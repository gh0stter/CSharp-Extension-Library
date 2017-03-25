# CSharp Extension Library
A C# .Net Standard extension library.
Currently it provides extension methods for the following types:

* System.String
* System.Array 
* System.Collections.Generic.IEnumerable

This is a .Net Standard 1.6 library and covered with unit tests

## System.String extensions

#### Slice(int32, int32)
Retrieves a slice from this instance. The substring starts at a specifiedcharacter position and continues to the specified ending index. This inclusive for start index, exclusive for end index.

Example:
```csharp
"123456".Slice(0, 2);
"123456".Slice(0, -2);
```

#### Right(int32)
Retrieves a slice from this instance. The substring starts at the right and take the length of characters of a string.

Example:
```csharp
"0987654321".Right(3);
```

#### RemoveLabel(System.String)
Retrieves a slice from this instance. The substring excluding exclusionLabel

Usage:
```csharp
"Foo Bar".RemoveLabel("Bar");
```

## System.Array extensions

#### JoinArrays()
Join multiple arrays and retuen a new array with elements from all arrays.

Example:
```csharp
var a1 = new[] { 1, 2, 3 };
var a2 = new[] { 4, 5, 6 };
var a3 = new[] { 7, 8, 9 };
new[] { a1, a2, a3 }.JoinArrays();
```

#### JoinArrays(T[][])
Join multiple arrays and retuen a new array with elements from all arrays.

Example:
```csharp
var a1 = new[] { 1, 2, 3 };
var a2 = new[] { 4, 5, 6 };
var a3 = new[] { 7, 8, 9 };
a1.JoinArrays(a2, a3);
```

## System.Collections.Generic.IEnumerable extension

#### Shuffle()
Shuffling an sequence, randomizes its element order. It is using Fisher-Yates Shuffle algorithm.

Example:
```csharp
Enumerable.Range(1, 20).Shuffle();
```

## [.NET Platforms Support](https://docs.microsoft.com/en-us/dotnet/articles/standard/library ".NET Platforms Support")
You can see the complete set of .NET runtimes that support the .NET Standard Library.

| Platform Name              | Alias       | 1.0 | 1.1 | 1.2   | 1.3 | 1.4   | 1.5   | 1.6   | 2.0   |
|----------------------------|-------------|-----|-----|-------|-----|-------|-------|-------|-------|
| .NET Standard              | netstandard | →   | →   | →     | →   | →     | →     | 1.0   | 2.0   |
| .NET Core                  | netcoreapp  | →   | 4.5 | 4.5.1 | 4.6 | 4.6.4 | 4.6.2 | vNext | 4.6.1 |
| .NET Framework             | net         | →   | →   | →     | →   | →     | →     | →     | vNext |
| Mono/Xamarin Platforms     |             | →   | →   | →     | →   | →     | →     | →     | vNext |
| Universal Windows Platform | uap         | →   | →   | →     | →   | 10.0  | →     | →     | vNext |