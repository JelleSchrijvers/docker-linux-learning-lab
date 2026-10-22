# Les 12 — Docker Desktop en WSL 2 integreren

## Doel

Docker-commando's vanuit Ubuntu (WSL 2) kunnen uitvoeren terwijl Docker Desktop op Windows de Docker-engine levert.

## Het probleem

Bij het uitvoeren van:

```bash
docker --version
```

kan Ubuntu deze melding tonen:

```text
The command 'docker' could not be found in this WSL 2 distro.
We recommend to activate the WSL integration in Docker Desktop settings.
```

Dit betekent meestal dat Docker CLI niet beschikbaar is in die WSL-distributie. Het betekent niet automatisch dat Docker volledig opnieuw geïnstalleerd moet worden.

## Stappen om dit te onderzoeken

1. Open Docker Desktop in Windows.
2. Ga naar **Settings**.
3. Controleer of de WSL 2-engine is ingeschakeld, indien deze instelling beschikbaar is.
4. Open **Resources → WSL Integration**.
5. Schakel integratie in voor de gebruikte Ubuntu-distributie.
6. Pas de instellingen toe en herstart Docker Desktop indien daarom wordt gevraagd.
7. Open Ubuntu opnieuw en test:

```bash
docker --version
docker info
```

`docker --version` controleert of de CLI beschikbaar is. `docker info` controleert uitgebreider of de CLI de Docker-engine kan bereiken.

## Als het nog niet werkt

- Controleer in Windows PowerShell of WSL beschikbaar is met `wsl --status`.
- Controleer de distributies met `wsl --list --verbose`.
- Controleer dat Ubuntu met WSL 2 draait.
- Controleer in Docker Desktop of de juiste distributie is geselecteerd.
- Herstart WSL eventueel vanuit PowerShell met `wsl --shutdown` en open Ubuntu opnieuw.

Voer niet meteen willekeurige installatiecommando's uit. Lees eerst de foutmelding en bepaal of het probleem bij de CLI, WSL-integratie of de Docker-engine ligt.

## Wat ik hiervan leer

Docker Desktop en Ubuntu in WSL 2 zijn twee onderdelen die met elkaar moeten communiceren. Het activeren van WSL-integratie maakt de Docker CLI en engine bruikbaar vanuit de Linux-terminal.

## Controle

- [ ] `docker --version` werkt in Ubuntu.
- [ ] `docker info` toont informatie over de Docker-engine.
- [ ] Ik kan uitleggen waarom WSL-integratie nodig is.
