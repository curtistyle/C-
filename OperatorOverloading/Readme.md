# Sobrecarga de operadores; Introducción a las `struct`

La notación de llamada a método puede ser engorrosa para ciertos tipos de operaciones, como las operaciones aritméticas. En estos casos, sería conveniente utilizar el conjunto rico de operadores integrados de C# en su lugar.
Esta sección muestra cómo crear operadores que funcionan con objetos de sus propios tipos, a través de un proceso llamado sobrecarga de operadores.
Puede sobrecargar la mayoría de los operadores. Algunos se sobrecargan con más frecuencia que otros, especialmente los operadores aritméticos, como + y -, donde la notación de operador es más natural que llamar a métodos. Para ver una lista de operadores sobrecargables, consulte https://msdn.microsoft.com/library/8edha89s

### Cuándo declarar un tipo struct

Microsoft recomienda usar clases para la mayoría de los tipos nuevos, pero recomienda una estructura (struct) si:

- El tipo representa un único valor: un número complejo representa un solo número que tiene una parte real y una parte imaginaria.
- El tamaño de un objeto es de 16 bytes o menos: representaremos las partes real e imaginaria de un número complejo usando dos valores de tipo double (un total de 16 bytes).


