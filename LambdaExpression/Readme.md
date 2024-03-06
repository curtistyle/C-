## Expresiones Lambda

Las expresiones lambda te permiten definir m�todos simples y an�nimos, es decir, m�todos que no tienen nombres y que se definen donde se asignan a un delegado o se pasan como par�metro a un delegado. En muchos casos, trabajar con expresiones lambda puede reducir el tama�o de tu c�digo y la complejidad de trabajar con delegados. Como ver�s en ejemplos posteriores, las **expresiones** `lambda` son particularmente poderosas cuando se combinan con la cl�usula `where` en consultas `LINQ`. El codigo 19.7 reimplementa el ejemplo del codigo 19.6 usando expresiones `lambda` en lugar de *m�todos expl�citamente* declarados como `IsEven`, `IsOdd` e `IsOver5`.

### 19.9.1 Expresiones Lambda de Expresi�n
Una expresi�n lambda (l�nea 17)

```Csharp
	number => number % 2 == 0
```

comienza con una lista de par�metros (`number` en este caso). La lista de par�metros es seguida por el operador lambda `=>` (*le�do como "va a"*) y una expresi�n que representa el cuerpo de la lambda. La expresi�n lambda en la l�nea 17 usa el operador `%` para determinar si el valor del par�metro `number` es un entero par. El valor producido por la expresi�n, `true` si el entero es par, `false` en caso contrario, es devuelto impl�citamente por la expresi�n lambda. La lambda en la l�nea 17 se llama una expresi�n lambda, porque tiene una sola expresi�n a la derecha del operador lambda. Observa que no especificamos un tipo de retorno para la expresi�n lambda, el **tipo de retorno se infiere a partir del valor de retorno** o, en algunos casos, **del tipo de retorno de un delegado**. La expresi�n lambda en la l�nea 17 es equivalente al m�todo `IsEven` del codigo 19.6. Observa que los m�todos de cuerpo de expresi�n de C# 6 usan una sintaxis similar a las expresiones lambda, incluido el operador lambda (`=>`).

### 19.9.2 Asignaci�n de Lambdas a Variables de Delegado
En la l�nea 17 del coidgo 19.7, la expresi�n lambda se asigna a una variable del tipo `NumberPredicate`, el tipo de delegado declarado en la l�nea 9. **Un delegado puede contener una referencia a una expresi�n lambda**. Al igual que con los m�todos tradicionales, un m�todo definido por una expresi�n lambda debe tener una firma que sea compatible con el tipo de delegado. El delegado `NumberPredicate` puede contener una referencia a cualquier m�todo que reciba un entero y devuelva un booleano. Bas�ndose en esto, el compilador puede inferir que la expresi�n lambda en la l�nea 17 define un m�todo que impl�citamente toma un `int` como argumento y devuelve un resultado `bool` de la expresi�n en su cuerpo.
Las l�neas 20 muestran el resultado de llamar a la expresi�n lambda definida en la l�nea 17. La expresi�n lambda se llama a trav�s de la variable que la referencia (`evenPredicate`). La l�nea 23 pasa `evenPredicate` al m�todo `FilterArray` (l�neas 42�58), que es id�ntico al m�todo utilizado en el codigo 19.6: utiliza el delegado `NumberPredicate` para determinar si un elemento del array debe incluirse en el resultado. Las l�neas 26 muestran los resultados filtrados.

### 19.9.3 Par�metros de Lambda con Tipos Expl�citos
Las expresiones lambda se utilizan frecuentemente como argumentos para m�todos con par�metros de tipo delegado, en lugar de definir y referenciar un m�todo separado o definir una variable de delegado que haga referencia a una lambda. La linea 29 seleccionan los elementos impares del array con la lambda 

```
	(int n�mero) => n�mero % 2 == 1
```

En este caso, la lambda se pasa directamente al m�todo `FilterArray` y se almacena impl�citamente en el par�metro de delegado `NumberPredicate`.
El par�metro de entrada de la expresi�n lambda, `number`, se tipifica expl�citamente como un `int` aqu�, a veces esto es necesario para evitar ambig�edades que podr�an provocar errores de compilaci�n (aunque no es el caso aqu�). Cuando se especifica el tipo de par�metro de una lambda y/o cuando una lambda tiene m�s de un par�metro, debes encerrar la lista de par�metros entre par�ntesis como en la l�nea 29. La expresi�n lambda en la l�nea 29 es equivalente al m�todo `IsOdd` definido en el codigo 19.6. Las l�neas 32 de del codigo 19.7 muestran los resultados filtrados.

### 19.9.4 Expresiones Lambda de Sentencia
Las l�neas 35 utilizan la lambda

```Csharp
	number => {return number > 5;}
```

para encontrar los enteros mayores que 5 en el array y almacenar los resultados. Esta lambda es equivalente al m�todo `IsOver5` en la codigo 19.6.
La lambda anterior se llama **lambda de sentencia** (*statement lambda*), porque contiene un bloque de sentencias, una o m�s sentencias encerradas entre llaves ({}) a la derecha del operador lambda. La firma de esta lambda es compatible con el delegado `NumberPredicate`, porque se infiere que el tipo del par�metro `number` es `int` y la sentencia en la lambda devuelve un `bool`. Para obtener informaci�n adicional sobre lambdas, visita

https://msdn.microsoft.com/library/bb397687

