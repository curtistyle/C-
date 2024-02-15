# Sobrecarga de operadores; Introducci�n a las `struct`

La notaci�n de llamada a m�todo puede ser engorrosa para ciertos tipos de operaciones, como las operaciones aritm�ticas. En estos casos, ser�a conveniente utilizar el conjunto rico de operadores integrados de C# en su lugar.
Esta secci�n muestra c�mo crear operadores que funcionan con objetos de sus propios tipos, a trav�s de un proceso llamado sobrecarga de operadores.
Puede sobrecargar la mayor�a de los operadores. Algunos se sobrecargan con m�s frecuencia que otros, especialmente los operadores aritm�ticos, como + y -, donde la notaci�n de operador es m�s natural que llamar a m�todos. Para ver una lista de operadores sobrecargables, consulte https://msdn.microsoft.com/library/8edha89s

### Cu�ndo declarar un tipo struct

Microsoft recomienda usar clases para la mayor�a de los tipos nuevos, pero recomienda una estructura (struct) si:

- El tipo representa un �nico valor: un n�mero complejo representa un solo n�mero que tiene una parte real y una parte imaginaria.
- El tama�o de un objeto es de 16 bytes o menos: representaremos las partes real e imaginaria de un n�mero complejo usando dos valores de tipo double (un total de 16 bytes).


