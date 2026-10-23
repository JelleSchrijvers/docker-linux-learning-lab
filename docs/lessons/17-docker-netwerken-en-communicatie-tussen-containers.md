# Les: Docker-netwerken en communicatie tussen containers

## Doel

Begrijpen hoe Docker Compose containers met elkaar laat communiceren via een eigen netwerk en interne DNS.

## Mijn omgeving

- API-container: `dockerdemo-api`
- Databasecontainer: `postgres-demo`
- Compose-netwerk: `dockerdemo_default`
- Docker-netwerkdriver: `bridge`
- API-poort: `8080`
- PostgreSQL-poort: `5432`

## Wat heb ik geleerd?

### 1. Docker Compose maakt een projectnetwerk aan

Met `docker network ls` vond ik het netwerk `dockerdemo_default`.

Met `docker network inspect dockerdemo_default` controleerde ik de configuratie en zag ik dat beide containers op hetzelfde netwerk waren aangesloten.

Het netwerk gebruikte subnet `172.18.0.0/16`. De API had intern IP-adres `172.18.0.3` en PostgreSQL `172.18.0.2`.

### 2. Docker gebruikt interne DNS

Ik voerde het volgende commando uit:

```bash
docker exec dockerdemo-api getent hosts db
```

Uitvoer:

```text
172.18.0.2  db
```

Hiermee heb ik gecontroleerd dat de servicenaam `db` wordt vertaald naar het interne IP-adres van PostgreSQL.

Daarom gebruikt mijn API deze connection string:

```text
Host=db;Port=5432
```

Ik hoef het interne IP-adres niet hard te coderen. Docker Compose regelt de naamresolutie.

### 3. Het verschil tussen localhost en db

Ik voerde dit commando uit:

```bash
docker exec dockerdemo-api getent hosts localhost
```

De uitvoer bevatte:

```text
::1 localhost ip6-localhost ip6-loopback
```

`::1` is het IPv6-loopbackadres. Binnen de API-container verwijst `localhost` naar die container zelf, niet naar PostgreSQL.

Om de database vanuit de API te bereiken, gebruik ik daarom de servicenaam `db`.

### 4. De volledige verbinding testen

Ik voerde uit:

```bash
curl http://localhost:8080/lessons
```

De API retourneerde:

```json
[
  {"id":1,"title":"Docker volumes en PostgresSQL"},
  {"id":2,"title":"Mijn aangepaste API-databaseverbinding"}
]
```

Dit bevestigt dat ik de API via de gepubliceerde poort kan bereiken en dat de API gegevens uit PostgreSQL kan ophalen.

## Belangrijke commando's

| Commando | Doel |
|---|---|
| `docker network ls` | Docker-netwerken weergeven |
| `docker network inspect dockerdemo_default` | Netwerkdetails en verbonden containers bekijken |
| `docker exec dockerdemo-api getent hosts db` | Interne DNS-resolutie van de database testen |
| `docker exec dockerdemo-api getent hosts localhost` | De localhost-resolutie binnen de API-container bekijken |
| `docker compose ps` | De status van de Compose-services bekijken |
| `curl http://localhost:8080/lessons` | De API en databaseverbinding testen |

## Conclusie

Ik heb geleerd dat Docker Compose een eigen bridge-netwerk aanmaakt voor services en dat containers elkaar via servicenaam kunnen bereiken. Ik begrijp nu waarom `Host=db` werkt en waarom `localhost` binnen een container niet naar een andere container verwijst.

Ik heb deze concepten getest met mijn eigen ASP.NET Core API en PostgreSQL-database.
