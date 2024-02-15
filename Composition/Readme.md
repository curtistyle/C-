# Composition

Una clase puede tener objetos de tipos de valores o referencias a objetos de otras clases como miembros. Esto se llama composición y a veces se refiere como una relación de "tiene-un". Por ejemplo, un objeto de la clase RelojDespertador necesita conocer la hora actual y la hora en que se supone que debe sonar la alarma, por lo que es razonable incluir dos referencias a objetos de Tiempo en un objeto de `AlarmClock`.

### Constructor

El constructor (líneas 13–19) recibe tres ints. La línea 15 invoca el accesor `set` de la propiedad `Month` (líneas 28–37) para validar el mes; si el valor está fuera de rango, el accesor arroja una excepción. La línea 16 utiliza la propiedad `Year` para establecer el año. Dado que `Year` es una propiedad de auto-implementación, no proporciona validación; estamos asumiendo en este ejemplo que el valor de Year es correcto. 
La línea 17 utiliza el accesor `set` de la propiedad `Day` (líneas 47–67) para validar y asignar el valor del día basado en el Mes y el Año actual (usando las propiedades Month y Year a su vez para obtener los valores de mes y año).
El orden de inicialización es importante, porque el accesor `set` de la propiedad `Day` realiza su validación asumiendo que `Month` y `Year` son correctos. La línea 53 determina si el día está fuera de rango, basándose en el número de días en el Mes, y si es así, arroja una excepción. Las líneas 59–60 determinan si el Mes es febrero, el día es 29 y el Año no es un año bisiesto (en cuyo caso, 29 está fuera de rango) y, si es así, arroja una excepción. 
Si no se lanzan excepciones, el valor del día es correcto y se asigna a la variable de instancia en la línea 66. La línea 18 en el constructor formatea la referencia `this` como una cadena. 
Dado que `this` es una referencia al objeto Date actual, el método `ToString` del objeto (línea 71) se llama implícitamente para obtener la representación de cadena de la fecha.

### private set accessor

La clase `Date` utiliza modificadores de acceso para garantizar que los clientes de la clase deben utilizar los métodos y propiedades apropiados para acceder a los datos privados. En particular, las propiedades `Year`, `Month` y `Day` declaran accesores `set` privados (líneas 9, 28 y 47, respectivamente): estos accesores `set` solo pueden ser utilizados dentro de la clase. 
Declaramos estos como privados por las mismas razones por las que declaramos las variables de instancia como privadas: para simplificar el mantenimiento del código y controlar el acceso a los datos de la clase. Aunque el constructor, método y propiedades en la clase `Date` todavía tienen todas las ventajas de usar los accesores `set` para realizar validaciones, los clientes de la clase deben usar el constructor de la clase para inicializar los datos en un objeto `Date`. 
Los accesores `get` de `Year`, `Month` y `Day` son implícitamente públicos: cuando no hay un modificador de acceso antes de un accesor `get` o `set`, se utiliza el modificador de acceso de la propiedad.

