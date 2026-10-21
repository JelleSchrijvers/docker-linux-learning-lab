# Les 10 — Problemen systematisch oplossen

## Een herhaalbaar proces
1. Lees de volledige foutmelding.
2. Bepaal in welke laag het probleem zit: shell, Git, authenticatie, build, container, netwerk of applicatie.
3. Controleer de huidige toestand met een veilige inspectieopdracht.
4. Verander één ding tegelijk.
5. Voer het commando opnieuw uit en vergelijk de uitvoer.
6. Noteer oorzaak en oplossing voor toekomstig gebruik.

## Voorbeelden van inspectiecommando's
```bash
pwd
git status
git remote -v
docker ps -a
docker logs <containernaam>
```

Vervang `<containernaam>` door de echte naam; typ de punthaken niet letterlijk in het commando.
