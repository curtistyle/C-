# Genericos

### Desventajas de las Estructuras de Datos Basadas en Objetos
Puedes almacenar cualquier objeto en nuestras estructuras de datos. Un aspecto inconveniente de almacenar referencias de objetos ocurre al recuperarlos de una colección. Normalmente, una aplicación necesita procesar tipos específicos de objetos. Como resultado, las referencias de objetos obtenidas de una colección generalmente necesitan ser convertidas a un tipo apropiado para permitir que la aplicación procese los objetos correctamente. Además, los datos de tipos de valor (por ejemplo, `int` y `double`) deben ser "**boxed**" para ser manipulados con referencias de objeto, lo que aumenta el costo de procesar dichos datos. Lo más importante, procesar todos los datos como tipo objeto limita la capacidad del compilador de C# para realizar la verificación de tipos.

### Seguridad de tipo en tiempo de compilación
Aunque podemos crear fácilmente estructuras de datos que manipulen cualquier tipo de datos como objetos, sería bueno si pudiéramos detectar incompatibilidades de tipos en tiempo de compilación; esto se conoce como seguridad de tipo en tiempo de compilación (*compile-time type safety*). Por ejemplo, si una pila solo debería almacenar valores `int`, intentar agregar una cadena a esa pila debería causar un error en tiempo de compilación. De manera similar, un método de ordenamiento debería poder comparar elementos que se garantice que tienen el mismo tipo.
Si creamos versiones específicas de tipos de la clase `Stack` y del método `Sort`, el compilador de C# ciertamente podría garantizar la seguridad de tipo en tiempo de compilación. Sin embargo, esto requeriría que creáramos muchas copias del mismo código básico.

### Genéricos
Este capítulo trata sobre los genéricos, que proporcionan los medios para crear los modelos generales mencionados anteriormente. Los métodos genéricos te permiten especificar, con una sola declaración de método, un conjunto de métodos relacionados. Las clases genéricas te permiten especificar, con una sola declaración de clase, un conjunto de clases relacionadas. De manera similar, las interfaces genéricas te permiten especificar, con una sola declaración de interfaz, un conjunto de interfaces relacionadas. Los genéricos proporcionan seguridad de tipo en tiempo de compilación. [Nota: También puedes implementar estructuras y delegados genéricos.] Hasta ahora en este libro, hemos utilizado los tipos genéricos `List` y `Dictionary`.

Podemos escribir un método genérico para ordenar un `array`, luego invocar el método genérico por separado con un array de `int`s, un array de `double`s, un array de `string`'s, etc., para ordenar cada tipo diferente de `array`. El compilador realiza la comprobación de tipos para asegurar que el `array` pasado al método de ordenamiento contenga solo elementos del tipo correcto. Podemos escribir una única clase genérica `Stack`, luego instanciar objetos `Stack` para una pila de enteros, una pila de dobles, una pila de cadenas, etc. El compilador realiza la comprobación de tipos para asegurar que la `Stack` almacene solo elementos del tipo correcto.

Este capítulo presenta ejemplos de métodos genéricos y clases genéricas. El Capítulo 19, Colecciones Genéricas; Programación Funcional con LINQ/PLINQ, discute las clases de colecciones genéricas del Framework .NET. Una colección es una estructura de datos que mantiene un grupo de objetos o valores relacionados. Las clases de colecciones del Framework .NET utilizan genéricos para permitirte especificar los tipos exactos de objeto que una colección particular almacenará.

## 18.2 Motivación para Métodos Genéricos
Los métodos sobrecargados se utilizan frecuentemente para realizar operaciones similares en diferentes tipos de datos. Para comprender la motivación para los métodos genéricos, comencemos con un ejemplo (Cod. 18.1) que contiene tres métodos `DisplayArray` sobrecargados (overload) (líneas 23–31, líneas 34–42 y líneas 45–53). Estos métodos muestran los elementos de un array de `int`s, un array de `double`s y un array de `string`s, respectivamente. Pronto, reimplementaremos este programa de manera más concisa y elegante utilizando un único método genérico.

El programa comienza declarando e inicializando tres arreglos: un arreglo de enteros de seis elementos llamado `intArray` (línea 10), un arreglo de dobles de siete elementos llamado `doubleArray` (línea 11) y un arreglo de caracteres de cinco elementos llamado `charArray` (línea 12). Luego, las líneas 14–19 muestran los arreglos.

Cuando el compilador encuentra una llamada a un método, intenta localizar una declaración de método que tenga el mismo nombre de método y parámetros que coincidan con los tipos de argumentos en la llamada al método. En este ejemplo, cada llamada a `DisplayArray` coincide exactamente con una de las declaraciones del método `DisplayArray`. Por ejemplo, la línea 15 llama a `DisplayArray` con `intArray` como su argumento. En tiempo de compilación, el compilador determina el tipo del argumento `intArray` (es decir, int[]), intenta localizar un método llamado `DisplayArray` que especifique un único parámetro `int[]` (lo encuentra en las líneas 23–31) y configura una llamada a ese método. De manera similar, cuando el compilador encuentra la llamada a `DisplayArray` en la línea 17, determina el tipo del argumento `doubleArray` (es decir, `double[]`), luego intenta localizar un método llamado `DisplayArray` que especifique un único parámetro `double[]` (lo encuentra en las líneas 34–42) y configura una llamada a ese método. Finalmente, cuando el compilador encuentra la llamada a DisplayArray en la línea 19, determina el tipo del argumento `charArray` (es decir, `char[]`), luego intenta localizar un método llamado `DisplayArray` que especifique un único parámetro `char[]` (lo encuentra en las líneas 45–53) y configura una llamada a ese método.

Observa que el tipo de elemento del arreglo (`int`, `double` o `char`) aparece en una ubicación en cada método: en el encabezado del método (líneas 23, 34 y 45). Cada encabezado de la instrucción `foreach` (líneas 25, 36 y 47) utiliza `var` para inferir el tipo de elemento del parámetro del método. Si reemplazáramos los tipos de elementos en el encabezado de cada método con un nombre genérico (como T para "tipo"), entonces los tres métodos se verían como el de la Figura 18.2. 

#### Figura 18.2
```Csharp
private static void DisplayArray(T[] inputArray)
{
	foreach (var element in inputArray)
	{
		Console.WriteLine($"{element} ");
	}

	Console.WriteLine();
}
```

Parece que si pudiéramos reemplazar el tipo de elemento del arreglo en cada uno de los tres métodos con un solo "parámetro de tipo genérico", entonces deberíamos poder declarar un método `DisplayArray` que pueda mostrar los elementos de cualquier arreglo. El método en la  18.2 no se compilará, porque su sintaxis no es correcta. Declaramos un método genérico `DisplayArray` con la sintaxis adecuada en el Cod 18.3.

## Implementación de Método Genérico

Si las operaciones realizadas por varios métodos sobrecargados (**overloaded**) son idénticas para cada tipo de argumento, los métodos sobrecargados pueden codificarse de manera más compacta y conveniente utilizando un método genérico. Puedes escribir una única declaración de método genérico que puede ser llamada en diferentes momentos con argumentos de diferentes tipos. Basado en los tipos de los argumentos pasados al método genérico, el compilador maneja cada llamada al método apropiadamente.

El Codigo 18.3 reimplementa la aplicación del Codigo 18.1 usando un método `DisplayArray` genérico (líneas 24–32). Observa que las llamadas al método `DisplayArray` en las líneas 15, 17 y 19 son idénticas a las del codigo 18.1, las salidas de las dos aplicaciones son idénticas y el código 18.3 tiene 22 líneas menos que en el codigo 18.1. Como se escribio en el codigo 18.3, los genéricos nos permiten crear y probar nuestro código una vez, luego reutilizarlo para muchos tipos diferentes de datos. Esto demuestra efectivamente el poder expresivo de los genéricos.

La línea 23 comienza la declaración del método `DisplayArray`, que es `static` para que `Main` pueda llamar a `DisplayArray`. Todas las declaraciones de métodos genéricos tienen una lista de parámetros de tipo delimitada por corchetes angulares (<T> en este ejemplo) que sigue el nombre del método. Cada lista de parámetros de tipo contiene uno o más **parámetros de tipo**, separados por comas (por ejemplo, Dictionary<K, V>). Un parámetro de tipo es un identificador que se utiliza en lugar de nombres de tipo reales. Los parámetros de tipo se pueden usar para declarar el tipo de retorno, los tipos de parámetros y los tipos de variables locales en la declaración de un método genérico; los parámetros de tipo actúan como marcadores de posición para los argumentos de tipo que representan los tipos de datos que se pasarán al método genérico.

Los nombres de los parámetros de tipo a lo largo de la declaración del método (si los hay) deben coincidir con los declarados en la lista de parámetros de tipo. Además, un parámetro de tipo solo puede declararse una vez en la lista de parámetros de tipo, pero puede aparecer más de una vez en la lista de parámetros del método. Los nombres de los parámetros de tipo no necesitan ser únicos entre métodos genéricos separados.

La lista de parámetros de tipo del método `DisplayArray` (línea 23) declara el parámetro de tipo `T` como el marcador de posición para el tipo de elemento del arreglo que `DisplayArray` producirá. Observa que `T` aparece en la lista de parámetros como el tipo de elemento del arreglo (línea 23). Este es el mismo lugar donde los métodos sobrecargados `DisplayArray` de la Codigo 18.1 especificaban `int`, `double` o `char` como el tipo de elemento. El resto de `DisplayArray` es idéntico a la versión presentada en la Codigo 18.1. En este ejemplo, la instrucción `foreach` infiere el tipo de elemento del tipo de arreglo pasado al método.

Al igual que en la Codigo 18.1, el programa 18.3 comienza declarando e inicializando un arreglo de enteros de seis elementos `intArray` (línea 10), un arreglo de dobles de siete elementos `doubleArray` (línea 11) y un arreglo de caracteres de cinco elementos `charArray` (línea 12). Luego, cada arreglo es mostrado llamando a `DisplayArray` (líneas 15, 17 y 19), una vez con `intArray`, una vez con `doubleArray` y una vez con `charArray` como argumentos.

Cuando el compilador encuentra una llamada a un método como la línea 15, analiza el conjunto de métodos (tanto genéricos como no genéricos) que podrían coincidir con la llamada al método, buscando un método que coincida mejor con la llamada. Si no hay ningún método coincidente, o si hay más de una coincidencia mejor, el compilador genera un error.

En el caso de la línea 15, el compilador determina que la mejor coincidencia ocurre si el parámetro de tipo T en la línea 23 de la declaración del método `DisplayArray` se reemplaza con el tipo de los elementos en el argumento de la llamada al método `intArray` (es decir, `int`). Luego, el compilador configura una llamada a `DisplayArray` con `int` como el argumento de tipo para el parámetro de tipo T. Esto se conoce como el proceso de inferencia de tipos (*the type-inferencing process*). El mismo proceso se repite para las llamadas al método `DisplayArray` en las líneas 17 y 19.

Para cada variable declarada con un parámetro de tipo, el compilador verifica si las operaciones realizadas en la variable están permitidas para todos los tipos que el parámetro de tipo puede asumir. Por defecto, un parámetro de tipo puede asumir cualquier tipo, pero mostraremos en la Sección 18.4 que puedes restringir esto a tipos específicos. La única operación realizada en cada elemento del arreglo en este ejemplo es mostrar su representación como cadena. La línea 27 realiza una llamada implícita a `ToString` en el elemento actual del arreglo. Dado que todos los objetos tienen un método `ToString`, el compilador está satisfecho de que la línea 27 realiza una operación válida para cualquier elemento del arreglo. 

Al declarar `DisplayArray` como un método genérico en la Codigo 18.3, eliminamos la necesidad de los métodos sobrecargados del Codigo 18.1, ahorrando 22 líneas de código y creando un método reutilizable que puede mostrar las representaciones como cadena de los elementos en cualquier arreglo unidimensional, no solo arreglos de elementos int, double o char.

### Tipos de Valor vs. Tipos de Referencia en Genéricos
El compilador maneja los tipos de valor y los tipos de referencia de manera diferente en las llamadas a métodos genéricos. Cuando se utiliza un argumento de tipo de valor para un parámetro de tipo dado, el compilador genera una versión del método que es específica para el tipo de valor; si se ha generado una previamente, el compilador la reutiliza. Por lo tanto, en la Codigo 18.3, el compilador genera tres versiones del método `DisplayArray`, una para cada uno de los tipos `int`, `double` y `char`. Si `DisplayArray` se llamara con un tipo de referencia, el compilador también generaría una única versión del método que sería utilizada por todos los tipos de referencia.

### Argumentos de Tipo Explícitos
También puedes usar argumentos de tipo explícitos para indicar el tipo exacto que debe utilizarse para llamar a una función genérica. Por ejemplo, la línea 15 podría escribirse como:

```Csharp

	DisplayArray<int>(intArray); // pasar un argumento de tipo int array

```
	

La llamada al método precedente proporciona explícitamente el argumento de tipo (`int`) que debe utilizarse para reemplazar el parámetro de tipo `T` en la línea 23. Aunque no es necesario aquí, un argumento de tipo explícito sería requerido si el compilador no puede inferir el tipo a partir del argumento(s) del método.

