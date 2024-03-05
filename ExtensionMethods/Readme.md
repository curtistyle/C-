## Clase de Caso de Estudio Time: Métodos de Extensión

Puedes utilizar métodos de extensión para añadir funcionalidad a un tipo existente sin modificar el código fuente del tipo. Viste en la Sección 9.3.3 que las capacidades de LINQ están implementadas como métodos de extensión. La Figura 10.16 utiliza métodos de extensión para añadir dos nuevos métodos a la clase Time2 (Sección 10.5) - `DisplayTime` y `AddHours`.

### Método de Extensión `DisplayTime`

El método de extensión `DisplayTime` (líneas 35–38) muestra la representación de cadena del tiempo. La característica clave del método `DisplayTime` es la palabra clave `this` que precede al parámetro `Time2` en la cabecera del método (línea 35) - esto notifica al compilador que `DisplayTime` es un método de extensión para una clase existente (`Time2`). El tipo del primer parámetro de un método de extensión especifica el tipo de objeto sobre el cual se puede llamar al método, por esta razón, *cada método de extensión debe definir al menos un parámetro*. Además, los métodos de extensión deben definirse como métodos estáticos (`static`) en una clase estática como `TimeExtensions` (líneas 32–53). **Una clase estática solo puede contener miembros estáticos y no puede ser instanciada**.

### Llamada al Método de Extensión `DisplayTime`

La línea 14 utiliza el objeto `Time2 myTime` para llamar al método de extensión `DisplayTime`. Observa que no proporcionamos un argumento para la llamada al método. El compilador pasa implícitamente el objeto que llama al método (`myTime`) como el primer argumento del método de extensión. Esto te permite llamar a `DisplayTime` como si fuera un método de instancia de `Time2`.

La flecha hacia abajo en el icono denota un método de extensión. Además, cuando seleccionas un método de extensión en la ventana de **IntelliSense**, la información sobre herramientas que describe el método incluye el texto (extensión) para cada método de extensión.

### Método de Extensión `AddHours`

Las líneas 42–52 se declaran el método de extensión `AddHours`. Nuevamente, la palabra clave `this` en la declaración del primer parámetro indica que `AddHours` puede ser llamado en un objeto `Time2`.
El segundo parámetro es un valor `int` que especifica la cantidad de horas que se agregarán al tiempo. El método `AddHours` devuelve un nuevo objeto `Time2` con la cantidad especificada de horas agregadas.
Las líneas 45–46 crean el nuevo objeto `Time2` y utilizan un inicializador de objetos para establecer sus propiedades `Minute` y `Second` en los valores correspondientes en el parámetro `aTime`—estos no se modifican cuando agregamos horas al tiempo. La línea 49 agrega el número de horas del segundo argumento a la propiedad `Hour` del objeto `Time2` original, luego utiliza el operador % para asegurarse de que el valor permanezca en el rango de 0 a 23. El resultado se asigna a la propiedad `Hour` del nuevo objeto `Time2`. La línea 51 devuelve el nuevo objeto `Time2` al llamante.

### Llamando al Método de Extensión `AddHours`

Línea 18 llama al método de extensión `AddHours` para agregar cinco horas al valor de hora del objeto `myTime`. Observa que la llamada al método especifica solo un argumento: la cantidad de horas a agregar. Nuevamente, el compilador pasa implícitamente el objeto que se utiliza para llamar al método (`myTime`) como el primer argumento del método de extensión. El objeto `Time2` devuelto por `AddHours` se asigna a una variable local (`timeAdded`) y se muestra en la consola utilizando el método de extensión `DisplayTime` (línea 19).

### Llamando a Ambos Métodos de Extensión en una Sola Instrucción
La línea 23 utiliza ambos métodos de extensión (`DisplayTime` y `AddHours`) en una sola instrucción para agregar 15 horas al `myTime` original y mostrar el resultado en la consola. Las múltiples llamadas de método en la misma instrucción se conocen como llamadas de método en cascada. Cuando un método devuelve un objeto, puedes seguir la llamada del método con un operador de acceso a miembros (.) y luego llamar a un método en el objeto que fue devuelto. Los métodos se llaman de izquierda a derecha. En la línea 23, se llama al método `DisplayTime` en el objeto `Time2` devuelto por el método `AddHours`. Esto elimina la necesidad de asignar el objeto devuelto por `AddHours` a una variable y luego llamar a `DisplayTime` en una instrucción separada.

### Precauciones con los Métodos de Extensión
Si un tipo para el cual declaras un método de extensión ya define un método de instancia con el mismo nombre y una firma compatible, el método de instancia eclipsará (es decir, ocultará) al método de extensión. Además, si un tipo predefinido se actualiza posteriormente para incluir un método de instancia que oculta un método de extensión, el compilador no informará errores y el método de extensión no aparecerá en IntelliSense.