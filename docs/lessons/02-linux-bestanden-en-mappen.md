# Les 2 — Bestanden en mappen beheren

## Veelgebruikte commando's
```bash
ls -la
mkdir -p docs/lessons
touch notities.md
cp bron.txt kopie.txt
mv oud.txt nieuw.txt
```

- `ls -la`: toont ook verborgen bestanden, zoals `.gitignore`.
- `mkdir -p`: maakt mappen aan, inclusief ontbrekende bovenliggende mappen.
- `touch`: maakt een leeg bestand aan als het nog niet bestaat.
- `cp`: kopieert een bestand.
- `mv`: verplaatst of hernoemt een bestand.

Verwijderen met `rm` kan definitief zijn. Controleer het pad zorgvuldig voordat je het gebruikt.

## Relatieve en absolute paden
- Relatief: `docs/lessons/les.md` — vanaf de huidige map.
- Absoluut: `/home/jelle/projects/...` — vanaf de root van het bestandssysteem.

## Proces
1. Controleer je huidige map met `pwd`.
2. Bekijk de inhoud met `ls -la`.
3. Maak alleen de mappen die je nodig hebt.
4. Controleer het resultaat opnieuw met `find . -maxdepth 2 -type d`.
