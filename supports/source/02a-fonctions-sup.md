# Fonctions d'ordre supérieur en C#

Les fonctions d'ordre supérieur sont un concept important en programmation qui permet de passer des fonctions comme des arguments à d'autres fonctions. Cela peut sembler complexe au début, mais avec cet article, vous allez comprendre les bases de ces fonctions et apprendre à les utiliser en C#.

## Qu'est-ce qu'une fonction d'ordre supérieur ?

Une fonction d'ordre supérieur est une fonction qui prend une autre fonction comme argument ou retourne une fonction comme valeur de retour. Les fonctions d'ordre supérieur sont également connues sous le nom de fonctions de haut niveau ou de fonctions de deuxième ordre.

## Types de fonctions d'ordre supérieur

Il existe deux types de fonctions d'ordre supérieur :

### 1. Fonctions qui prennent une fonction comme argument
Le type à utiliser pour un argument de type *fonction* est `Action` ou `Func`.

#### Void: ACTION
 Ainsi une fonction l’ordre supérieur sans valeur de retour et avec un paramètre `int x` en entrée en C# correspond à ceci:

```csharp
void F(Action<int> x)
{
    x(1);
}
```

Si la fonction en paramètre n’a pas de paramètre:

```csharp
void F(Action x)
{
    x();
}
```

> On peut en déduire que les paramètres d’entrée sont spécifiés à l’intérieur des chevrons (*généricité...*) du type `Action` :
>
> Action`<`param1,param2,param3e...`>`

#### Exemple d’utilisation de `Action` pour afficher des messages

```csharp
Action<string> myAction = message => Console.WriteLine(message);
myAction("Bonjour"); // Affichera "Bonjour" dans la console
```

#### Avec valeur de retour: FUNC (ou delegate)
Si la fonction passée en paramètre retourne une valeur, on utilise le type `Func` et la valeur de retour correspond au dernier type indiqué entre les chevrons (dans l’exemple ci-dessous, `double`):

```csharp
void F(Func<int, int, double> x)
{
    var z = x(1, 2);
    Console.WriteLine(z);
}
```

> Derrière les décors, Action est une sorte de Func<...,void>

#### Avec valeur de retour pour la fonction de base et son paramètre:

```csharp
int F(Func<int, int, int> x)
{
    return x(1, 2);
}
```

#### Exemple d’utilisation de `Func` pour multiplier des nombres

```csharp
int x2(int x) { return x + x }
Func<int, int> myFunc = x2;
int result = myFunc(5); // Retourne 10
```


#### **Un fonction d’ordre supérieur en paramètre**

Pour terminer sur la définition d’une fonction d’ordre supérieur, il est à noter qu’elle peuvent se composer.

![Alt text](dogfood.jpg)

Il n’y a donc pas de limite avec les fonctions d’ordre supérieur qui peuvent avoir comme paramètre, une fonction d’ordre supérieur aussi:

```csharp
void FSuper(Action<Func<int, string>> a)
{
    a(Convert);
}

string Convert(int value)
{
    return $"{value}";
}
```

#### Exemple d’utilisation de `Func` pour créer une fonction qui retourne une fonction avec un `lambda`

```csharp
Func<int, Func<int, int>> myFunc = x => y => x + y;
int result = myFunc(5)(3); // Retourne 8
```

> Le lambda est expliqué ci-après

### Fonction anonyme
Une fonction peut être *déclarée à la volée* sans avoir de nom, on appelle cela un `lambda`. La définition d’un lambda utilise l’opérateur **=>** et on doit comprendre qu’à
- **gauche** de la flèche sont décrits les paramètres (signature)

et qu’à
- **droite** est décrit le comportement (corps).

#### Signature
Pour spéficier les arguments avec un lambda, il y a 3 cas principaux

**1. Pas d’argument**
```csharp
//Fonction qui n’a pas de paramètre et retourne la valeur 1
Func<int> one = () => 1;
```

> Ici les parenthèses sont obligatoires

**2. Argument non utilisé (underscore)**
```csharp
//Fonction avec un paramètre dont le lambda ne tient pas compte et retourne la valeur 2
Func<int,int> two = _ => 2;
```

**3. Argument utilisé**
```csharp
//Fonction avec un paramètre et retourne la valeur doublée
Func<int,int> x2 = x => x*2;
```

>À noter que les parenthèses des arguments sont optionnelles (sauf s’il n’y en a pas)

```csharp
//Fonction avec un paramètre et retourne la valeur doublée
Func<int,int> x2 = (x) => x*2;
```

### Action et lamdba combinés
La force du lambda est de le combiner avec le type action.

Voici donc un exemple de définition d’une `Action` avec un `lambda` (fonction anonyme) :
```csharp
Action<int> myAction = x => Console.WriteLine(x);
myAction(5); // Affichera "5" dans la console
```
Dans cet exemple, `myAction` est une fonction qui prend un entier comme argument et affiche ce nombre dans la console.

Si la fontion est complexe, le corps d’un lambda peut être écrit comme pour une fonction avec des `accolades` (sans oublier le point virgule à la fin):
```csharp
Action<int> myAction2 = x =>
{
    //Corps de fonction standard
    Console.WriteLine(x);
};
```

### Fonction nommée
On peut faire la même chose avec une fonction *standard* (pas anonyme):
```csharp
//Code de la classe
Action<int> myAction3 = PrintThis;

//Fonction définie dans une classe
void PrintThis(int x)
{
    Console.WriteLine(x);
}
```

## Autres Exemples
### Exemple A
Voici un exemple d'utilisation de `Action` avec LINQ pour filtrer une collection :
```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
Action<int> myAction = x => Console.WriteLine(x);
numbers.Where(myAction).ToList(); // Affichera les nombres impairs dans la console
```
Dans cet exemple, `myAction` est une fonction qui prend un entier comme argument et affiche ce nombre dans la console. La méthode `Where` de LINQ utilise cette fonction pour filtrer la collection `numbers` et afficher les nombres impairs.

### Exemple B
Voici un exemple d'utilisation de `Func` :
```csharp
Func<int, int> myFunc = x => x * 2;
int result = myFunc(5); // Retourne 10
```
Dans cet exemple, `myFunc` est une fonction qui prend un entier comme argument et retourne le double de ce nombre.

### Exemple C
Voici un exemple d'utilisation de `Func` avec LINQ pour filtrer une collection :
```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
Func<int, bool> myFunc = x => x % 2 == 0;
numbers.Where(myFunc).ToList(); // Retourne la liste des nombres pairs
```
Dans cet exemple, `myFunc` est une fonction qui prend un entier comme argument et retourne un booléen indiquant si le nombre est pair. La méthode `Where` de LINQ utilise cette fonction pour filtrer la collection `numbers` et retourner la liste des nombres pairs.

## Avantages des fonctions d'ordre supérieur

Les fonctions d'ordre supérieur offrent plusieurs avantages, notamment :

### 1. Flexibilité

Les fonctions d'ordre supérieur permettent de créer des fonctions plus génériques et plus flexibles. Vous pouvez passer des fonctions comme arguments pour les modifier ou les combiner.

### 2. Réutilisation

Les fonctions d'ordre supérieur permettent de réutiliser du code en passant des fonctions comme arguments. Vous pouvez créer des fonctions qui peuvent être utilisées avec différentes fonctions.

### 3. Simplification

Les fonctions d'ordre supérieur peuvent simplifier le code en permettant de regrouper des opérations complexes en une seule fonction.

## Exemples d'utilisation avec LINQ et lambda

#### 1. Utilisation de `Action` pour afficher des messages ()

```csharp
List<string> names = new List<string> { "John", "Mary", "Jane" };
Action<string> myAction = name => Console.WriteLine(name);
names.ForEach(myAction); // Affichera les noms dans la console
```
#### 2. Utilisation de `Func` pour filtrer une collection

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
Func<int, bool> isEven = x => x % 2 == 0;
Func<int, bool> isBig = x => x  > 2;
numbers.Where(isEven).ToList(); // Retourne la liste des nombres pairs (2,4)
numbers.Where(isBig).ToList();  // Retourne la liste des "grands" nombre (3,4,5)
```
On relèvera le fait que la méthode qui effectue l'action de filtrage est la même dans les deux cas: `Where`

## Conclusion

**Action** et **Func** sont donc 2 nouveaux *types* à connaître et maîtriser en C# afin de tirer le maximum de la programmation fonctionnelle et de comprendre ses mécanismes sous-jacents.

La notion de fonction anonyme nomée `lambda` avec son opérateur `=>` est aussi un élément clé de l’integration de la programmation fonctionnelle avec C#.

De manière générale, les fonctions d'ordre supérieur sont un concept important en programmation qui peut sembler complexe au début, mais qui offre de nombreux avantages. En comprenant les fonctions d'ordre supérieur, vous pouvez créer des programmes plus flexibles, plus réutilisables et plus simples.

## *Source*

Inspiré de [groq ai inference](https://groq.com/) avec le prompt suivant :
```text
théorie sur les fonctions d’ordre supérieur pour des débutants en programmation Csharp en markdown et avec maximum 500 mots
```