# Genericos

### Desventajas de las Estructuras de Datos Basadas en Objetos
Puedes almacenar cualquier objeto en nuestras estructuras de datos. Un aspecto inconveniente de almacenar referencias de objetos ocurre al recuperarlos de una colecci�n. Normalmente, una aplicaci�n necesita procesar tipos espec�ficos de objetos. Como resultado, las referencias de objetos obtenidas de una colecci�n generalmente necesitan ser convertidas a un tipo apropiado para permitir que la aplicaci�n procese los objetos correctamente. Adem�s, los datos de tipos de valor (por ejemplo, `int` y `double`) deben ser "**boxed**" para ser manipulados con referencias de objeto, lo que aumenta el costo de procesar dichos datos. Lo m�s importante, procesar todos los datos como tipo objeto limita la capacidad del compilador de C# para realizar la verificaci�n de tipos.

### Seguridad de tipo en tiempo de compilaci�n
Aunque podemos crear f�cilmente estructuras de datos que manipulen cualquier tipo de datos como objetos, ser�a bueno si pudi�ramos detectar incompatibilidades de tipos en tiempo de compilaci�n; esto se conoce como seguridad de tipo en tiempo de compilaci�n (*compile-time type safety*). Por ejemplo, si una pila solo deber�a almacenar valores `int`, intentar agregar una cadena a esa pila deber�a causar un error en tiempo de compilaci�n. De manera similar, un m�todo de ordenamiento deber�a poder comparar elementos que se garantice que tienen el mismo tipo.
Si creamos versiones espec�ficas de tipos de la clase `Stack` y del m�todo `Sort`, el compilador de C# ciertamente podr�a garantizar la seguridad de tipo en tiempo de compilaci�n. Sin embargo, esto requerir�a que cre�ramos muchas copias del mismo c�digo b�sico.

### Gen�ricos
Este cap�tulo trata sobre los gen�ricos, que proporcionan los medios para crear los modelos generales mencionados anteriormente. Los m�todos gen�ricos te permiten especificar, con una sola declaraci�n de m�todo, un conjunto de m�todos relacionados. Las clases gen�ricas te permiten especificar, con una sola declaraci�n de clase, un conjunto de clases relacionadas. De manera similar, las interfaces gen�ricas te permiten especificar, con una sola declaraci�n de interfaz, un conjunto de interfaces relacionadas. Los gen�ricos proporcionan seguridad de tipo en tiempo de compilaci�n. [Nota: Tambi�n puedes implementar estructuras y delegados gen�ricos.] Hasta ahora en este libro, hemos utilizado los tipos gen�ricos `List` y `Dictionary`.

Podemos escribir un m�todo gen�rico para ordenar un `array`, luego invocar el m�todo gen�rico por separado con un array de `int`s, un array de `double`s, un array de `string`'s, etc., para ordenar cada tipo diferente de `array`. El compilador realiza la comprobaci�n de tipos para asegurar que el `array` pasado al m�todo de ordenamiento contenga solo elementos del tipo correcto. Podemos escribir una �nica clase gen�rica `Stack`, luego instanciar objetos `Stack` para una pila de enteros, una pila de dobles, una pila de cadenas, etc. El compilador realiza la comprobaci�n de tipos para asegurar que la `Stack` almacene solo elementos del tipo correcto.

Este cap�tulo presenta ejemplos de m�todos gen�ricos y clases gen�ricas. El Cap�tulo 19, Colecciones Gen�ricas; Programaci�n Funcional con LINQ/PLINQ, discute las clases de colecciones gen�ricas del Framework .NET. Una colecci�n es una estructura de datos que mantiene un grupo de objetos o valores relacionados. Las clases de colecciones del Framework .NET utilizan gen�ricos para permitirte especificar los tipos exactos de objeto que una colecci�n particular almacenar�.

## 18.2 Motivaci�n para M�todos Gen�ricos
Los m�todos sobrecargados se utilizan frecuentemente para realizar operaciones similares en diferentes tipos de datos. Para comprender la motivaci�n para los m�todos gen�ricos, comencemos con un ejemplo (Cod. 18.1) que contiene tres m�todos `DisplayArray` sobrecargados (overload) (l�neas 23�31, l�neas 34�42 y l�neas 45�53). Estos m�todos muestran los elementos de un array de `int`s, un array de `double`s y un array de `string`s, respectivamente. Pronto, reimplementaremos este programa de manera m�s concisa y elegante utilizando un �nico m�todo gen�rico.

El programa comienza declarando e inicializando tres arreglos: un arreglo de enteros de seis elementos llamado `intArray` (l�nea 10), un arreglo de dobles de siete elementos llamado `doubleArray` (l�nea 11) y un arreglo de caracteres de cinco elementos llamado `charArray` (l�nea 12). Luego, las l�neas 14�19 muestran los arreglos.

Cuando el compilador encuentra una llamada a un m�todo, intenta localizar una declaraci�n de m�todo que tenga el mismo nombre de m�todo y par�metros que coincidan con los tipos de argumentos en la llamada al m�todo. En este ejemplo, cada llamada a `DisplayArray` coincide exactamente con una de las declaraciones del m�todo `DisplayArray`. Por ejemplo, la l�nea 15 llama a `DisplayArray` con `intArray` como su argumento. En tiempo de compilaci�n, el compilador determina el tipo del argumento `intArray` (es decir, int[]), intenta localizar un m�todo llamado `DisplayArray` que especifique un �nico par�metro `int[]` (lo encuentra en las l�neas 23�31) y configura una llamada a ese m�todo. De manera similar, cuando el compilador encuentra la llamada a `DisplayArray` en la l�nea 17, determina el tipo del argumento `doubleArray` (es decir, `double[]`), luego intenta localizar un m�todo llamado `DisplayArray` que especifique un �nico par�metro `double[]` (lo encuentra en las l�neas 34�42) y configura una llamada a ese m�todo. Finalmente, cuando el compilador encuentra la llamada a DisplayArray en la l�nea 19, determina el tipo del argumento `charArray` (es decir, `char[]`), luego intenta localizar un m�todo llamado `DisplayArray` que especifique un �nico par�metro `char[]` (lo encuentra en las l�neas 45�53) y configura una llamada a ese m�todo.

Observa que el tipo de elemento del arreglo (`int`, `double` o `char`) aparece en una ubicaci�n en cada m�todo: en el encabezado del m�todo (l�neas 23, 34 y 45). Cada encabezado de la instrucci�n `foreach` (l�neas 25, 36 y 47) utiliza `var` para inferir el tipo de elemento del par�metro del m�todo. Si reemplaz�ramos los tipos de elementos en el encabezado de cada m�todo con un nombre gen�rico (como T para "tipo"), entonces los tres m�todos se ver�an como el de la Figura 18.2. 

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

Parece que si pudi�ramos reemplazar el tipo de elemento del arreglo en cada uno de los tres m�todos con un solo "par�metro de tipo gen�rico", entonces deber�amos poder declarar un m�todo `DisplayArray` que pueda mostrar los elementos de cualquier arreglo. El m�todo en la  18.2 no se compilar�, porque su sintaxis no es correcta. Declaramos un m�todo gen�rico `DisplayArray` con la sintaxis adecuada en el Cod 18.3.

## Implementaci�n de M�todo Gen�rico

Si las operaciones realizadas por varios m�todos sobrecargados (**overloaded**) son id�nticas para cada tipo de argumento, los m�todos sobrecargados pueden codificarse de manera m�s compacta y conveniente utilizando un m�todo gen�rico. Puedes escribir una �nica declaraci�n de m�todo gen�rico que puede ser llamada en diferentes momentos con argumentos de diferentes tipos. Basado en los tipos de los argumentos pasados al m�todo gen�rico, el compilador maneja cada llamada al m�todo apropiadamente.

El Codigo 18.3 reimplementa la aplicaci�n del Codigo 18.1 usando un m�todo `DisplayArray` gen�rico (l�neas 24�32). Observa que las llamadas al m�todo `DisplayArray` en las l�neas 15, 17 y 19 son id�nticas a las del codigo 18.1, las salidas de las dos aplicaciones son id�nticas y el c�digo 18.3 tiene 22 l�neas menos que en el codigo 18.1. Como se escribio en el codigo 18.3, los gen�ricos nos permiten crear y probar nuestro c�digo una vez, luego reutilizarlo para muchos tipos diferentes de datos. Esto demuestra efectivamente el poder expresivo de los gen�ricos.

La l�nea 23 comienza la declaraci�n del m�todo `DisplayArray`, que es `static` para que `Main` pueda llamar a `DisplayArray`. Todas las declaraciones de m�todos gen�ricos tienen una lista de par�metros de tipo delimitada por corchetes angulares (<T> en este ejemplo) que sigue el nombre del m�todo. Cada lista de par�metros de tipo contiene uno o m�s **par�metros de tipo**, separados por comas (por ejemplo, Dictionary<K, V>). Un par�metro de tipo es un identificador que se utiliza en lugar de nombres de tipo reales. Los par�metros de tipo se pueden usar para declarar el tipo de retorno, los tipos de par�metros y los tipos de variables locales en la declaraci�n de un m�todo gen�rico; los par�metros de tipo act�an como marcadores de posici�n para los argumentos de tipo que representan los tipos de datos que se pasar�n al m�todo gen�rico.

Los nombres de los par�metros de tipo a lo largo de la declaraci�n del m�todo (si los hay) deben coincidir con los declarados en la lista de par�metros de tipo. Adem�s, un par�metro de tipo solo puede declararse una vez en la lista de par�metros de tipo, pero puede aparecer m�s de una vez en la lista de par�metros del m�todo. Los nombres de los par�metros de tipo no necesitan ser �nicos entre m�todos gen�ricos separados.

La lista de par�metros de tipo del m�todo `DisplayArray` (l�nea 23) declara el par�metro de tipo `T` como el marcador de posici�n para el tipo de elemento del arreglo que `DisplayArray` producir�. Observa que `T` aparece en la lista de par�metros como el tipo de elemento del arreglo (l�nea 23). Este es el mismo lugar donde los m�todos sobrecargados `DisplayArray` de la Codigo 18.1 especificaban `int`, `double` o `char` como el tipo de elemento. El resto de `DisplayArray` es id�ntico a la versi�n presentada en la Codigo 18.1. En este ejemplo, la instrucci�n `foreach` infiere el tipo de elemento del tipo de arreglo pasado al m�todo.

Al igual que en la Codigo 18.1, el programa 18.3 comienza declarando e inicializando un arreglo de enteros de seis elementos `intArray` (l�nea 10), un arreglo de dobles de siete elementos `doubleArray` (l�nea 11) y un arreglo de caracteres de cinco elementos `charArray` (l�nea 12). Luego, cada arreglo es mostrado llamando a `DisplayArray` (l�neas 15, 17 y 19), una vez con `intArray`, una vez con `doubleArray` y una vez con `charArray` como argumentos.

Cuando el compilador encuentra una llamada a un m�todo como la l�nea 15, analiza el conjunto de m�todos (tanto gen�ricos como no gen�ricos) que podr�an coincidir con la llamada al m�todo, buscando un m�todo que coincida mejor con la llamada. Si no hay ning�n m�todo coincidente, o si hay m�s de una coincidencia mejor, el compilador genera un error.

En el caso de la l�nea 15, el compilador determina que la mejor coincidencia ocurre si el par�metro de tipo T en la l�nea 23 de la declaraci�n del m�todo `DisplayArray` se reemplaza con el tipo de los elementos en el argumento de la llamada al m�todo `intArray` (es decir, `int`). Luego, el compilador configura una llamada a `DisplayArray` con `int` como el argumento de tipo para el par�metro de tipo T. Esto se conoce como el proceso de inferencia de tipos (*the type-inferencing process*). El mismo proceso se repite para las llamadas al m�todo `DisplayArray` en las l�neas 17 y 19.

Para cada variable declarada con un par�metro de tipo, el compilador verifica si las operaciones realizadas en la variable est�n permitidas para todos los tipos que el par�metro de tipo puede asumir. Por defecto, un par�metro de tipo puede asumir cualquier tipo, pero mostraremos en la Secci�n 18.4 que puedes restringir esto a tipos espec�ficos. La �nica operaci�n realizada en cada elemento del arreglo en este ejemplo es mostrar su representaci�n como cadena. La l�nea 27 realiza una llamada impl�cita a `ToString` en el elemento actual del arreglo. Dado que todos los objetos tienen un m�todo `ToString`, el compilador est� satisfecho de que la l�nea 27 realiza una operaci�n v�lida para cualquier elemento del arreglo. 

Al declarar `DisplayArray` como un m�todo gen�rico en la Codigo 18.3, eliminamos la necesidad de los m�todos sobrecargados del Codigo 18.1, ahorrando 22 l�neas de c�digo y creando un m�todo reutilizable que puede mostrar las representaciones como cadena de los elementos en cualquier arreglo unidimensional, no solo arreglos de elementos int, double o char.

### Tipos de Valor vs. Tipos de Referencia en Gen�ricos
El compilador maneja los tipos de valor y los tipos de referencia de manera diferente en las llamadas a m�todos gen�ricos. Cuando se utiliza un argumento de tipo de valor para un par�metro de tipo dado, el compilador genera una versi�n del m�todo que es espec�fica para el tipo de valor; si se ha generado una previamente, el compilador la reutiliza. Por lo tanto, en la Codigo 18.3, el compilador genera tres versiones del m�todo `DisplayArray`, una para cada uno de los tipos `int`, `double` y `char`. Si `DisplayArray` se llamara con un tipo de referencia, el compilador tambi�n generar�a una �nica versi�n del m�todo que ser�a utilizada por todos los tipos de referencia.

### Argumentos de Tipo Expl�citos
Tambi�n puedes usar argumentos de tipo expl�citos para indicar el tipo exacto que debe utilizarse para llamar a una funci�n gen�rica. Por ejemplo, la l�nea 15 podr�a escribirse como:

```Csharp

	DisplayArray<int>(intArray); // pasar un argumento de tipo int array

```
	

La llamada al m�todo precedente proporciona expl�citamente el argumento de tipo (`int`) que debe utilizarse para reemplazar el par�metro de tipo `T` en la l�nea 23. Aunque no es necesario aqu�, un argumento de tipo expl�cito ser�a requerido si el compilador no puede inferir el tipo a partir del argumento(s) del m�todo.

