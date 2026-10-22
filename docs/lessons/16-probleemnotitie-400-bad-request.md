# Probleemnotitie — 400 Bad Request bij een API-request

**Datum:** 22 oktober 2026

## 1. Symptoom

Tijdens het testen van mijn API kreeg ik de volgende HTTP-statuscode:

```http
HTTP/1.1 400 Bad Request
```

De response bevatte de melding:

```json
"Title mag niet leeg zijn."
```

## 2. Onderzoek

Ik heb de HTTP-statusregel, headers en responsebody bekeken.

Uit de response bleek dat de API het request afwees omdat het veld `Title` niet de vereiste waarde bevatte.

Ik heb hiervan geleerd dat een foutcode niet automatisch betekent dat de API-server niet werkt. De server kan het request correct ontvangen en vervolgens afwijzen op basis van validatieregels.

## 3. Oorzaak

De melding wees erop dat de titel ontbrak of leeg was.

De exacte oorzaak in de code moet worden gecontroleerd aan de hand van het request en de validatieregels in de API.

## 4. Oplossing en controle

Om dit probleem correct op te lossen, moet ik:

1. De juiste API-route controleren.
2. De verwachte HTTP-methode controleren.
3. De vereiste velden in het requestmodel of de API-code bekijken.
4. Een request met een geldige, niet-lege `Title` versturen.
5. De HTTP-statuscode en responsebody opnieuw controleren.

Ik moet de route en JSON-body uit mijn eigen project gebruiken en geen onbekende endpointnamen aannemen.

## 5. Controle van de API-response

Na mijn tests kreeg ik een JSON-array terug met records zoals:

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

Hieruit kon ik afleiden dat de API deze records kon teruggeven.

Om ook te bewijzen dat nieuwe gegevens na een container-herstart behouden blijven, moet ik de API of container herstarten en de gegevens opnieuw ophalen.

## 6. Wat heb ik geleerd?

- HTTP-statuscodes helpen bij het opsporen van problemen.
- De responsebody kan uitleggen waarom een request wordt afgewezen.
- Validatie voorkomt dat ongeldige invoer zomaar wordt verwerkt.
- Ik moet requests testen met zowel ongeldige als geldige invoer.
- Na een wijziging moet ik opnieuw testen om het resultaat te controleren.

## 7. Conclusie

Ik heb geleerd hoe ik een `400 Bad Request` onderzoek en hoe ik een validatiemelding interpreteer. Ik kan nu beter onderscheid maken tussen een server die niet bereikbaar is en een API die een ongeldig request afwijst.
