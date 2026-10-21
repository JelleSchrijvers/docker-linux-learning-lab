# Les 3 — Paden, rechten en sudo

## Begrippen
- Linux gebruikt `/` als scheidingsteken in paden.
- `.` betekent de huidige map; `..` betekent de bovenliggende map.
- `sudo` voert een commando uit met verhoogde rechten, na authenticatie.
- Gebruik `sudo` alleen wanneer dat nodig is; gebruik het niet standaard voor projectbestanden.

## Commando's
```bash
pwd
ls -l
id
sudo apt update
```

`ls -l` toont onder meer rechten, eigenaar en groep. `sudo apt update` ververst de pakketindex; het installeert op zichzelf geen upgrades.

## Veilig werken
Lees een commando voordat je het uitvoert. Wees extra voorzichtig met `sudo`, `rm -r`, redirects naar systeembestanden en commando's die je online kopieert.
