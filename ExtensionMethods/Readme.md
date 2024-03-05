## Clase de Caso de Estudio Time: M�todos de Extensi�n

Puedes utilizar m�todos de extensi�n para a�adir funcionalidad a un tipo existente sin modificar el c�digo fuente del tipo. Viste en la Secci�n 9.3.3 que las capacidades de LINQ est�n implementadas como m�todos de extensi�n. La Figura 10.16 utiliza m�todos de extensi�n para a�adir dos nuevos m�todos a la clase Time2 (Secci�n 10.5) - `DisplayTime` y `AddHours`.

### M�todo de Extensi�n `DisplayTime`

El m�todo de extensi�n `DisplayTime` (l�neas 35�38) muestra la representaci�n de cadena del tiempo. La caracter�stica clave del m�todo `DisplayTime` es la palabra clave `this` que precede al par�metro `Time2` en la cabecera del m�todo (l�nea 35) - esto notifica al compilador que `DisplayTime` es un m�todo de extensi�n para una clase existente (`Time2`). El tipo del primer par�metro de un m�todo de extensi�n especifica el tipo de objeto sobre el cual se puede llamar al m�todo, por esta raz�n, *cada m�todo de extensi�n debe definir al menos un par�metro*. Adem�s, los m�todos de extensi�n deben definirse como m�todos est�ticos (`static`) en una clase est�tica como `TimeExtensions` (l�neas 32�53). **Una clase est�tica solo puede contener miembros est�ticos y no puede ser instanciada**.

### Llamada al M�todo de Extensi�n `DisplayTime`

La l�nea 14 utiliza el objeto `Time2 myTime` para llamar al m�todo de extensi�n `DisplayTime`. Observa que no proporcionamos un argumento para la llamada al m�todo. El compilador pasa impl�citamente el objeto que llama al m�todo (`myTime`) como el primer argumento del m�todo de extensi�n. Esto te permite llamar a `DisplayTime` como si fuera un m�todo de instancia de `Time2`.

La flecha hacia abajo en el icono denota un m�todo de extensi�n. Adem�s, cuando seleccionas un m�todo de extensi�n en la ventana de **IntelliSense**, la informaci�n sobre herramientas que describe el m�todo incluye el texto (extensi�n) para cada m�todo de extensi�n.

### M�todo de Extensi�n `AddHours`

Las l�neas 42�52 se declaran el m�todo de extensi�n `AddHours`. Nuevamente, la palabra clave `this` en la declaraci�n del primer par�metro indica que `AddHours` puede ser llamado en un objeto `Time2`.
El segundo par�metro es un valor `int` que especifica la cantidad de horas que se agregar�n al tiempo. El m�todo `AddHours` devuelve un nuevo objeto `Time2` con la cantidad especificada de horas agregadas.
Las l�neas 45�46 crean el nuevo objeto `Time2` y utilizan un inicializador de objetos para establecer sus propiedades `Minute` y `Second` en los valores correspondientes en el par�metro `aTime`�estos no se modifican cuando agregamos horas al tiempo. La l�nea 49 agrega el n�mero de horas del segundo argumento a la propiedad `Hour` del objeto `Time2` original, luego utiliza el operador % para asegurarse de que el valor permanezca en el rango de 0 a 23. El resultado se asigna a la propiedad `Hour` del nuevo objeto `Time2`. La l�nea 51 devuelve el nuevo objeto `Time2` al llamante.

### Llamando al M�todo de Extensi�n `AddHours`

L�nea 18 llama al m�todo de extensi�n `AddHours` para agregar cinco horas al valor de hora del objeto `myTime`. Observa que la llamada al m�todo especifica solo un argumento: la cantidad de horas a agregar. Nuevamente, el compilador pasa impl�citamente el objeto que se utiliza para llamar al m�todo (`myTime`) como el primer argumento del m�todo de extensi�n. El objeto `Time2` devuelto por `AddHours` se asigna a una variable local (`timeAdded`) y se muestra en la consola utilizando el m�todo de extensi�n `DisplayTime` (l�nea 19).

### Llamando a Ambos M�todos de Extensi�n en una Sola Instrucci�n
La l�nea 23 utiliza ambos m�todos de extensi�n (`DisplayTime` y `AddHours`) en una sola instrucci�n para agregar 15 horas al `myTime` original y mostrar el resultado en la consola. Las m�ltiples llamadas de m�todo en la misma instrucci�n se conocen como llamadas de m�todo en cascada. Cuando un m�todo devuelve un objeto, puedes seguir la llamada del m�todo con un operador de acceso a miembros (.) y luego llamar a un m�todo en el objeto que fue devuelto. Los m�todos se llaman de izquierda a derecha. En la l�nea 23, se llama al m�todo `DisplayTime` en el objeto `Time2` devuelto por el m�todo `AddHours`. Esto elimina la necesidad de asignar el objeto devuelto por `AddHours` a una variable y luego llamar a `DisplayTime` en una instrucci�n separada.

### Precauciones con los M�todos de Extensi�n
Si un tipo para el cual declaras un m�todo de extensi�n ya define un m�todo de instancia con el mismo nombre y una firma compatible, el m�todo de instancia eclipsar� (es decir, ocultar�) al m�todo de extensi�n. Adem�s, si un tipo predefinido se actualiza posteriormente para incluir un m�todo de instancia que oculta un m�todo de extensi�n, el compilador no informar� errores y el m�todo de extensi�n no aparecer� en IntelliSense.