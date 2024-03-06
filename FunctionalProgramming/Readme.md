## 19.10 Introducción a la Programación Funcional
Hasta ahora, has visto técnicas de programación estructurada, orientada a objetos y genérica en C#. Aunque a menudo usaste clases e interfaces del marco de trabajo .NET para realizar diversas tareas, típicamente determinaste lo que querías lograr en una tarea, luego especificaste precisamente cómo lograrlo.

Por ejemplo, supongamos que lo que te gustaría lograr es sumar los elementos de un array de enteros llamado valores (la fuente de datos). Podrías usar el siguiente código:

```csharp
var suma = 0;
for (var contador = 0; contador < valores.Length; ++contador)
{
    suma += valores[contador];
}
```

Este bucle especifica precisamente cómo agregar el valor de cada elemento del array a la suma, con una declaración de iteración `for` que procesa cada elemento uno a la vez, agregando su valor a la suma. Esta técnica se conoce como iteración externa, porque especificas cómo iterar, no la biblioteca, y requiere que accedas a los elementos secuencialmente desde el principio hasta el final en un único hilo de ejecución. Para realizar la tarea anterior, también creas dos variables (`suma` y `contador`) que se mutan repetidamente: sus valores cambian a medida que se realiza la iteración. Realizaste muchas tareas similares con arrays y colecciones, como mostrar los elementos de un array, resumir las caras de un dado que se lanzó 60,000,000 veces, calcular el promedio de los elementos de un array y más.

#### La Iteración Externa Es Propensa a Errores
El problema con la iteración externa es que incluso en este bucle simple, hay muchas oportunidades para cometer errores. Por ejemplo, podrías:
    - inicializar incorrectamente la variable `suma`,
    - inicializar incorrectamente la variable de control `contador`,
    - usar una condición de continuación de bucle incorrecta,
    - incrementar incorrectamente la variable de control contador o
    - sumar incorrectamente cada valor en el array a la `suma`.

#### Iteración Interna
**En la programación funcional, especificas lo que quieres lograr en una tarea, pero no cómo lograrlo.** Como verás, para sumar los elementos de una fuente de datos numéricos (como los de un array o una colección), puedes usar las capacidades de LINQ que te permiten decir: "Aquí tienes una fuente de datos, dame la suma de sus elementos". No necesitas especificar cómo iterar a través de los elementos ni declarar ni usar variables mutables (es decir, modificables). Esto se conoce como **iteración interna**, porque el código de la biblioteca (por detrás) itera a través de todos los elementos para realizar la tarea.

> *Los desarrolladores de sistemas han estado familiarizados con la distinción entre "qué vs. cómo" durante décadas. Comienzan un esfuerzo de desarrollo de sistemas definiendo un documento de requisitos que especifica qué se supone que debe hacer el sistema. Luego, utilizan herramientas, como UML, para diseñar el sistema, lo que especifica cómo debe construirse el sistema para cumplir con los requisitos. En los capítulos en línea, construimos el software para un cajero automático muy simple. Comenzamos con un documento de requisitos que especifica qué se supone que debe hacer el software, luego usamos UML para especificar cómo el software debe hacerlo. Especificamos los detalles finales de cómo escribiendo el código C# real.*

Un aspecto clave de la programación funcional es la inmutabilidad, es decir, *no modificar la fuente de datos que se está procesando ni ningún otro estado del programa*, como variables de control de contador en bucles. Al utilizar la iteración interna, eliminas de tus programas errores comunes que son causados por modificar datos incorrectamente. Esto facilita la escritura de código correcto.

#### Filtrar, Mapear y Reducir
Tres operaciones comunes de programación funcional que realizarás en colecciones de datos son **filtrar** (*Filter*), **mapear** (*Map*) y **reducir** (*reduce*):

- Una operación de **filter** resulta en una nueva colección que contiene solo los elementos que satisfacen una condición. Por ejemplo, podrías filtrar una colección de enteros para localizar solo los enteros pares, o podrías filtrar una colección de empleados para localizar personas en un departamento específico de una gran empresa. Las operaciones de filtro no modifican la colección original.

- Una operación de **map** resulta en una nueva colección en la que cada elemento de la colección original se asigna a un nuevo valor (posiblemente de un tipo diferente), por ejemplo, asignando valores numéricos a los cuadrados de los valores numéricos. La nueva colección tiene el mismo número de elementos que la colección que fue asignada. Las operaciones de mapeo no modifican la colección original.

- Una operación de **reduce** combina los elementos de una colección en un nuevo valor único, típicamente utilizando un lambda que especifica cómo combinar los elementos. Por ejemplo, podrías reducir una colección de calificaciones de exámenes de enteros de cero a 100 al número de estudiantes que aprobaron con una calificación mayor o igual a 60. Las operaciones de reducción no modifican la colección original.

En la próxima sección, demostraremos operaciones de **filter**, **map** y **reduce** utilizando los métodos de extensión **LINQ** a objetos de la clase `Enumeralbe`: `Where`, `Select` y `Aggregate`, respectivamente. Los métodos de extensión definidos por la clase `Enumerable` operan en colecciones que implementan la interfaz `IEnumerable<T>`.

### C# y Programación Funcional

Aunque C# no fue originalmente diseñado como un lenguaje de programación funcional, la sintaxis de consulta de LINQ de C# y los métodos de extensión de LINQ admiten técnicas de programación funcional, como la iteración interna y la inmutabilidad. Además, las propiedades implementadas automáticamente de solo lectura de C# 6 facilitan la definición de tipos inmutables. Esperamos que las futuras versiones de C# y la mayoría de otros lenguajes de programación populares incluyan más capacidades de programación funcional que hagan que la implementación de programas con un estilo funcional sea más natural.


## Programación Funcional con Sintaxis de Llamada de Método LINQ y Lambdas

En el Capítulo 9, presentamos LINQ, demostramos la sintaxis de consulta de LINQ e introdujimos algunos métodos de extensión de LINQ. Las mismas tareas que puedes realizar con la sintaxis de consulta de LINQ también se pueden realizar con varios métodos de extensión de LINQ y lambdas. De hecho, el compilador traduce la sintaxis de consulta de LINQ en llamadas a métodos de extensión de LINQ que reciben lambdas como argumentos. Por ejemplo, las líneas 21-24 de la Figura 9.2:

```Csharp
var filtered =
    from value in values // data source is values
    where value > 4    
    select value;   
```

pueden escribirse como:

```Csharp
    var filtered = values.Where(value => value > 4);
```

La Figura 19.8 demuestra técnicas simples de programación funcional usando una lista de enteros.

### Método de Extensión Display
A lo largo de este ejemplo, mostramos los resultados de varias operaciones llamando a nuestro propio método de extensión llamado `Display`, el cual está definido en la clase estática `Extensions` (líneas 54-61). El método utiliza el método `Join` de `string` para concatenar los elementos del argumento `IEnumerable<T>` separados por espacios.
Observa al principio y al final de `Main` que cuando llamamos `Display` directamente en la colección de `values`, los mismos valores se muestran en el mismo orden. Estas salidas confirman que las operaciones de programación funcional realizadas a lo largo de `Main` no modifican el contenido de la colección original de valores.

## 19.11.1 Métodos de Extensión LINQ `Min`, `Max`, `Sum` y `Average`
La clase `Enumerable` (`namespace System.Linq`) define varios métodos de extensión **LINQ** para realizar operaciones de reducción comunes, incluyendo:
- `Min` (línea 17) devuelve el valor más pequeño en la colección.
- `Max` (línea 18) devuelve el valor más grande en la colección.
- `Sum` (línea 19) devuelve la suma de todos los valores en la colección.
- `Average` (línea 20) devuelve el promedio de todos los valores en la colección.

### Iteración y Mutación Están Ocultas para Ti
Observa en las líneas 17-20 que para cada una de estas operaciones de reducción:
- Simplemente decimos qué queremos lograr, no cómo lograrlo, no hay detalles de iteración en la aplicación.
- No se utilizan variables mutables en la aplicación para realizar estas operaciones.
- La colección de valores no se modifica (confirmado por la salida de la línea 49).

*De hecho, las operaciones LINQ no tienen efectos secundarios que modifiquen la colección original o cualquier otra variable en la aplicación, un aspecto clave de la programación funcional.*

Por supuesto, detrás de escena se requiere *iteración* y *variables mutables*:
- Todos los cuatro métodos de extensión iteran a través de la colección y deben llevar un seguimiento del elemento actual que están procesando.
- Mientras iteran a través de la colección, `Min` y `Max` deben almacenar los elementos más pequeños y más grandes actuales, respectivamente, y `Sum` y `Average` deben llevar un seguimiento del total de los elementos procesados hasta ahora, todo esto requiere mutar una variable local que está oculta para ti.

*Las otras operaciones en las Secciones 19.11.2–19.11.4 también requieren iteración y variables mutables, pero la biblioteca, que ya ha sido depurada y probada exhaustivamente, maneja estos detalles por ti. Para ver cómo los métodos de extensión LINQ como `Min`, `Max`, `Sum` y `Average` implementan estos conceptos, consulta la clase `Enumerable` en el código fuente de .NET en:*

https://github.com/dotnet/corefx/tree/master/src/System.Linq/src/System/Linq

*La clase Enumerable está dividida en muchas clases parciales, puedes encontrar los métodos `Min`, `Max`, `Sum` y `Average` en los archivos Min.cs, Max.cs, Sum.cs y Average.cs.*

## Método de Extensión `Aggregate` para Operaciones de Reducción

Puedes definir tus propias reducciones con el método de extensión `Aggregate` de LINQ. Por ejemplo, la llamada a `Aggregate` en las líneas 23–24 suma los elementos de `values`. La versión de `Aggregate` utilizada aquí recibe dos argumentos:

- El primer argumento (0) es un valor que te ayuda a comenzar la operación de reducción. Cuando sumamos los elementos de una colección, comenzamos con el valor 0. Pronto, usaremos 1 para comenzar a calcular el producto de los elementos.
- El segundo argumento es un delegado del tipo `Func` (`namespace System`) que representa un método que recibe dos argumentos del mismo tipo y devuelve un valor. Hay muchas versiones de tipo `Func` que especifican de 0 a 16 argumentos de cualquier tipo. En este caso, pasamos la siguiente expresión lambda, que devuelve la suma de sus dos argumentos:

```Csharp
    (x, y) => x + y
```

Una vez por cada elemento en la colección, `Aggregate` llama a esta expresión lambda.

- En la primera llamada a la lambda, el valor del parámetro `x` es el primer argumento de `Aggregate` (0) y el valor del parámetro `y` es el primer entero en `values` (3), produciendo el valor 3 **(0 + 3)**.
- Cada llamada subsiguiente a la lambda utiliza el resultado de la llamada anterior como el primer argumento de la lambda y el siguiente elemento de la colección como el segundo. En la segunda llamada a la lambda, el valor del parámetro `x` es el resultado del primer cálculo (3) y el valor del parámetro `y` es el segundo entero en `values` (10), produciendo la suma 13 **(3 + 10)**.
- En la tercera llamada a la lambda, el valor del parámetro `x` es el resultado del cálculo anterior (13) y el valor del parámetro y es el tercer entero en `values` (6), produciendo la suma 19 **(13 + 6)**.

Este proceso continúa produciendo un total acumulado de los valores hasta que todos han sido utilizados, momento en el que se devuelve la suma final por `Aggregate`. Nuevamente, observa que no se utilizan variables mutables para reducir la colección a la suma de sus elementos y que la colección original de valores no se modifica.

### Sumando los Cuadrados de los Valores con el Método Aggregate

Las líneas 27-28 utilizan `Aggregate` para calcular la suma de los cuadrados de los elementos de valores. La lambda en este caso,

```
    (x, y) => x + y * y
```

añade el cuadrado del valor actual al total acumulado. La evaluación de la reducción procede de la siguiente manera:

- En la primera llamada a la lambda, el valor del parámetro `x` es el primer argumento de `Aggregate` (0) y el valor del parámetro `y` es el primer entero en `values` (3), produciendo el valor 9 **(0 + 3^2)**.
- En la siguiente llamada a la lambda, el valor del parámetro `x` es el resultado del primer cálculo (9) y el valor del parámetro `y` es el segundo entero en `values` (10), produciendo la suma 109 **(9 + 10^2)**.
- En la siguiente llamada a la lambda, el valor del parámetro `x` es el resultado del cálculo anterior (109) y el valor del parámetro `y` es el tercer entero en `values` (6), produciendo la suma 145 **(109 + 6^2)**.

Este proceso continúa produciendo un total acumulado de los cuadrados de los elementos hasta que todos han sido utilizados, momento en el que se devuelve la suma final por `Aggregate`. Nuevamente, observa que no se utilizan variables mutables para reducir la colección a la suma de sus cuadrados y que la colección original de valores no se modifica.

### Calculando el Producto de los Valores con el Método Aggregate

Las líneas 31-32 utilizan `Aggregate` para calcular el producto de los elementos de valores. La lambda 

```
    (x, y) => x * y
```

multiplica sus dos argumentos. Dado que estamos produciendo un producto, comenzamos con el valor `1` en este caso. La evaluación de la reducción procede de la siguiente manera:

- En la primera llamada a la lambda, el valor del parámetro `x` es el primer argumento de `Aggregate` (1) y el valor del parámetro `y` es el primer entero en `values` (3), produciendo el valor 3 **(1 * 3)**.
- En la siguiente llamada a la lambda, el valor del parámetro `x` es el resultado del primer cálculo (3) y el valor del parámetro `y` es el segundo entero en `values` (10), produciendo el producto 30 **(3 * 10)**.
- En la siguiente llamada a la lambda, el valor del parámetro `x` es el resultado del cálculo anterior (30) y el valor del parámetro `y` es el tercer entero en `values` (6), produciendo el producto 180 **(30 * 6)**.

Este proceso continúa produciendo un producto acumulativo de los elementos hasta que todos han sido utilizados, momento en el cual se devuelve el producto final. Nuevamente, cabe destacar que *no se utilizan variables mutables* para reducir la colección al producto de sus elementos y que la colección original de valores (`values`) no se modifica.

## El Método de Extensión `Where` para Operaciones de Filtrado (**filter**)
Las líneas 37–38 *filtran los enteros pares* en los valores, *los ordenan en orden ascendente* y *muestran los resultados*. Filtras los elementos para producir una *nueva colección* de resultados que coincidan con una condición conocida como predicado. El método de extensión `Where` de LINQ (línea 36) recibe como argumento un delegado `Func` para un método que recibe un argumento y devuelve un `bool` que indica si un elemento dado debe incluirse en la colección devuelta por `Where`.
El lambda en la lvínea 36:

```Csharp
    value => value % 2 == 0
```

recibe un valor y devuelve un `bool` que indica si el valor satisface el predicado, en este caso, si el valor que recibe es divisible por 2.

### Ordenando los Resultados
El método de extensión `OrderBy` recibe como argumento un delegado `Func` que representa un método que recibe un parámetro y devuelve un valor que se utiliza para ordenar los resultados. En este caso (línea 37), la expresión lambda

```Csharp
    value => value
```

simplemente devuelve su argumento, el cual `OrderBy` utiliza para ordenar los valores en orden ascendente. Para orden descendente, se usaría `OrderByDescending`. Nuevamente, cabe destacar que no se utilizan variables mutables para filtrar o ordenar la colección y que la colección original de valores no se modifica.

### Ejecución Diferida
Las llamadas a `Where` y `OrderBy` utilizan la misma ejecución diferida que discutimos en la Sección 9.5.2: no se evalúan hasta que se itera sobre los resultados. En las líneas 36–38 (Fig. 19.8), esto ocurre cuando se llama a nuestro método de extensión `Display` (línea 38). Esto significa que puedes guardar la operación en una variable para su ejecución futura, como en:

```Csharp
var evenIntegers = 
    values.Where(value => value % 2 == 0) // encontrar enteros pares
    .OrderBy(value => value); // ordenar los valores restantes
```

Puedes ejecutar la operación iterando sobre `evenIntegers` más tarde. Cada vez que ejecutas la operación, los elementos actuales en valores se filtrarán y ordenarán. Entonces, si modificas valores agregando más enteros pares a la colección, estos aparecerán en los resultados cuando iteres sobre `evenIntegers`.

### Método de extensión `Select` para Operaciones de Mapeo (**Map**)
Las líneas 42–45 filtran los enteros impares en valores, multiplican cada entero impar por 10, ordenan los valores en orden ascendente y muestran los resultados. La nueva característica aquí es la operación de mapeo que toma cada valor y lo multiplica por 10. El mapeo transforma los elementos de una colección en nuevos valores, que a veces son de tipos diferentes a los elementos originales.
El método de extensión `Select` de LINQ recibe como argumento un delegado `Func` para un método que recibe un argumento y lo mapea a un nuevo valor (posiblemente de otro tipo) que se incluye en la colección devuelta por `Select`. La lambda en la línea 46:

```
    valor => valor * 10
```

multiplica su argumento de valor por 10, mapeándolo así a un nuevo valor. La línea 44 ordena los resultados. Las llamadas a `Select` se diferirán hasta que se itere sobre los resultados, en este caso, cuando se llame a nuestro método de extensión `Display` (línea 45). Nuevamente, ten en cuenta que no se utilizan variables mutables para mapear los elementos de la colección y que la colección original de valores no se modifica.