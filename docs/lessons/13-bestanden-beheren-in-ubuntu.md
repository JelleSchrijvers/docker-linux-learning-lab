# Les 13 — Bestanden en mappen beheren in Ubuntu

## Doel

Bestaande bestanden vanuit de Ubuntu-terminal bekijken, aanpassen en controleren.

## Werken vanuit de juiste map

```bash
pwd
ls -la
```

- `pwd` toont de huidige werkmap.
- `ls -la` toont bestanden, inclusief verborgen bestanden zoals `.gitignore`.

Ga naar de projectmap met:

```bash
cd ~/projects/docker-linux
```

## Bestanden lezen

```bash
cat README.md
less README.md
```

`cat` toont de inhoud direct. `less` is handiger voor langere bestanden; druk op `q` om af te sluiten.

## Bestanden aanpassen

Een eenvoudige terminaleditor is `nano`:

```bash
nano README.md
```

Sla in nano op met `Ctrl+O`, druk op Enter en sluit af met `Ctrl+X`.

Controleer daarna je wijziging:

```bash
git diff -- README.md
```

`git diff` toont welke regels veranderd zijn sinds de laatste commit.

## Verborgen bestanden en Git

Bestanden waarvan de naam met een punt begint, zoals `.gitignore`, zijn in Linux verborgen in standaard directory-overzichten. Gebruik `ls -la` om ze te zien.

Controleer welke bestanden Git ziet:

```bash
git status --short
```

## Wat ik hiervan leer

De terminal kan gebruikt worden om door mappen te navigeren, bestanden te lezen en tekstbestanden te wijzigen. `git diff` helpt om wijzigingen vóór een commit na te kijken.

## Controle

- [ ] Ik kan met `pwd` zien waar ik werk.
- [ ] Ik kan een bestand bekijken en aanpassen.
- [ ] Ik controleer mijn wijziging met `git diff`.
