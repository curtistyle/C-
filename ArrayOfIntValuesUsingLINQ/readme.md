## A Linq querys

### The `from` clause

La clausula `from` especifica una variable de rango (ej: `value`) y la fuente de datos a consultar (ej: una lista).
La variable de rango (`value`) representa cada elemento de la lista (uno a la vez).

### The `where` clause

La clausa `where` evalua: si la condicion es verdadera, el elemento es seleccionado.
*Una expresion que toma un valor y devuelve verdadero o falso al probar una condiciaon, ese valor se conoce como predicado*

### The `select` clause

Para cada elemento de la lista, la clausula `select` determina que valor aparece en los resultados

### Iterating Through the Results of the LINQ Query

Podemos usar un `foreach` para iterar un resultado de una consulta LINQ, mostrando cada uno de sus elementos.

### The `orderby` clause

La clausula `orderby` ordena los resultados de la consulta en orden ascendente.
Y el modificador `descending` en la clausula `orderby` ordena los resultados en orden descendentes.
*Caulquier valor que pueda compararse con otros valores del mismo tipo puede ser utilizado con la clausula orderby*
Debido a que las consultas pueden operar sobre los resultados de otras consultas, es posible construir una consulta paso a paso, pasando los resultados de las consultas entre metodos, para su procesamiento adicional.

## La interfaz `IEnumerable<T>`

Esta interfaz describe la funcionalidad de cualquier objeto que se pueda recorrer y, por lo tanto, ofrece metodos y propiedades para acceder a cada elemento.
La mayoria de las consultas LINQ devuelve un objeto `IEnumerable<T>`. Para las consultas que devuelven un objeto `IEnumerable<T>`, se puede utilizar una declaracion `foreach` para iterar sobre los resultados de la consulta.
La notacion `<T>` indica que la interfaz es una interfaz generica que se puede utilizar con cualquier tipo de datos.

### Algunos metodos de extension de `IEnumerable`

#### Metodo `Distinct()`

El m�todo `Distinct()` es un m�todo de extensi�n en LINQ para la interfaz IEnumerable<T> en C#. Este m�todo se utiliza para eliminar elementos duplicados de una secuencia de elementos, devolviendo una nueva secuencia que contiene solo los elementos �nicos

Es importante tener en cuenta que el m�todo `Distinct()` utiliza la igualdad por defecto (`EqualityComparer<T>.Default`) para comparar los elementos y determinar si son iguales o no. Para tipos de datos personalizados, es posible que necesites proporcionar tu propia implementaci�n de `IEqualityComparer<T>` o utilizar la sobrecarga del m�todo `Distinct()` que acepta un comparador personalizado.

#### Metodo `First()`

El m�todo `First` se utiliza para obtener el primer elemento de una secuencia de elementos que cumple con ciertos criterios o simplemente el primer elemento de la secuencia si no se especifican criterios adicionales.

Es importante tener en cuenta que si deseas evitar que se genere una excepci�n cuando la secuencia est� vac�a, puedes usar `FirstOrDefault()`, que devuelve el primer elemento de la secuencia o un valor predeterminado si la secuencia est� vac�a.

#### Metodo `Intersect()`

El m�todo `Intersect()` se utiliza para obtener la intersecci�n de dos secuencias, es decir, los elementos que est�n presentes en ambas secuencias.

Es importante tener en cuenta que el m�todo Intersect() utiliza la igualdad por defecto (`EqualityComparer<T>.Default`) para comparar los elementos y determinar si son iguales o no. Para tipos de datos personalizados, es posible que necesites proporcionar tu propia implementaci�n de `IEqualityComparer<T>` o utilizar la sobrecarga del m�todo `Intersect()` que acepta un comparador personalizado.

#### Metodo`Count()`

El m�todo `Count()` se utiliza para contar el n�mero de elementos en una secuencia de elementos que implementa la interfaz `IEnumerable<T>`.

Este metodo tiene algunas variantes. Sin argumentos, simplemente cuenta el n�mero total de elementos en la secuencia. Sin embargo, tambi�n puede aceptar un predicado como argumento, lo que permite contar solo los elementos que cumplen con ciertos criterios.

Es importante tener en cuenta que el m�todo `Count()` realiza un recorrido completo de la secuencia para contar los elementos. Esto puede tener un impacto en el rendimiento, especialmente en secuencias grandes o en secuencias que no son colecciones en memoria, como consultas de base de datos.

#### Metodo `ElementAt()`

El metodo `ElementAt()` se utiliza para obtener el elemento en una posici�n espec�fica dentro de una secuencia de elementos que implementa la interfaz `IEnumerable<T>`.

Es importante tener en cuenta que el m�todo `ElementAt()` utiliza indexaci�n base cero, lo que significa que el primer elemento de la secuencia est� en la posici�n 0, el segundo elemento est� en la posici�n 1, y as� sucesivamente. Si el �ndice especificado est� fuera del rango de la secuencia (es decir, si es menor que cero o mayor o igual al n�mero total de elementos), se genera una excepci�n `ArgumentOutOfRangeException`.

#### Metodo `Except()`

El metodo `Except()` se utiliza para obtener los elementos que est�n presentes en una secuencia pero no est�n presentes en otra secuencia, es decir, realiza la operaci�n de diferencia entre dos secuencias.

Es importante tener en cuenta que el m�todo `Except()` utiliza la igualdad por defecto (`EqualityComparer<T>.Default`) para comparar los elementos y determinar si son iguales o no. Para tipos de datos personalizados, es posible que necesites proporcionar tu propia implementaci�n de `IEqualityComparer<T>` o utilizar la sobrecarga del m�todo `Except()` que acepta un comparador personalizado.

#### Metodo `Join()`

El metodo `Join()` se utiliza para realizar una operaci�n de combinaci�n (join) entre dos secuencias basada en una condici�n de igualdad entre las claves de ambas secuencias.

**El m�todo `Join()` toma cuatro argumentos:**

- La secuencia interna (`inner`) que se combinar� con la secuencia externa.
- La clave de la secuencia interna (`innerKeySelector`).
- La clave de la secuencia externa (`outerKeySelector`).
- Un selector de resultados (`resultSelector`) que especifica c�mo se deben combinar los elementos de las dos secuencias para formar el resultado final.
- Es importante tener en cuenta que `Join()` es una operaci�n que puede ser costosa, especialmente si las secuencias son grandes, ya que implica comparar cada elemento de una secuencia con cada elemento de la otra secuencia.

```C#
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var personas = new[] {
            new { Id = 1, Nombre = "Juan" },
            new { Id = 2, Nombre = "Mar�a" },
            new { Id = 3, Nombre = "Pedro" }
        };

        var trabajos = new[] {
            new { Id = 1, Trabajo = "Ingeniero" },
            new { Id = 2, Trabajo = "Doctor" }
        };

        var resultado = personas.Join(
            trabajos,
            persona => persona.Id,
            trabajo => trabajo.Id,
            (persona, trabajo) => new {
                Nombre = persona.Nombre,
                Trabajo = trabajo.Trabajo
            });

        foreach (var item in resultado)
        {
            Console.WriteLine($"{item.Nombre} - {item.Trabajo}");
        }
    }
}

```

#### Metodo `Max()`

El M�todo `Max()` se utiliza para obtener el valor m�ximo de una secuencia de elementos que implementa la interfaz `IEnumerable<T>`.

Es importante tener en cuenta que el m�todo `Max()` puede ser utilizado con tipos de datos que implementan la interfaz `IComparable<T>`, lo que significa que los elementos de la secuencia deben ser comparables entre s� para determinar cu�l es el m�ximo.

#### Metodo `Min()`

El m�todo `Min()` se utiliza para obtener el valor minimo de una secuencia de elementos que implementa la interfaz `IEnumerable<T>`

Al igual que con el m�todo `Max()`, el m�todo `Min()` puede ser utilizado con tipos de datos que implementan la interfaz `IComparable<T>`, lo que significa que los elementos de la secuencia deben ser comparables entre s� para determinar cu�l es el m�nimo.

#### Metodo `Last()`

El metodo `Last()` se utiliza para obtener el �ltimo elemento de una secuencia de elementos que implementa la interfaz `IEnumerable<T>`.

Es importante tener en cuenta que el m�todo `Last()` puede generar una excepci�n `InvalidOperationException` si la secuencia est� vac�a, es decir, si no contiene ning�n elemento.

Si la secuencia est� vac�a, el m�todo `Last()` generar� una excepci�n `InvalidOperationException`. Es importante manejar este caso si no est�s seguro de si la secuencia contiene elementos o no. Puedes utilizar m�todos como `LastOrDefault()` si prefieres un valor predeterminado en lugar de una excepci�n en caso de una secuencia vac�a.

#### Metodo `Agregate()`

El metodo `Agregate()` se utiliza para aplicar una funci�n acumuladora a los elementos de una secuencia, produciendo un �nico resultado.

Es importante tener en cuenta que el m�todo `Aggregate()` puede ser utilizado para una amplia variedad de operaciones de agregaci�n, como sumar todos los elementos de una secuencia, calcular un producto, concatenar cadenas, encontrar el valor m�ximo o m�nimo, etc. La funci�n acumuladora que se proporciona determina c�mo se realizar� la agregaci�n.

```
int[] ints = { 4, 8, 8, 3, 9, 0, 7, 8, 2 };

// Count the even numbers in the array, using a seed value of 0.
int numEven = ints.Aggregate(0, (total, next) =>
                                    next % 2 == 0 ? total + 1 : total);

Console.WriteLine("The number of even integers is: {0}", numEven);

// This code produces the following output:
//
// The number of even integers is: 6
```

```
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] numeros = { 1, 2, 3, 4, 5 };

        // Calcular la suma de los elementos de la secuencia
        int suma = numeros.Aggregate((acumulador, elemento) => acumulador + elemento);
        Console.WriteLine("La suma de los elementos es: " + suma); // Salida: 15
    }
}
```

- `numeros`: Es una secuencia de elementos sobre la que se aplica el m�todo `Aggregate()`.
- `Aggregate(...)`: Este es el m�todo `Aggregate()` en s� mismo, que toma un acumulador inicial y una funci�n acumuladora como argumentos.
- `acumulador` y `elemento`: Son par�metros de la funci�n acumuladora. acumulador representa el valor acumulado hasta el momento, y elemento es el siguiente elemento en la secuencia que se est� procesando.
- `=>`: Este es el operador de la expresi�n lambda, que define la funci�n acumuladora.
- `acumulador + elemento`: Es la expresi�n que describe c�mo se acumula el valor. En este caso, simplemente suma el valor del acumulador actual con el elemento actual de la secuencia.