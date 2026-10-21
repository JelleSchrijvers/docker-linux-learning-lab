# Proces — Git-workflow

Gebruik dit proces wanneer je wijzigingen in je repository wilt vastleggen en publiceren.

## 1. Controleer de situatie
```bash
git status
git branch --show-current
git remote -v
```

## 2. Bekijk de wijzigingen
```bash
git diff
```

## 3. Stage alleen wat je wilt vastleggen
```bash
git add <bestand-of-map>
git diff --staged
```

## 4. Commit
```bash
git commit -m "Describe the change"
```

## 5. Push naar GitHub
```bash
git push
```

Bij de eerste push van een nieuwe branch kan dit nodig zijn:
```bash
git push -u origin main
```

## 6. Controleer
```bash
git status
git log --oneline -5
```

Vervang placeholders zoals `<bestand-of-map>` door echte paden. Gebruik `git add .` alleen als je eerst gecontroleerd hebt dat alle wijzigingen geschikt zijn om te committen.
