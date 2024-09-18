# File Count

Ecrivez un programme qui demande le chemin d'un dossier et qui donne le nombre de fichiers et de dossiers qu'il y a dans le dossier courant et tout ceux qui sont en dessous (quelle que soit la profondeur de la structure de dossier).

```
Dossier: c:\temp
c:\temp contient 69 fichiers et 32 dossiers
```

### Etape 1
Trouvez les méthodes dont vous aurez besoin dans la classe statique [`Directory`](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory?view=net-8.0) de .NET

Ecrivez un programme qui ne compte que les fichiers. Ce programme doit être une traduction en code de la phrase suivante:

> Le **nombre total de fichiers** dans un dossier est égal au nombre de fichiers présent dans ce dossier plus la somme du **nombre total de fichiers** dans chacun de ses sous-dossier.

(commit)

### Etape 2
Ajoutez le code nécessaire pour que votre programme compte également le nombre de dossiers.

(commit)

### Etape 3
Observez bien votre code. Il utilise probablement une fonction impure, n'est-ce pas ?

Si ce n'est pas le cas, félicitations! vous avez terminé cet exercice.

Sinon, refactorisez votre code pour qu'il ne contienne pas de fonction impure.

Indice: votre fonction doit retourner deux valeurs (nombre de fichiers et nombre de dossiers). Vous pouvez faire cela avec une classe ou un [Tuple](https://learn.microsoft.com/en-us/dotnet/api/system.tuple?view=net-8.0).

(commit)
