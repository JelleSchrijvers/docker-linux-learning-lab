# Les 9 — Een .NET-app in Docker bouwen en starten

## Wat dit project doet
De Dockerfile gebruikt meerdere build-stages: de SDK-image bouwt de app en een kleinere ASP.NET-runtime-image voert de gepubliceerde app uit. De container luistert op poort `8080`.

## Voorbeeldworkflow
Voer de commando's uit vanuit de map waarin de Dockerfile staat. Als de Dockerfile in de repository-root blijft en de projectcode in `src/DockerDemo/` staat, gebruik dan die projectmap als build context:

```bash
docker build -t dockerdemo:local -f Dockerfile src/DockerDemo
docker run --rm -d --name dockerdemo -p 8080:8080 dockerdemo:local
curl -i http://localhost:8080/weatherforecast
docker logs dockerdemo
docker stop dockerdemo
```

Deze build-opdracht gaat ervan uit dat de Dockerfile in de repository-root staat en paden in de Dockerfile relatief aan de projectmap zijn. Controleer dit na het verplaatsen van bestanden.

- `-t`: geeft het image een naam en tag.
- `-d`: draait de container op de achtergrond.
- `--name`: geeft de container een herkenbare naam.
- `-p 8080:8080`: koppelt hostpoort 8080 aan containerpoort 8080.
- `--rm`: verwijdert de container na het stoppen.

## Controle
Test altijd het endpoint en bekijk logs als de container niet werkt. Verwijder of overschrijf geen images/containers voordat je weet welke je nodig hebt.
