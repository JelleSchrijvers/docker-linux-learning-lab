# Workflow — Documenteren en committen

## Doel

Nieuwe leerervaringen op een consistente manier documenteren en wijzigingen gecontroleerd opslaan in Git.

## 1. Documenteer een leerervaring

Een nuttige les bevat:

1. **Doel** — wat wilde ik bereiken?
2. **Situatie of foutmelding** — wat gebeurde er?
3. **Onderzoek** — welke controles heb ik uitgevoerd?
4. **Oplossing** — welke stap werkte?
5. **Uitleg** — waarom werkte die stap?
6. **Controle** — hoe heb ik vastgesteld dat het werkt?
7. **Reflectie** — wat begrijp ik nu beter?

Neem geen wachtwoorden, tokens, API-sleutels of andere geheimen op in documentatie.

## 2. Controleer wijzigingen

```bash
git status
git diff
```

Bekijk de gewijzigde bestanden en lees de diff voordat je alles toevoegt.

## 3. Stage de bedoelde bestanden

```bash
git add docs/
git status
```

Gebruik `git add docs/` wanneer alleen documentatie moet worden opgenomen. Gebruik `git add .` alleen als je bewust alle gewijzigde bestanden wilt klaarzetten.

## 4. Commit met een beschrijvende boodschap

Voor documentatie:

```bash
git commit -m "docs: update learning notes and portfolio documentation"
```

Een commitbericht beschrijft de verandering, niet alleen dat er “updates” zijn gebeurd. Als code en documentatie verschillende doelen hebben, overweeg dan aparte commits.

## 5. Controleer na de commit

```bash
git status
git log --oneline -3
```

Een schone werkboom betekent dat er geen niet-gecommitte wijzigingen meer zijn. Het betekent niet automatisch dat de commit al naar GitHub is gepusht.

## Transparantie over AI-hulp

AI kan worden gebruikt om uitleg, structuur of documentatievoorstellen te maken. Vermeld dat eerlijk in het portfolio. Controleer de inhoud zelf en voer de beschreven commando's zelf uit, zodat duidelijk blijft wat je begrijpt en hebt getest.
