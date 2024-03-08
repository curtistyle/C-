### Más sobre Variables Locales de Tipo Implícito

Las variables locales de tipo implícito también pueden usarse para inicializar una variable de array mediante una lista de inicializadores. En la siguiente declaración, el tipo de `values` se infiere como `int[]`:

```csharp
var values = new[] {32, 27, 64, 18, 95, 14, 90, 70, 60, 37};
```

`new[]` especifica que la lista de inicializadores es para un array. El tipo de elemento del array, `int`, se infiere a partir de los inicializadores. La siguiente declaración, en la que `values` se inicializa directamente sin `new[]`, genera un error de compilación:

```csharp
var values = {32, 27, 64, 18, 95, 14, 90, 70, 60, 37};
```

Error de Programación Común 8.6

Las listas de inicializadores pueden usarse tanto con arrays como con colecciones. Si una variable local de tipo implícito se inicializa mediante una lista de inicializadores sin `new[]`, se produce un error de compilación, porque el compilador no puede inferir si la variable debería ser un array o una colección. Utilizamos una colección de tipo List en el Capítulo 9 y cubrimos las colecciones en detalle en el Capítulo 19.