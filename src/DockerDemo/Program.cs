var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
var connectionString = 
	builder.Configuration.GetConnectionString("DefaultConnection");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "UBUNTU", "LEARNING", "UBUNTU", "AND", "DOCKER","Docker cache test","Cache demonstratie",
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/lessons", async () =>
{
    await using var dataSource =
        Npgsql.NpgsqlDataSource.Create(connectionString!);

    await using var command =
        dataSource.CreateCommand("SELECT id, title FROM lessons ORDER BY id");

    await using var reader = await command.ExecuteReaderAsync();

    var lessons = new List<Lesson>();

    while (await reader.ReadAsync())
    {
        lessons.Add(new Lesson(
            reader.GetInt32(0),
            reader.GetString(1)
        ));
    }

    return Results.Ok(lessons);
});

app.MapPost("/lessons", async (CreateLesson request) =>
{
    if (string.IsNullOrWhiteSpace(request.Title))
    {
        return Results.BadRequest("Title mag niet leeg zijn.");
    }

    await using var dataSource =
        Npgsql.NpgsqlDataSource.Create(connectionString!);

    await using var command = dataSource.CreateCommand(
        "INSERT INTO lessons (title) VALUES ($1) RETURNING id, title");

    command.Parameters.AddWithValue(request.Title);

    await using var reader = await command.ExecuteReaderAsync();
    await reader.ReadAsync();

    var lesson = new Lesson(
        reader.GetInt32(0),
        reader.GetString(1)
    );

    return Results.Created($"/lessons/{lesson.Id}", lesson);
});

app.MapDelete("/lessons/{id:int}", async (int id) =>
{
    await using var dataSource =
        Npgsql.NpgsqlDataSource.Create(connectionString!);

    await using var command = dataSource.CreateCommand(
        "DELETE FROM lessons WHERE id = $1 RETURNING id");

    command.Parameters.AddWithValue(id);

    var deletedId = await command.ExecuteScalarAsync();

    if (deletedId is null)
    {
        return Results.NotFound($"Les met id {id} niet gevonden.");
    }

    return Results.Ok($"Les met id {id} verwijderd.");
});

app.MapPut("/lessons/{id:int}", async (int id, CreateLesson request) =>
{
    if (string.IsNullOrWhiteSpace(request.Title))
    {
        return Results.BadRequest("Title mag niet leeg zijn.");
    }

    await using var dataSource =
        Npgsql.NpgsqlDataSource.Create(connectionString!);

    await using var command = dataSource.CreateCommand(
        "UPDATE lessons SET title = $1 WHERE id = $2 RETURNING id, title");

    command.Parameters.AddWithValue(request.Title);
    command.Parameters.AddWithValue(id);

    await using var reader = await command.ExecuteReaderAsync();

    if (!await reader.ReadAsync())
    {
        return Results.NotFound($"Les met id {id} niet gevonden.");
    }

    var lesson = new Lesson(
        reader.GetInt32(0),
        reader.GetString(1)
    );

    return Results.Ok(lesson);
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

record Lesson(int Id, string Title);
record CreateLesson(string Title);
