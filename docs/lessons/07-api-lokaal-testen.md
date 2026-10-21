# Les 7 — Een API lokaal testen

## Doel
Een HTTP-endpoint aanroepen en controleren of de applicatie antwoordt.

In dit project is `/weatherforecast` gebruikt als testendpoint.

## Voorbeeld
```bash
curl -i http://localhost:5252/weatherforecast
```

Gebruik de poort die jouw applicatie daadwerkelijk meldt; de voorbeeldpoort `5252` kan per profiel verschillen.

- `curl` verstuurt een HTTP-verzoek.
- `-i` toont ook de HTTP-status en responseheaders.
- Een statuscode in de `200`-reeks betekent doorgaans dat het verzoek succesvol is verwerkt.

## Proces
1. Start de app.
2. Lees de lokale URL in de terminal.
3. Roep het endpoint aan met `curl`.
4. Controleer statuscode en response body.
5. Stop de app met `Ctrl+C`.
