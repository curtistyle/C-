### M�s sobre Variables Locales de Tipo Impl�cito

Las variables locales de tipo impl�cito tambi�n pueden usarse para inicializar una variable de array mediante una lista de inicializadores. En la siguiente declaraci�n, el tipo de `values` se infiere como `int[]`:

```csharp
var values = new[] {32, 27, 64, 18, 95, 14, 90, 70, 60, 37};
```

`new[]` especifica que la lista de inicializadores es para un array. El tipo de elemento del array, `int`, se infiere a partir de los inicializadores. La siguiente declaraci�n, en la que `values` se inicializa directamente sin `new[]`, genera un error de compilaci�n:

```csharp
var values = {32, 27, 64, 18, 95, 14, 90, 70, 60, 37};
```

Error de Programaci�n Com�n 8.6

Las listas de inicializadores pueden usarse tanto con arrays como con colecciones. Si una variable local de tipo impl�cito se inicializa mediante una lista de inicializadores sin `new[]`, se produce un error de compilaci�n, porque el compilador no puede inferir si la variable deber�a ser un array o una colecci�n. Utilizamos una colecci�n de tipo List en el Cap�tulo 9 y cubrimos las colecciones en detalle en el Cap�tulo 19.