# Composition

Una clase puede tener objetos de tipos de valores o referencias a objetos de otras clases como miembros. Esto se llama composici�n y a veces se refiere como una relaci�n de "tiene-un". Por ejemplo, un objeto de la clase RelojDespertador necesita conocer la hora actual y la hora en que se supone que debe sonar la alarma, por lo que es razonable incluir dos referencias a objetos de Tiempo en un objeto de `AlarmClock`.

### Constructor

El constructor (l�neas 13�19) recibe tres ints. La l�nea 15 invoca el accesor `set` de la propiedad `Month` (l�neas 28�37) para validar el mes; si el valor est� fuera de rango, el accesor arroja una excepci�n. La l�nea 16 utiliza la propiedad `Year` para establecer el a�o. Dado que `Year` es una propiedad de auto-implementaci�n, no proporciona validaci�n; estamos asumiendo en este ejemplo que el valor de Year es correcto. 
La l�nea 17 utiliza el accesor `set` de la propiedad `Day` (l�neas 47�67) para validar y asignar el valor del d�a basado en el Mes y el A�o actual (usando las propiedades Month y Year a su vez para obtener los valores de mes y a�o).
El orden de inicializaci�n es importante, porque el accesor `set` de la propiedad `Day` realiza su validaci�n asumiendo que `Month` y `Year` son correctos. La l�nea 53 determina si el d�a est� fuera de rango, bas�ndose en el n�mero de d�as en el Mes, y si es as�, arroja una excepci�n. Las l�neas 59�60 determinan si el Mes es febrero, el d�a es 29 y el A�o no es un a�o bisiesto (en cuyo caso, 29 est� fuera de rango) y, si es as�, arroja una excepci�n. 
Si no se lanzan excepciones, el valor del d�a es correcto y se asigna a la variable de instancia en la l�nea 66. La l�nea 18 en el constructor formatea la referencia `this` como una cadena. 
Dado que `this` es una referencia al objeto Date actual, el m�todo `ToString` del objeto (l�nea 71) se llama impl�citamente para obtener la representaci�n de cadena de la fecha.

### private set accessor

La clase `Date` utiliza modificadores de acceso para garantizar que los clientes de la clase deben utilizar los m�todos y propiedades apropiados para acceder a los datos privados. En particular, las propiedades `Year`, `Month` y `Day` declaran accesores `set` privados (l�neas 9, 28 y 47, respectivamente): estos accesores `set` solo pueden ser utilizados dentro de la clase. 
Declaramos estos como privados por las mismas razones por las que declaramos las variables de instancia como privadas: para simplificar el mantenimiento del c�digo y controlar el acceso a los datos de la clase. Aunque el constructor, m�todo y propiedades en la clase `Date` todav�a tienen todas las ventajas de usar los accesores `set` para realizar validaciones, los clientes de la clase deben usar el constructor de la clase para inicializar los datos en un objeto `Date`. 
Los accesores `get` de `Year`, `Month` y `Day` son impl�citamente p�blicos: cuando no hay un modificador de acceso antes de un accesor `get` o `set`, se utiliza el modificador de acceso de la propiedad.

