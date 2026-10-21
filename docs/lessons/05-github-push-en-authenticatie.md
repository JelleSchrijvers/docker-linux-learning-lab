# Les 5 — GitHub publiceren en authenticatie

## Wat ik heb gedaan
Ik heb lokaal een Git-repository gemaakt, een eerste commit aangemaakt, een GitHub-repository toegevoegd als remote en de branch `main` gepusht.

## Commando's
```bash
git remote -v
git push -u origin main
```

- `git remote -v` toont de gekoppelde remote URL's.
- `git push` uploadt lokale commits naar de remote.
- `-u` stelt de upstream in, zodat latere pushes meestal met `git push` kunnen.

## HTTPS-authenticatie
GitHub accepteert geen gewoon accountwachtwoord meer voor Git-operaties via HTTPS. GitHub CLI kan authenticatie regelen:

```bash
gh auth login
gh auth setup-git
git push -u origin main
```

Bij `gh auth login` kies je GitHub.com en HTTPS, en volg je de browser-login. Als de browser niet automatisch opent in WSL, kun je de getoonde URL handmatig openen.

## Veiligheid
- Deel geen one-time codes, access tokens of wachtwoorden.
- Voer `gh auth token` niet uit wanneer je niet bewust een token wilt bekijken.
- Controleer zorgvuldig welke bestanden je publiceert.
