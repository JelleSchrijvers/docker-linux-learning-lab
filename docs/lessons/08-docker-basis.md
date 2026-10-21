# Les 8 — Docker-basisbegrippen

- **Image**: een pakket met de applicatie en de benodigde runtimebestanden.
- **Container**: een draaiende instantie van een image.
- **Dockerfile**: recept waarmee Docker een image bouwt.
- **Port mapping**: koppelt een poort op de host aan een poort in de container.
- **Build context**: bestanden die Docker tijdens het bouwen mag gebruiken.

## Commando's
```bash
docker --version
docker images
docker ps
docker ps -a
```

`docker ps` toont draaiende containers. `docker ps -a` toont ook gestopte containers. `docker images` toont lokaal beschikbare images.
