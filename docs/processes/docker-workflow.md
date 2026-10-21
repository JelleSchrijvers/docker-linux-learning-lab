# Proces — Docker-workflow

## 1. Controleer de Dockerfile en projectbestanden
Lees de Dockerfile en controleer de build context voordat je bouwt.

## 2. Bouw een image
Voor een Dockerfile in de repository-root en een project in `src/DockerDemo/`:
```bash
docker build -t dockerdemo:local -f Dockerfile src/DockerDemo
```

## 3. Start de container
```bash
docker run --rm -d --name dockerdemo -p 8080:8080 dockerdemo:local
```

## 4. Test de API
```bash
curl -i http://localhost:8080/weatherforecast
```

## 5. Bekijk logs en status
```bash
docker ps
docker logs dockerdemo
```

## 6. Stop de container
```bash
docker stop dockerdemo
```

Als de container niet start, kijk eerst naar `docker ps -a` en de logs. Poorten, bestandslocaties en Dockerfile-paden moeten overeenkomen met de huidige projectstructuur.
