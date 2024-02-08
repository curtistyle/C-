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

El método `Distinct()` es un método de extensión en LINQ para la interfaz IEnumerable<T> en C#. Este método se utiliza para eliminar elementos duplicados de una secuencia de elementos, devolviendo una nueva secuencia que contiene solo los elementos únicos

Es importante tener en cuenta que el método `Distinct()` utiliza la igualdad por defecto (`EqualityComparer<T>.Default`) para comparar los elementos y determinar si son iguales o no. Para tipos de datos personalizados, es posible que necesites proporcionar tu propia implementación de `IEqualityComparer<T>` o utilizar la sobrecarga del método `Distinct()` que acepta un comparador personalizado.

#### Metodo `First()`

El método `First` se utiliza para obtener el primer elemento de una secuencia de elementos que cumple con ciertos criterios o simplemente el primer elemento de la secuencia si no se especifican criterios adicionales.

Es importante tener en cuenta que si deseas evitar que se genere una excepción cuando la secuencia está vacía, puedes usar `FirstOrDefault()`, que devuelve el primer elemento de la secuencia o un valor predeterminado si la secuencia está vacía.

#### Metodo `Intersect()`

El método `Intersect()` se utiliza para obtener la intersección de dos secuencias, es decir, los elementos que están presentes en ambas secuencias.

Es importante tener en cuenta que el método Intersect() utiliza la igualdad por defecto (`EqualityComparer<T>.Default`) para comparar los elementos y determinar si son iguales o no. Para tipos de datos personalizados, es posible que necesites proporcionar tu propia implementación de `IEqualityComparer<T>` o utilizar la sobrecarga del método `Intersect()` que acepta un comparador personalizado.

#### Metodo`Count()`

El método `Count()` se utiliza para contar el número de elementos en una secuencia de elementos que implementa la interfaz `IEnumerable<T>`.

Este metodo tiene algunas variantes. Sin argumentos, simplemente cuenta el número total de elementos en la secuencia. Sin embargo, también puede aceptar un predicado como argumento, lo que permite contar solo los elementos que cumplen con ciertos criterios.

Es importante tener en cuenta que el método `Count()` realiza un recorrido completo de la secuencia para contar los elementos. Esto puede tener un impacto en el rendimiento, especialmente en secuencias grandes o en secuencias que no son colecciones en memoria, como consultas de base de datos.

#### Metodo `ElementAt()`

El metodo `ElementAt()` se utiliza para obtener el elemento en una posición específica dentro de una secuencia de elementos que implementa la interfaz `IEnumerable<T>`.

Es importante tener en cuenta que el método `ElementAt()` utiliza indexación base cero, lo que significa que el primer elemento de la secuencia está en la posición 0, el segundo elemento está en la posición 1, y así sucesivamente. Si el índice especificado está fuera del rango de la secuencia (es decir, si es menor que cero o mayor o igual al número total de elementos), se genera una excepción `ArgumentOutOfRangeException`.

#### Metodo `Except()`

El metodo `Except()` se utiliza para obtener los elementos que están presentes en una secuencia pero no están presentes en otra secuencia, es decir, realiza la operación de diferencia entre dos secuencias.

Es importante tener en cuenta que el método `Except()` utiliza la igualdad por defecto (`EqualityComparer<T>.Default`) para comparar los elementos y determinar si son iguales o no. Para tipos de datos personalizados, es posible que necesites proporcionar tu propia implementación de `IEqualityComparer<T>` o utilizar la sobrecarga del método `Except()` que acepta un comparador personalizado.

#### Metodo `Join()`

El metodo `Join()` se utiliza para realizar una operación de combinación (join) entre dos secuencias basada en una condición de igualdad entre las claves de ambas secuencias.

**El método `Join()` toma cuatro argumentos:**

- La secuencia interna (`inner`) que se combinará con la secuencia externa.
- La clave de la secuencia interna (`innerKeySelector`).
- La clave de la secuencia externa (`outerKeySelector`).
- Un selector de resultados (`resultSelector`) que especifica cómo se deben combinar los elementos de las dos secuencias para formar el resultado final.
- Es importante tener en cuenta que `Join()` es una operación que puede ser costosa, especialmente si las secuencias son grandes, ya que implica comparar cada elemento de una secuencia con cada elemento de la otra secuencia.