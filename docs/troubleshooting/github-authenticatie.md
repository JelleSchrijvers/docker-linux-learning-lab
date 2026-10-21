# Probleemoplossing — GitHub-authenticatie

## Symptoom
`git push` meldt:
```text
Password authentication is not supported for Git operations.
```

## Oorzaak
GitHub accepteert geen gewoon accountwachtwoord voor Git-operaties via HTTPS. Een succesvolle login bij GitHub CLI betekent niet automatisch dat Git is geconfigureerd om die login te gebruiken.

## Oplossing
```bash
gh auth status
gh auth setup-git
git push -u origin main
```

`gh auth setup-git` configureert Git om GitHub CLI als credential helper te gebruiken.

## WSL-opmerking
Als de browser niet automatisch opent, kopieer dan de URL uit de terminal en open die in een browser. Volg alleen de officiële GitHub-loginprocedure.

## Veiligheid
- Deel geen one-time codes of tokens.
- De melding `credentials saved in plain text` betekent dat credentials mogelijk onversleuteld lokaal worden opgeslagen; beoordeel je credential-opslaginstellingen.
- Verwijder tokens niet blindelings en plaats ze nooit in bestanden of screenshots.
