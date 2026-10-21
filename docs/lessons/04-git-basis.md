# Les 4 — Git-basis

## Kernbegrippen
- **Working tree**: bestanden waarin je werkt.
- **Staging area**: wijzigingen die klaarstaan voor de volgende commit.
- **Commit**: een vastgelegd punt in de geschiedenis.
- **Branch**: een aparte ontwikkellijn; in dit project heet de hoofdbranch `main`.
- **Remote**: een externe repository, bijvoorbeeld op GitHub.

## Veelgebruikte commando's
```bash
git status
git add README.md
git diff --staged
git commit -m "Document learning project"
git log --oneline
```

`git add` kiest wijzigingen voor de volgende commit. `git commit` legt de gestagede wijzigingen vast. Controleer met `git status` wat er nog niet is vastgelegd.

## Typische cyclus
1. `git status`
2. Bewerk bestanden.
3. `git diff` om unstaged wijzigingen te bekijken.
4. `git add <bestand>` voor de gewenste wijzigingen.
5. `git diff --staged` om de staged wijzigingen te controleren.
6. `git commit -m "Korte beschrijving"`
7. `git status` om te controleren of de working tree schoon is.
