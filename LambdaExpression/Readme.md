## Expresiones Lambda

Las expresiones lambda te permiten definir métodos simples y anónimos, es decir, métodos que no tienen nombres y que se definen donde se asignan a un delegado o se pasan como parámetro a un delegado. En muchos casos, trabajar con expresiones lambda puede reducir el tamaño de tu código y la complejidad de trabajar con delegados. Como verás en ejemplos posteriores, las **expresiones** `lambda` son particularmente poderosas cuando se combinan con la cláusula `where` en consultas `LINQ`. El codigo 19.7 reimplementa el ejemplo del codigo 19.6 usando expresiones `lambda` en lugar de *métodos explícitamente* declarados como `IsEven`, `IsOdd` e `IsOver5`.

### 19.9.1 Expresiones Lambda de Expresión
Una expresión lambda (línea 17)

```Csharp
	number => number % 2 == 0
```

comienza con una lista de parámetros (`number` en este caso). La lista de parámetros es seguida por el operador lambda `=>` (*leído como "va a"*) y una expresión que representa el cuerpo de la lambda. La expresión lambda en la línea 17 usa el operador `%` para determinar si el valor del parámetro `number` es un entero par. El valor producido por la expresión, `true` si el entero es par, `false` en caso contrario, es devuelto implícitamente por la expresión lambda. La lambda en la línea 17 se llama una expresión lambda, porque tiene una sola expresión a la derecha del operador lambda. Observa que no especificamos un tipo de retorno para la expresión lambda, el **tipo de retorno se infiere a partir del valor de retorno** o, en algunos casos, **del tipo de retorno de un delegado**. La expresión lambda en la línea 17 es equivalente al método `IsEven` del codigo 19.6. Observa que los métodos de cuerpo de expresión de C# 6 usan una sintaxis similar a las expresiones lambda, incluido el operador lambda (`=>`).

### 19.9.2 Asignación de Lambdas a Variables de Delegado
En la línea 17 del coidgo 19.7, la expresión lambda se asigna a una variable del tipo `NumberPredicate`, el tipo de delegado declarado en la línea 9. **Un delegado puede contener una referencia a una expresión lambda**. Al igual que con los métodos tradicionales, un método definido por una expresión lambda debe tener una firma que sea compatible con el tipo de delegado. El delegado `NumberPredicate` puede contener una referencia a cualquier método que reciba un entero y devuelva un booleano. Basándose en esto, el compilador puede inferir que la expresión lambda en la línea 17 define un método que implícitamente toma un `int` como argumento y devuelve un resultado `bool` de la expresión en su cuerpo.
Las líneas 20 muestran el resultado de llamar a la expresión lambda definida en la línea 17. La expresión lambda se llama a través de la variable que la referencia (`evenPredicate`). La línea 23 pasa `evenPredicate` al método `FilterArray` (líneas 42–58), que es idéntico al método utilizado en el codigo 19.6: utiliza el delegado `NumberPredicate` para determinar si un elemento del array debe incluirse en el resultado. Las líneas 26 muestran los resultados filtrados.

### 19.9.3 Parámetros de Lambda con Tipos Explícitos
Las expresiones lambda se utilizan frecuentemente como argumentos para métodos con parámetros de tipo delegado, en lugar de definir y referenciar un método separado o definir una variable de delegado que haga referencia a una lambda. La linea 29 seleccionan los elementos impares del array con la lambda 

```
	(int número) => número % 2 == 1
```

En este caso, la lambda se pasa directamente al método `FilterArray` y se almacena implícitamente en el parámetro de delegado `NumberPredicate`.
El parámetro de entrada de la expresión lambda, `number`, se tipifica explícitamente como un `int` aquí, a veces esto es necesario para evitar ambigüedades que podrían provocar errores de compilación (aunque no es el caso aquí). Cuando se especifica el tipo de parámetro de una lambda y/o cuando una lambda tiene más de un parámetro, debes encerrar la lista de parámetros entre paréntesis como en la línea 29. La expresión lambda en la línea 29 es equivalente al método `IsOdd` definido en el codigo 19.6. Las líneas 32 de del codigo 19.7 muestran los resultados filtrados.

### 19.9.4 Expresiones Lambda de Sentencia
Las líneas 35 utilizan la lambda

```Csharp
	number => {return number > 5;}
```

para encontrar los enteros mayores que 5 en el array y almacenar los resultados. Esta lambda es equivalente al método `IsOver5` en la codigo 19.6.
La lambda anterior se llama **lambda de sentencia** (*statement lambda*), porque contiene un bloque de sentencias, una o más sentencias encerradas entre llaves ({}) a la derecha del operador lambda. La firma de esta lambda es compatible con el delegado `NumberPredicate`, porque se infiere que el tipo del parámetro `number` es `int` y la sentencia en la lambda devuelve un `bool`. Para obtener información adicional sobre lambdas, visita

https://msdn.microsoft.com/library/bb397687

