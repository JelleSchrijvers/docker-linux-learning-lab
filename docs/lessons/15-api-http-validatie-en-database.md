# Les 15 — API testen, validatie en databasegegevens controleren

**Datum:** 22 oktober 2026  
**Onderwerp:** ASP.NET Core Web API, HTTP, JSON, invoervalidatie en database-interactie

## 1. Wat heb ik geleerd?

Tijdens deze les heb ik verder gewerkt aan mijn ASP.NET Core Web API. Ik heb HTTP-requests uitgevoerd, API-responses onderzocht en geleerd hoe ik foutmeldingen kan interpreteren.

Ik heb ook geleerd hoe ik JSON-gegevens met records kan lezen en hoe ik kan controleren of de API gegevens teruggeeft.

De belangrijkste onderwerpen waren:

- HTTP-statuscodes begrijpen.
- API-responses en headers bekijken met `curl`.
- JSON-data lezen.
- Validatiefouten herkennen.
- API- en database-interactie onderzoeken.
- Problemen systematisch opsporen.

## 2. HTTP-responses begrijpen

Tijdens het testen ontving ik deze HTTP-response:

```http
HTTP/1.1 400 Bad Request
Content-Type: application/json; charset=utf-8
```

De responsebody bevatte de melding:

```json
"Title mag niet leeg zijn."
```

### Wat betekent dit?

**`400 Bad Request`**

De server heeft het request ontvangen, maar de inhoud ervan voldoet niet aan de verwachtingen van de API.

**`Content-Type: application/json`**

De response bevat JSON-data.

**`Title mag niet leeg zijn.`**

De API controleert of het veld `Title` een geldige waarde bevat. Een lege of ontbrekende titel wordt afgewezen.

Ik heb hierdoor geleerd dat een HTTP 400-fout niet automatisch betekent dat de server uitstaat. De API kan bereikbaar zijn en toch een request afwijzen omdat de invoer ongeldig is.

## 3. API testen met curl

Met `curl` kan ik vanuit Ubuntu HTTP-requests naar mijn API sturen.

Voorbeeld van een GET-request:

```bash
curl -i http://localhost:8080/VERVANG-DOOR-HET-JUISTE-ENDPOINT
```

De optie `-i` zorgt ervoor dat ook de HTTP-statusregel en headers worden weergegeven.

De voorbeeldroute moet ik vervangen door het echte endpoint van mijn API.

Bij het testen controleer ik:

1. Of de URL en poort correct zijn.
2. Welke HTTP-statuscode de server teruggeeft.
3. Welke headers aanwezig zijn.
4. Welke gegevens of foutmelding in de responsebody staan.
5. Of de response overeenkomt met wat ik verwachtte.

## 4. JSON-responses lezen

Tijdens het testen kreeg ik deze lijst met records terug:

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

### Wat heb ik hieruit geleerd?

- De response is een JSON-array.
- De array bevat meerdere records.
- Elk record heeft een `id` en een `title`.
- De API kan de records als gestructureerde gegevens teruggeven.

Hiermee heb ik geleerd hoe ik API-output kan controleren en hoe ik kan zien welke gegevens een endpoint teruggeeft.

## 5. Validatie van API-invoer

De foutmelding `Title mag niet leeg zijn.` heeft mij geleerd dat API's invoer kunnen valideren.

Om dit verder te testen, kan ik drie situaties vergelijken:

1. Een request waarbij `Title` ontbreekt.
2. Een request waarbij `Title` leeg is.
3. Een request waarbij `Title` een geldige tekst bevat.

Bij iedere test noteer ik de statuscode, responsebody en het resultaat.

Ik moet de juiste route, HTTP-methode en JSON-structuur gebruiken die mijn eigen API verwacht. Die informatie controleer ik in `Program.cs` en de bijbehorende request- of modelcode.

## 6. API en database controleren

Ik heb gewerkt aan de API-databaseverbinding en records via de API bekeken.

Een goede controle bestaat uit de volgende stappen:

1. De API starten met de juiste configuratie.
2. Een GET-request uitvoeren om bestaande records op te halen.
3. Een geldig record toevoegen via het juiste endpoint.
4. Opnieuw een GET-request uitvoeren.
5. Controleren of het nieuwe record in de response verschijnt.
6. Indien van toepassing de API of container herstarten en controleren of het record nog bestaat.

Een record dat na een nieuw GET-request zichtbaar blijft, bewijst dat het via de API opnieuw kan worden opgehaald. Om te controleren of gegevens ook na een container-herstart bewaard blijven, moet ik die herstarttest afzonderlijk uitvoeren.

## 7. Problemen en wat ik ervan heb geleerd

| Probleem of waarneming | Wat ik heb geleerd |
|---|---|
| `400 Bad Request` | De server kan bereikbaar zijn terwijl het request ongeldig is. |
| `Title mag niet leeg zijn.` | De API controleert of verplichte invoer aanwezig is. |
| JSON met `id` en `title` | API-responses kunnen gestructureerde records bevatten. |
| Meerdere records in één array | Een endpoint kan een lijst van records teruggeven. |
| Databaseverbinding onderzoeken | API-configuratie en database-interactie moeten gecontroleerd worden met echte requests en responses. |

## 8. Wat moet ik nog controleren?

- [ ] De echte GET-route van mijn API noteren.
- [ ] De echte route en JSON-body voor het toevoegen van records noteren.
- [ ] Ontbrekende, lege en geldige `Title` testen.
- [ ] Controleren of een nieuw record na een herstart behouden blijft.
- [ ] Controleren of de lokale code overeenkomt met de code op GitHub.
- [ ] Controleren dat er geen wachtwoorden of andere geheimen in Git terechtkomen.

## 9. Resultaat

Ik heb geleerd om HTTP-responses systematisch te onderzoeken, validatiefouten te herkennen en JSON-gegevens te lezen. Ook heb ik verder gewerkt aan het begrijpen en controleren van de API-databaseverbinding.

Deze les bouwt voort op mijn bestaande documentatie over API-testen, Docker en bestandsbeheer in Ubuntu.
