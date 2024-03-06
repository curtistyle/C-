## 19.10 Introducci�n a la Programaci�n Funcional
Hasta ahora, has visto t�cnicas de programaci�n estructurada, orientada a objetos y gen�rica en C#. Aunque a menudo usaste clases e interfaces del marco de trabajo .NET para realizar diversas tareas, t�picamente determinaste lo que quer�as lograr en una tarea, luego especificaste precisamente c�mo lograrlo.

Por ejemplo, supongamos que lo que te gustar�a lograr es sumar los elementos de un array de enteros llamado valores (la fuente de datos). Podr�as usar el siguiente c�digo:

```csharp
var suma = 0;
for (var contador = 0; contador < valores.Length; ++contador)
{
    suma += valores[contador];
}
```

Este bucle especifica precisamente c�mo agregar el valor de cada elemento del array a la suma, con una declaraci�n de iteraci�n `for` que procesa cada elemento uno a la vez, agregando su valor a la suma. Esta t�cnica se conoce como iteraci�n externa, porque especificas c�mo iterar, no la biblioteca, y requiere que accedas a los elementos secuencialmente desde el principio hasta el final en un �nico hilo de ejecuci�n. Para realizar la tarea anterior, tambi�n creas dos variables (`suma` y `contador`) que se mutan repetidamente: sus valores cambian a medida que se realiza la iteraci�n. Realizaste muchas tareas similares con arrays y colecciones, como mostrar los elementos de un array, resumir las caras de un dado que se lanz� 60,000,000 veces, calcular el promedio de los elementos de un array y m�s.

#### La Iteraci�n Externa Es Propensa a Errores
El problema con la iteraci�n externa es que incluso en este bucle simple, hay muchas oportunidades para cometer errores. Por ejemplo, podr�as:
    - inicializar incorrectamente la variable `suma`,
    - inicializar incorrectamente la variable de control `contador`,
    - usar una condici�n de continuaci�n de bucle incorrecta,
    - incrementar incorrectamente la variable de control contador o
    - sumar incorrectamente cada valor en el array a la `suma`.

#### Iteraci�n Interna
**En la programaci�n funcional, especificas lo que quieres lograr en una tarea, pero no c�mo lograrlo.** Como ver�s, para sumar los elementos de una fuente de datos num�ricos (como los de un array o una colecci�n), puedes usar las capacidades de LINQ que te permiten decir: "Aqu� tienes una fuente de datos, dame la suma de sus elementos". No necesitas especificar c�mo iterar a trav�s de los elementos ni declarar ni usar variables mutables (es decir, modificables). Esto se conoce como **iteraci�n interna**, porque el c�digo de la biblioteca (por detr�s) itera a trav�s de todos los elementos para realizar la tarea.

> *Los desarrolladores de sistemas han estado familiarizados con la distinci�n entre "qu� vs. c�mo" durante d�cadas. Comienzan un esfuerzo de desarrollo de sistemas definiendo un documento de requisitos que especifica qu� se supone que debe hacer el sistema. Luego, utilizan herramientas, como UML, para dise�ar el sistema, lo que especifica c�mo debe construirse el sistema para cumplir con los requisitos. En los cap�tulos en l�nea, construimos el software para un cajero autom�tico muy simple. Comenzamos con un documento de requisitos que especifica qu� se supone que debe hacer el software, luego usamos UML para especificar c�mo el software debe hacerlo. Especificamos los detalles finales de c�mo escribiendo el c�digo C# real.*

Un aspecto clave de la programaci�n funcional es la inmutabilidad, es decir, *no modificar la fuente de datos que se est� procesando ni ning�n otro estado del programa*, como variables de control de contador en bucles. Al utilizar la iteraci�n interna, eliminas de tus programas errores comunes que son causados por modificar datos incorrectamente. Esto facilita la escritura de c�digo correcto.

#### Filtrar, Mapear y Reducir
Tres operaciones comunes de programaci�n funcional que realizar�s en colecciones de datos son **filtrar** (*Filter*), **mapear** (*Map*) y **reducir** (*reduce*):

- Una operaci�n de **filter** resulta en una nueva colecci�n que contiene solo los elementos que satisfacen una condici�n. Por ejemplo, podr�as filtrar una colecci�n de enteros para localizar solo los enteros pares, o podr�as filtrar una colecci�n de empleados para localizar personas en un departamento espec�fico de una gran empresa. Las operaciones de filtro no modifican la colecci�n original.

- Una operaci�n de **map** resulta en una nueva colecci�n en la que cada elemento de la colecci�n original se asigna a un nuevo valor (posiblemente de un tipo diferente), por ejemplo, asignando valores num�ricos a los cuadrados de los valores num�ricos. La nueva colecci�n tiene el mismo n�mero de elementos que la colecci�n que fue asignada. Las operaciones de mapeo no modifican la colecci�n original.

- Una operaci�n de **reduce** combina los elementos de una colecci�n en un nuevo valor �nico, t�picamente utilizando un lambda que especifica c�mo combinar los elementos. Por ejemplo, podr�as reducir una colecci�n de calificaciones de ex�menes de enteros de cero a 100 al n�mero de estudiantes que aprobaron con una calificaci�n mayor o igual a 60. Las operaciones de reducci�n no modifican la colecci�n original.

En la pr�xima secci�n, demostraremos operaciones de **filter**, **map** y **reduce** utilizando los m�todos de extensi�n **LINQ** a objetos de la clase `Enumeralbe`: `Where`, `Select` y `Aggregate`, respectivamente. Los m�todos de extensi�n definidos por la clase `Enumerable` operan en colecciones que implementan la interfaz `IEnumerable<T>`.

### C# y Programaci�n Funcional

Aunque C# no fue originalmente dise�ado como un lenguaje de programaci�n funcional, la sintaxis de consulta de LINQ de C# y los m�todos de extensi�n de LINQ admiten t�cnicas de programaci�n funcional, como la iteraci�n interna y la inmutabilidad. Adem�s, las propiedades implementadas autom�ticamente de solo lectura de C# 6 facilitan la definici�n de tipos inmutables. Esperamos que las futuras versiones de C# y la mayor�a de otros lenguajes de programaci�n populares incluyan m�s capacidades de programaci�n funcional que hagan que la implementaci�n de programas con un estilo funcional sea m�s natural.


## Programaci�n Funcional con Sintaxis de Llamada de M�todo LINQ y Lambdas

En el Cap�tulo 9, presentamos LINQ, demostramos la sintaxis de consulta de LINQ e introdujimos algunos m�todos de extensi�n de LINQ. Las mismas tareas que puedes realizar con la sintaxis de consulta de LINQ tambi�n se pueden realizar con varios m�todos de extensi�n de LINQ y lambdas. De hecho, el compilador traduce la sintaxis de consulta de LINQ en llamadas a m�todos de extensi�n de LINQ que reciben lambdas como argumentos. Por ejemplo, las l�neas 21-24 de la Figura 9.2:

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

La Figura 19.8 demuestra t�cnicas simples de programaci�n funcional usando una lista de enteros.

### M�todo de Extensi�n Display
A lo largo de este ejemplo, mostramos los resultados de varias operaciones llamando a nuestro propio m�todo de extensi�n llamado `Display`, el cual est� definido en la clase est�tica `Extensions` (l�neas 54-61). El m�todo utiliza el m�todo `Join` de `string` para concatenar los elementos del argumento `IEnumerable<T>` separados por espacios.
Observa al principio y al final de `Main` que cuando llamamos `Display` directamente en la colecci�n de `values`, los mismos valores se muestran en el mismo orden. Estas salidas confirman que las operaciones de programaci�n funcional realizadas a lo largo de `Main` no modifican el contenido de la colecci�n original de valores.

## 19.11.1 M�todos de Extensi�n LINQ `Min`, `Max`, `Sum` y `Average`
La clase `Enumerable` (`namespace System.Linq`) define varios m�todos de extensi�n **LINQ** para realizar operaciones de reducci�n comunes, incluyendo:
- `Min` (l�nea 17) devuelve el valor m�s peque�o en la colecci�n.
- `Max` (l�nea 18) devuelve el valor m�s grande en la colecci�n.
- `Sum` (l�nea 19) devuelve la suma de todos los valores en la colecci�n.
- `Average` (l�nea 20) devuelve el promedio de todos los valores en la colecci�n.

### Iteraci�n y Mutaci�n Est�n Ocultas para Ti
Observa en las l�neas 17-20 que para cada una de estas operaciones de reducci�n:
- Simplemente decimos qu� queremos lograr, no c�mo lograrlo, no hay detalles de iteraci�n en la aplicaci�n.
- No se utilizan variables mutables en la aplicaci�n para realizar estas operaciones.
- La colecci�n de valores no se modifica (confirmado por la salida de la l�nea 49).

*De hecho, las operaciones LINQ no tienen efectos secundarios que modifiquen la colecci�n original o cualquier otra variable en la aplicaci�n, un aspecto clave de la programaci�n funcional.*

Por supuesto, detr�s de escena se requiere *iteraci�n* y *variables mutables*:
- Todos los cuatro m�todos de extensi�n iteran a trav�s de la colecci�n y deben llevar un seguimiento del elemento actual que est�n procesando.
- Mientras iteran a trav�s de la colecci�n, `Min` y `Max` deben almacenar los elementos m�s peque�os y m�s grandes actuales, respectivamente, y `Sum` y `Average` deben llevar un seguimiento del total de los elementos procesados hasta ahora, todo esto requiere mutar una variable local que est� oculta para ti.

*Las otras operaciones en las Secciones 19.11.2�19.11.4 tambi�n requieren iteraci�n y variables mutables, pero la biblioteca, que ya ha sido depurada y probada exhaustivamente, maneja estos detalles por ti. Para ver c�mo los m�todos de extensi�n LINQ como `Min`, `Max`, `Sum` y `Average` implementan estos conceptos, consulta la clase `Enumerable` en el c�digo fuente de .NET en:*

https://github.com/dotnet/corefx/tree/master/src/System.Linq/src/System/Linq

*La clase Enumerable est� dividida en muchas clases parciales, puedes encontrar los m�todos `Min`, `Max`, `Sum` y `Average` en los archivos Min.cs, Max.cs, Sum.cs y Average.cs.*

## M�todo de Extensi�n `Aggregate` para Operaciones de Reducci�n

Puedes definir tus propias reducciones con el m�todo de extensi�n `Aggregate` de LINQ. Por ejemplo, la llamada a `Aggregate` en las l�neas 23�24 suma los elementos de `values`. La versi�n de `Aggregate` utilizada aqu� recibe dos argumentos:

- El primer argumento (0) es un valor que te ayuda a comenzar la operaci�n de reducci�n. Cuando sumamos los elementos de una colecci�n, comenzamos con el valor 0. Pronto, usaremos 1 para comenzar a calcular el producto de los elementos.
- El segundo argumento es un delegado del tipo `Func` (`namespace System`) que representa un m�todo que recibe dos argumentos del mismo tipo y devuelve un valor. Hay muchas versiones de tipo `Func` que especifican de 0 a 16 argumentos de cualquier tipo. En este caso, pasamos la siguiente expresi�n lambda, que devuelve la suma de sus dos argumentos:

```Csharp
    (x, y) => x + y
```

Una vez por cada elemento en la colecci�n, `Aggregate` llama a esta expresi�n lambda.

- En la primera llamada a la lambda, el valor del par�metro `x` es el primer argumento de `Aggregate` (0) y el valor del par�metro `y` es el primer entero en `values` (3), produciendo el valor 3 **(0 + 3)**.
- Cada llamada subsiguiente a la lambda utiliza el resultado de la llamada anterior como el primer argumento de la lambda y el siguiente elemento de la colecci�n como el segundo. En la segunda llamada a la lambda, el valor del par�metro `x` es el resultado del primer c�lculo (3) y el valor del par�metro `y` es el segundo entero en `values` (10), produciendo la suma 13 **(3 + 10)**.
- En la tercera llamada a la lambda, el valor del par�metro `x` es el resultado del c�lculo anterior (13) y el valor del par�metro y es el tercer entero en `values` (6), produciendo la suma 19 **(13 + 6)**.

Este proceso contin�a produciendo un total acumulado de los valores hasta que todos han sido utilizados, momento en el que se devuelve la suma final por `Aggregate`. Nuevamente, observa que no se utilizan variables mutables para reducir la colecci�n a la suma de sus elementos y que la colecci�n original de valores no se modifica.

### Sumando los Cuadrados de los Valores con el M�todo Aggregate

Las l�neas 27-28 utilizan `Aggregate` para calcular la suma de los cuadrados de los elementos de valores. La lambda en este caso,

```
    (x, y) => x + y * y
```

a�ade el cuadrado del valor actual al total acumulado. La evaluaci�n de la reducci�n procede de la siguiente manera:

- En la primera llamada a la lambda, el valor del par�metro `x` es el primer argumento de `Aggregate` (0) y el valor del par�metro `y` es el primer entero en `values` (3), produciendo el valor 9 **(0 + 3^2)**.
- En la siguiente llamada a la lambda, el valor del par�metro `x` es el resultado del primer c�lculo (9) y el valor del par�metro `y` es el segundo entero en `values` (10), produciendo la suma 109 **(9 + 10^2)**.
- En la siguiente llamada a la lambda, el valor del par�metro `x` es el resultado del c�lculo anterior (109) y el valor del par�metro `y` es el tercer entero en `values` (6), produciendo la suma 145 **(109 + 6^2)**.

Este proceso contin�a produciendo un total acumulado de los cuadrados de los elementos hasta que todos han sido utilizados, momento en el que se devuelve la suma final por `Aggregate`. Nuevamente, observa que no se utilizan variables mutables para reducir la colecci�n a la suma de sus cuadrados y que la colecci�n original de valores no se modifica.

### Calculando el Producto de los Valores con el M�todo Aggregate

Las l�neas 31-32 utilizan `Aggregate` para calcular el producto de los elementos de valores. La lambda 

```
    (x, y) => x * y
```

multiplica sus dos argumentos. Dado que estamos produciendo un producto, comenzamos con el valor `1` en este caso. La evaluaci�n de la reducci�n procede de la siguiente manera:

- En la primera llamada a la lambda, el valor del par�metro `x` es el primer argumento de `Aggregate` (1) y el valor del par�metro `y` es el primer entero en `values` (3), produciendo el valor 3 **(1 * 3)**.
- En la siguiente llamada a la lambda, el valor del par�metro `x` es el resultado del primer c�lculo (3) y el valor del par�metro `y` es el segundo entero en `values` (10), produciendo el producto 30 **(3 * 10)**.
- En la siguiente llamada a la lambda, el valor del par�metro `x` es el resultado del c�lculo anterior (30) y el valor del par�metro `y` es el tercer entero en `values` (6), produciendo el producto 180 **(30 * 6)**.

Este proceso contin�a produciendo un producto acumulativo de los elementos hasta que todos han sido utilizados, momento en el cual se devuelve el producto final. Nuevamente, cabe destacar que *no se utilizan variables mutables* para reducir la colecci�n al producto de sus elementos y que la colecci�n original de valores (`values`) no se modifica.

## El M�todo de Extensi�n `Where` para Operaciones de Filtrado (**filter**)
Las l�neas 37�38 *filtran los enteros pares* en los valores, *los ordenan en orden ascendente* y *muestran los resultados*. Filtras los elementos para producir una *nueva colecci�n* de resultados que coincidan con una condici�n conocida como predicado. El m�todo de extensi�n `Where` de LINQ (l�nea 36) recibe como argumento un delegado `Func` para un m�todo que recibe un argumento y devuelve un `bool` que indica si un elemento dado debe incluirse en la colecci�n devuelta por `Where`.
El lambda en la lv�nea 36:

```Csharp
    value => value % 2 == 0
```

recibe un valor y devuelve un `bool` que indica si el valor satisface el predicado, en este caso, si el valor que recibe es divisible por 2.

### Ordenando los Resultados
El m�todo de extensi�n `OrderBy` recibe como argumento un delegado `Func` que representa un m�todo que recibe un par�metro y devuelve un valor que se utiliza para ordenar los resultados. En este caso (l�nea 37), la expresi�n lambda

```Csharp
    value => value
```

simplemente devuelve su argumento, el cual `OrderBy` utiliza para ordenar los valores en orden ascendente. Para orden descendente, se usar�a `OrderByDescending`. Nuevamente, cabe destacar que no se utilizan variables mutables para filtrar o ordenar la colecci�n y que la colecci�n original de valores no se modifica.

### Ejecuci�n Diferida
Las llamadas a `Where` y `OrderBy` utilizan la misma ejecuci�n diferida que discutimos en la Secci�n 9.5.2: no se eval�an hasta que se itera sobre los resultados. En las l�neas 36�38 (Fig. 19.8), esto ocurre cuando se llama a nuestro m�todo de extensi�n `Display` (l�nea 38). Esto significa que puedes guardar la operaci�n en una variable para su ejecuci�n futura, como en:

```Csharp
var evenIntegers = 
    values.Where(value => value % 2 == 0) // encontrar enteros pares
    .OrderBy(value => value); // ordenar los valores restantes
```

Puedes ejecutar la operaci�n iterando sobre `evenIntegers` m�s tarde. Cada vez que ejecutas la operaci�n, los elementos actuales en valores se filtrar�n y ordenar�n. Entonces, si modificas valores agregando m�s enteros pares a la colecci�n, estos aparecer�n en los resultados cuando iteres sobre `evenIntegers`.

### M�todo de extensi�n `Select` para Operaciones de Mapeo (**Map**)
Las l�neas 42�45 filtran los enteros impares en valores, multiplican cada entero impar por 10, ordenan los valores en orden ascendente y muestran los resultados. La nueva caracter�stica aqu� es la operaci�n de mapeo que toma cada valor y lo multiplica por 10. El mapeo transforma los elementos de una colecci�n en nuevos valores, que a veces son de tipos diferentes a los elementos originales.
El m�todo de extensi�n `Select` de LINQ recibe como argumento un delegado `Func` para un m�todo que recibe un argumento y lo mapea a un nuevo valor (posiblemente de otro tipo) que se incluye en la colecci�n devuelta por `Select`. La lambda en la l�nea 46:

```
    valor => valor * 10
```

multiplica su argumento de valor por 10, mape�ndolo as� a un nuevo valor. La l�nea 44 ordena los resultados. Las llamadas a `Select` se diferir�n hasta que se itere sobre los resultados, en este caso, cuando se llame a nuestro m�todo de extensi�n `Display` (l�nea 45). Nuevamente, ten en cuenta que no se utilizan variables mutables para mapear los elementos de la colecci�n y que la colecci�n original de valores no se modifica.