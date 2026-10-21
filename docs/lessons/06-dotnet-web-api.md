# Les 6 — De structuur van een .NET Web API

## Bestanden in dit project
- `DockerDemo.csproj`: projectbestand met framework- en package-informatie.
- `Program.cs`: startpunt en configuratie van de webapplicatie.
- `appsettings.json`: algemene applicatie-instellingen.
- `appsettings.Development.json`: instellingen voor de ontwikkelomgeving.
- `Properties/launchSettings.json`: lokale profielen voor starten en debuggen.
- `DockerDemo.http`: verzoeken waarmee endpoints handmatig kunnen worden getest.
- `Dockerfile`: instructies om een Docker-image te bouwen.

## Belangrijk onderscheid
`launchSettings.json` is vooral bedoeld voor lokaal ontwikkelen. Docker gebruikt de instructies en omgevingsvariabelen uit de Dockerfile of de containerconfiguratie.

## Verkenning
```bash
dotnet --info
dotnet build
dotnet run
```

Voer `dotnet run` uit vanuit de map met het `.csproj`-bestand. Let op de URL's die de applicatie in de terminal meldt.
