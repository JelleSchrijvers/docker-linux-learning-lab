# Mappenstructuur en migratie

## Gewenste structuur

```text
linux-docker-learning-lab/
├── .gitignore
├── Dockerfile
├── README.md
├── LESSON-INDEX.md
├── docs/
│   ├── lessons/
│   ├── processes/
│   └── troubleshooting/
├── scripts/
└── src/
    └── DockerDemo/
        ├── DockerDemo.csproj
        ├── Program.cs
        ├── appsettings.json
        ├── appsettings.Development.json
        ├── DockerDemo.http
        └── Properties/
            └── launchSettings.json
```

De daadwerkelijke inhoud kan afwijken; behoud bestanden die in jouw project aanwezig zijn. `.git/` blijft automatisch door Git beheerd en hoort niet handmatig verplaatst te worden.

## Veilige migratie

1. Ga naar de repository-root en controleer `git status`.
2. Commit of bewaar alle wijzigingen voordat je bestanden verplaatst.
3. Maak de mappen:
   ```bash
   mkdir -p src/DockerDemo docs/lessons docs/processes docs/troubleshooting scripts
   ```
4. Verplaats alleen de bestanden die bij de .NET-app horen naar `src/DockerDemo/`. Laat `.gitignore`, `.git/`, de centrale README, lesindex en de root-Dockerfile in de root staan.
5. Controleer de Dockerfile en bouwcontext. Als de Dockerfile in de root blijft, moet de build context doorgaans `src/DockerDemo/` zijn:
   ```bash
   docker build -t dockerdemo:local -f Dockerfile src/DockerDemo
   ```
6. Bouw en test de app opnieuw.
7. Controleer alle wijzigingen:
   ```bash
   git status
   git diff --stat
   ```
8. Commit de herstructurering pas als de build en test geslaagd zijn.

## Let op
Deze documentatiebundel maakt de nieuwe documentatiebestanden aan, maar verplaatst je bestaande projectbestanden niet automatisch. Verplaatsen kan paden in de Dockerfile en lokale tooling beïnvloeden. Controleer dus eerst de echte bestanden in jouw repository.
