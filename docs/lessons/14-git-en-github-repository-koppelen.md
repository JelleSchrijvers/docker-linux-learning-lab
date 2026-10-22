# Les 14 — Een lokale Git-repository koppelen aan GitHub

## Doel

Een lokale Git-repository veilig koppelen aan een GitHub-repository en de eerste push voorbereiden.

## Lokale status controleren

Voer deze commando's uit vanuit de projectmap:

```bash
git status
git log --oneline -5
git remote -v
```

- `git status` toont de werkboomstatus.
- `git log --oneline -5` toont de vijf meest recente commits.
- `git remote -v` toont de ingestelde remote-URL's.

## Een GitHub-repository controleren

Met GitHub CLI (`gh`) kun je repositorygegevens bekijken:

```bash
gh repo view OWNER/REPOSITORY --json name,isPrivate,url
```

Vervang `OWNER/REPOSITORY` door de juiste eigenaar en repositorynaam.

Controleer of de remote en de repositorynaam overeenkomen. Let goed op namen die op elkaar lijken; één omgedraaid woord kan naar een andere repository verwijzen.

## Een remote toevoegen

Als `git remote -v` geen uitvoer geeft, kun je een remote toevoegen:

```bash
git remote add origin https://github.com/OWNER/REPOSITORY.git
git remote -v
```

Als `origin` al bestaat maar naar de verkeerde repository wijst, stop dan eerst en controleer de URL voordat je die aanpast.

## Controleren of GitHub al commits heeft

```bash
gh api repos/OWNER/REPOSITORY/commits --jq '.[].commit.message'
```

Als GitHub meldt dat de repository leeg is met HTTP 409, betekent dat dat er nog geen commits zijn om op te halen. Dit is niet hetzelfde als een fout in je lokale commit.

## De eerste push

Als de remote juist is en je zeker weet dat je naar de bedoelde lege repository pusht:

```bash
git push -u origin main
```

Hiermee publiceer je de lokale branch `main` en stel je de upstream in. Controleer daarna:

```bash
git status
git log --oneline -3
gh repo view OWNER/REPOSITORY
```

## Belangrijke veiligheidsregel

Verwijder of overschrijf een oude repository niet voordat de nieuwe repository is gecontroleerd en de bestanden online zichtbaar zijn. Bij meerdere repositories met bijna dezelfde naam moet de exacte URL worden bevestigd.

## Wat ik hiervan leer

Git houdt lokaal commits bij; GitHub host een remote kopie. `origin` is alleen een afgesproken naam voor een remote en bewijst op zichzelf niet dat de URL juist is. Daarom controleer ik zowel `git remote -v` als de repository op GitHub vóór ik push.

## Controle

- [ ] Ik heb de juiste GitHub-URL gecontroleerd.
- [ ] Ik heb mijn lokale commitgeschiedenis gecontroleerd.
- [ ] Ik weet of de remote repository al commits bevat.
- [ ] Ik kan uitleggen wat `git push -u origin main` doet.
