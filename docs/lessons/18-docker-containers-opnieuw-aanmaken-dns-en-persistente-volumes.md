# Les: Docker-containers opnieuw aanmaken, DNS en persistente volumes

## 1. Doel van de les

In deze les heb ik onderzocht wat er gebeurt wanneer een PostgreSQL-container opnieuw wordt aangemaakt. Ik heb geleerd hoe Docker DNS, interne IP-adressen, containers en named volumes samenwerken.

Het doel was om te controleren of:
- Docker DNS de database nog steeds kan vinden via de servicenaam `db`.
- De API na het opnieuw aanmaken van de databasecontainer nog verbinding kan maken.
- De bestaande databasegegevens behouden blijven.
- Docker de koppeling tussen een container en een named volume correct beheert.

## 2. Beginsituatie controleren

Ik begon met het controleren van de draaiende containers:

```bash
docker compose ps
```

Zowel `dockerdemo-api` als `postgres-demo` waren actief.

Daarna controleerde ik het interne IP-adres van PostgreSQL:

```bash
docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' postgres-demo
```

Uitvoer:

```text
172.18.0.2
```

Vervolgens controleerde ik hoe Docker de servicenaam `db` vertaalde:

```bash
docker exec dockerdemo-api getent hosts db
```

Uitvoer:

```text
172.18.0.2 db
```

Hieruit bleek dat Docker DNS de servicenaam `db` naar het interne IP-adres van PostgreSQL vertaalde.

## 3. De PostgreSQL-container opnieuw aanmaken

Ik voerde het volgende commando uit:

```bash
docker compose up -d --force-recreate db
```

Met dit commando liet ik Docker Compose de container van de service `db` opnieuw aanmaken.

- `up` zorgt ervoor dat de service draait.
- `-d` voert de container op de achtergrond uit.
- `--force-recreate` dwingt Docker Compose om de container opnieuw aan te maken.
- `db` beperkt de opdracht tot de PostgreSQL-service.

Docker bevestigde dat de container opnieuw was gestart.

Daarna controleerde ik het IP-adres opnieuw. Dit was nog steeds `172.18.0.2`.

**Belangrijke conclusie:** een container kan bij opnieuw aanmaken hetzelfde IP-adres behouden, maar dat is niet gegarandeerd. Daarom gebruik ik in mijn applicatie de servicenaam `db` in plaats van een hardgecodeerd IP-adres.

## 4. Docker DNS opnieuw testen

Ik voerde opnieuw uit:

```bash
docker exec dockerdemo-api getent hosts db
```

Uitvoer:

```text
172.18.0.2 db
```

De servicenaam `db` kon nog steeds worden vertaald naar het IP-adres van PostgreSQL.

Dit verklaart waarom mijn connection string deze hostnaam gebruikt:

```text
Host=db;Port=5432;Database=appdb;Username=appuser;Password=devpassword123
```

Binnen het door Docker Compose aangemaakte netwerk kunnen containers elkaar via de servicenaam bereiken. Docker DNS verzorgt de vertaling naar het bijbehorende IP-adres.

## 5. Controleren of de databasegegevens behouden bleven

Na het opnieuw aanmaken van PostgreSQL controleerde ik mijn API:

```bash
curl http://localhost:8080/lessons
```

Uitvoer:

```json
[
  {
    "id": 1,
    "title": "Docker volumes en PostgresSQL"
  },
  {
    "id": 2,
    "title": "Mijn aangepaste API-databaseverbinding"
  }
]
```

Beide lessen waren nog aanwezig. De API kon dus nog met PostgreSQL communiceren en de bestaande gegevens ophalen.

## 6. Het named volume onderzoeken

Ik inspecteerde het volume:

```bash
docker volume inspect postgres-data-clean
```

Belangrijke waarden uit de uitvoer:

```text
Name: postgres-data-clean
Driver: local
Scope: local
Mountpoint: /var/lib/docker/volumes/postgres-data-clean/_data
```

Daaruit leerde ik dat een named volume een afzonderlijk Docker-object is. De opslag wordt beheerd door Docker en blijft bestaan wanneer alleen de container opnieuw wordt aangemaakt.

Vervolgens onderzocht ik de mounts van de PostgreSQL-container:

```bash
docker inspect postgres-demo --format '{{json .Mounts}}'
```

Uitvoer:

```json
[
  {
    "Type": "volume",
    "Name": "postgres-data-clean",
    "Source": "/var/lib/docker/volumes/postgres-data-clean/_data",
    "Destination": "/var/lib/postgresql/data",
    "Driver": "local",
    "Mode": "rw",
    "RW": true,
    "Propagation": ""
  }
]
```

Hieruit blijkt dat het volume `postgres-data-clean` gekoppeld is aan `/var/lib/postgresql/data` in de container.

Dit is de map waarin PostgreSQL zijn databasebestanden opslaat.

- `Source` verwijst naar de opslaglocatie aan de kant van Docker.
- `Destination` verwijst naar de map binnen de container.
- `RW: true` betekent dat de mount lees- en schrijfrechten toestaat.

## 7. Wat heb ik geleerd?

### Containers en volumes zijn verschillend

Een container is een instantie waarin een applicatie draait. Een volume is een afzonderlijk opslagobject dat gegevens kan bewaren buiten de levensduur van die container.

Wanneer ik alleen de PostgreSQL-container opnieuw aanmaak en hetzelfde volume koppel, blijven de databasegegevens beschikbaar.

### Servicenamen zijn betrouwbaarder dan vaste IP-adressen

Een intern IP-adres kan veranderen wanneer Docker containers opnieuw aanmaakt. Door in de connection string `Host=db` te gebruiken, laat ik Docker DNS de servicenaam vertalen naar het actuele adres.

### Docker Compose beheert de samenwerking

Docker Compose maakt het eenvoudiger om de API, PostgreSQL en hun netwerkconfiguratie samen te beheren. De services kunnen via hun servicenaam communiceren wanneer ze op hetzelfde Compose-netwerk zitten.

### Een volume is geen back-up

Een named volume beschermt gegevens tegen het simpelweg opnieuw aanmaken van een container. Het vervangt echter geen back-up. Als het volume zelf wordt verwijderd of beschadigd raakt, kunnen de gegevens verloren gaan.

## 8. Belangrijke commando's uit deze les

| Commando | Doel |
|---|---|
| `docker compose ps` | De status van Compose-containers bekijken |
| `docker compose up -d --force-recreate db` | De databasecontainer opnieuw aanmaken |
| `docker inspect` | Configuratie en eigenschappen van een Docker-object bekijken |
| `docker exec` | Een commando uitvoeren in een draaiende container |
| `getent hosts db` | De servicenaam via de naamresolutie opzoeken |
| `docker volume inspect` | De eigenschappen van een named volume bekijken |
| `curl http://localhost:8080/lessons` | Controleren of de API de databasegegevens kan ophalen |

## 9. Conclusie

Ik heb in de praktijk getest dat ik een PostgreSQL-container opnieuw kan aanmaken zonder dat de bestaande databasegegevens verdwijnen, zolang het bestaande volume behouden blijft en opnieuw wordt gekoppeld.

Daarnaast heb ik bevestigd dat Docker DNS de servicenaam `db` blijft vertalen en dat mijn API de database na de recreatie nog kan bereiken.

Deze oefening heeft mijn inzicht verbeterd in containerlevenscycli, interne netwerkcommunicatie, DNS-resolutie en persistente opslag in Docker.
