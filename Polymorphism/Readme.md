## Introducci�n

Continuamos nuestro estudio de la programaci�n orientada a objetos explicando y demostrando el polimorfismo con jerarqu�as de herencia. El polimorfismo nos permite programar en lo general en lugar de programar en lo espec�fico. En particular, el polimorfismo nos permite escribir aplicaciones que procesan objetos que comparten la misma clase base en una jerarqu�a de clases como si fueran todos objetos de la clase base.

Consideremos un ejemplo de polimorfismo. Supongamos que creamos una aplicaci�n que simula el movimiento de varios tipos de animales para un estudio biol�gico. Las clases `Fish`, `Frog` y `Bird` representan los tipos de animales bajo investigaci�n. Imaginemos que cada clase extiende la clase base `Animal`, que contiene un m�todo `Move` y mantiene la ubicaci�n actual del animal como coordenadas x-y-z. Cada clase derivada implementa el m�todo `Move` de manera diferente. Nuestra aplicaci�n mantiene una colecci�n de referencias a objetos de las diversas clases derivadas de `Animal`. Para simular los movimientos de un animal, la aplicaci�n env�a a cada objeto el mismo mensaje una vez por segundo, es decir, `Move`. Cada tipo espec�fico de `Animal` responde a un mensaje `Move` de manera �nica: un `Fish` podr�a nadar tres pies, una `Frog` podr�a saltar cinco pies y un `Bird` podr�a volar 10 pies.

La aplicaci�n emite el mensaje `Move` a cada objeto animal de forma gen�rica, pero cada objeto modifica sus coordenadas x-y-z de manera apropiada para su tipo espec�fico de movimiento. Confiar en que cada objeto "haga lo correcto" en respuesta a la misma llamada de m�todo es el concepto clave del polimorfismo. El *mismo mensaje* (en este caso, `Move`) enviado a una variedad de objetos tiene muchas formas de resultados, de ah� el t�rmino polimorfismo.


## Los sistemas son f�ciles de extender
Con el polimorfismo, podemos dise�ar e implementar sistemas que son f�cilmente extensibles: nuevas clases pueden ser agregadas con poca o ninguna modificaci�n a las partes polim�rficas de la aplicaci�n, siempre y cuando las nuevas clases formen parte de la jerarqu�a de herencia que la aplicaci�n procesa de manera gen�rica. Las �nicas partes de una aplicaci�n que deben ser alteradas para acomodar nuevas clases son aquellas que requieren conocimiento directo de las nuevas clases que agregas a la jerarqu�a. Por ejemplo, si extendemos la clase `Animal` para crear la clase `Tortuga` (que podr�a responder a un mensaje de Movimiento arrastr�ndose una pulgada), solo necesitamos escribir la clase `Tortuga` y la parte de la simulaci�n que instancia un objeto `Tortuga`. Las partes de la simulaci�n que procesan cada `Animal` de manera gen�rica pueden permanecer iguales.

## Jerarqu�a de Herencia de Empleados Polim�rficos
A continuaci�n, presentamos un estudio de caso que revisita la jerarqu�a de `Employee`. Desarrollamos una aplicaci�n de n�mina simple que calcula de manera polim�rfica el pago semanal de varios tipos diferentes de empleados utilizando el m�todo de `Earnings` de cada empleado. Aunque las ganancias de cada tipo de empleado se calculan de una manera espec�fica, el polimorfismo nos permite procesar a los empleados *"en general"*. En el estudio de caso, ampliamos la jerarqu�a para incluir dos nuevas clases: SalariedEmployee (para personas que reciben un salario semanal fijo) y `HourlyEmployee` (para personas que reciben un salario por hora y "tiempo y medio" por horas extras). Declaramos un conjunto com�n de funcionalidades para todas las clases en la jerarqu�a actualizada en una clase base `Empleado` de la cual las clases `SalariedEmployee`, `HourlyEmployee` y `CommissionEmployee` heredan directamente y la clase `BasePlusCommissionEmployee` hereda indirectamente. Como pronto ver�s, cuando invocamos el m�todo de `Earnings` de cada empleado a trav�s de una referencia de clase base `Employee`, se realiza el c�lculo correcto de ganancias debido a las capacidades polim�rficas de C#.

## Determinar el Tipo de un Objeto en Tiempo de Ejecuci�n

En ocasiones, al realizar un procesamiento polim�rfico, necesitamos programar *"de manera espec�fica"*. Nuestro estudio de caso de Empleados demuestra que una aplicaci�n puede determinar el tipo de un objeto en tiempo de ejecuci�n y actuar en consecuencia. En el estudio de caso, utilizamos estas capacidades para determinar si un objeto de empleado en particular es un `BasePlusCommissionEmployee`. Si es as�, aumentamos el salario base de ese empleado en un 10%.

## Interfaces

Una interfaz describe un conjunto de m�todos y propiedades que pueden ser llamados en un objeto, pero no proporciona implementaciones concretas para ellos. Puedes declarar clases que implementen (es decir, proporcionen implementaciones concretas para los m�todos y propiedades de) una o m�s interfaces. Cada miembro de la interfaz debe ser definido para todas las clases que implementan la interfaz. Una vez que una clase implementa una interfaz, todos los objetos de esa clase tienen una relaci�n de "es un" con el tipo de interfaz, y todos los objetos de la clase est�n garantizados de proporcionar la funcionalidad descrita por la interfaz. Esto tambi�n es v�lido para todas las clases derivadas de esa clase.

Las interfaces son particularmente �tiles para asignar funcionalidades comunes a clases posiblemente no relacionadas. Esto permite que los objetos de clases no relacionadas sean procesados polim�rficamente: los objetos de clases que implementan la misma interfaz pueden responder a las mismas llamadas de m�todo. Para demostrar la creaci�n y el uso de interfaces, modificamos nuestra aplicaci�n de n�mina para crear una aplicaci�n general de cuentas por pagar que pueda calcular los pagos adeudados por las ganancias de los empleados de la empresa y los montos de facturas a facturar por bienes comprados. Como ver�s, las interfaces habilitan capacidades polim�rficas similares a las habilitadas por la herencia.

## Ejemplos de Polimorfismo

Consideremos varios ejemplos adicionales de polimorfismo.

### Jerarqu�a de Herencia de Cuadril�teros
Si la clase `Rect�ngulo` se deriva de la clase `Cuadril�tero` (una figura de cuatro lados), entonces un `Rect�ngulo` es una versi�n m�s espec�fica de un `Cuadril�tero`. Cualquier operaci�n (por ejemplo, calcular el per�metro o el �rea) que se pueda realizar en un objeto `Cuadril�tero` tambi�n se puede realizar en un objeto `Rect�ngulo`. Estas operaciones tambi�n se pueden realizar en otros `Cuadril�teros`, como `Cuadrados`, `Paralelogramos` y `Trapecios`. El polimorfismo ocurre cuando una aplicaci�n invoca un m�todo a trav�s de una variable de clase base; en tiempo de ejecuci�n, se llama a la versi�n del m�todo de la clase derivada correcta, seg�n el tipo del objeto referenciado. 

## Jerarqu�a de Herencia de Objetos Espaciales de Videojuegos

Como otro ejemplo, supongamos que dise�amos un videojuego que manipula objetos de muchos tipos diferentes, incluidos objetos de las clases `Martian`, `Venusian`, `Plutonian`, `SpaceShip` y `LaserBeam`. Imagina que cada clase hereda de la clase base com�n `SpaceObject`, que contiene el m�todo `Draw`. Cada clase derivada implementa este m�todo. Una aplicaci�n de gesti�n de pantalla mantiene una colecci�n (por ejemplo, un array de `SpaceObject`) de referencias a objetos de las diversas clases. Para refrescar la pantalla, el gestor de pantalla env�a peri�dicamente a cada objeto el mismo mensaje, es decir, `Draw`. Sin embargo, cada objeto responde de manera �nica. Por ejemplo, un objeto `Martian` podr�a dibujarse a s� mismo en rojo con el n�mero apropiado de antenas. Una `SpaceShip` podr�a dibujarse a s� misma como un platillo volador plateado brillante. Un `LaserBeam` podr�a dibujarse a s� mismo como un haz rojo brillante a trav�s de la pantalla. Nuevamente, el mismo mensaje (en este caso, `Draw`) enviado a una variedad de objetos tiene muchas formas de resultados.
Un gestor de pantalla podr�a usar el polimorfismo para facilitar la adici�n de nuevas clases a un sistema con modificaciones m�nimas en el c�digo del sistema. Supongamos que queremos agregar objetos `Mercurian` a nuestro videojuego. Para hacerlo, debemos construir una clase `Mercurian` que extienda `SpaceObject` y proporcione su propia implementaci�n del m�todo `Draw`. Cuando los objetos de la clase `Mercurian` aparecen en la colecci�n de `SpaceObject`, el c�digo del gestor de pantalla invoca el m�todo `Draw`, exactamente como lo hace para cualquier otro objeto en la colecci�n, independientemente de su tipo, por lo que los nuevos objetos `Mercurian` simplemente "se integran" sin ninguna modificaci�n del c�digo del gestor de pantalla por parte del programador. As�, sin modificar el sistema (excepto para construir nuevas clases y modificar el c�digo que crea nuevos objetos), puedes usar el polimorfismo para incluir tipos adicionales que quiz�s no se hayan previsto cuando se cre� el sistema.

## Demostraci�n del Comportamiento Polim�rfico

En la seccion anterior cre� una jerarqu�a de clases de empleados por comisi�n, en la que la clase `BasePlusCommissionEmployee` heredaba de la clase `CommissionEmployee`. Los ejemplos en esa secci�n manipulaban objetos `CommissionEmployee` y `BasePlusCommissionEmployee` utilizando referencias para invocar sus m�todos. Apunt�bamos referencias de clase base a objetos de clase base y referencias de clase derivada a objetos de clase derivada. Estas asignaciones son naturales y directas: las referencias de clase base est�n destinadas a referirse a objetos de clase base, y las referencias de clase derivada est�n destinadas a referirse a objetos de clase derivada. Sin embargo, otras asignaciones son posibles.

El siguiente ejemplo apunta una referencia de clase base a un objeto de clase derivada, luego muestra c�mo invocar un m�todo en un objeto de clase derivada a trav�s de una referencia de clase base invoca la funcionalidad de la clase derivada: el tipo del objeto referenciado real, no el tipo de la referencia, determina qu� m�todo se llama. Esto demuestra el concepto clave de que un objeto de clase derivada puede tratarse como un objeto de su clase base, lo que permite varias manipulaciones interesantes.

Una aplicaci�n puede crear una colecci�n de referencias de clase base que se refieran a objetos de muchos tipos de clase derivada, porque cada objeto de clase derivada es un objeto de su clase base. Por ejemplo, podemos asignar la referencia de un objeto `BasePlusCommissionEmployee` a una variable de clase base `CommissionEmployee` porque un `BasePlusCommissionEmployee` es un `CommissionEmployee`, por lo que podemos tratar un `BasePlusCommissionEmployee` como un `CommissionEmployee`.

Un objeto de clase base no es un objeto de ninguna de sus clases derivadas. Por ejemplo, no podemos asignar directamente la referencia de un objeto `CommissionEmployee` a una variable de clase derivada `BasePlusCommissionEmployee`, porque un `CommissionEmployee` no es un `BasePlusCommissionEmployee`: un `CommissionEmployee` no tiene, por ejemplo, una variable de instancia `baseSalary` ni una propiedad `BaseSalary`. El compilador permite la asignaci�n de una referencia de clase base a una variable de clase derivada si convertimos expl�citamente la referencia de clase base al tipo de clase derivada.

El codigo 12.1 demuestra tres formas de usar variables de clase base y clase derivada para almacenar referencias a objetos de clase base y clase derivada. Las dos primeras son directas, como en la Secci�n 11.4: asignamos una referencia de clase base a una variable de clase base y asignamos una referencia de clase derivada a una variable de clase derivada. Luego, demostramos la relaci�n entre las clases derivadas y las clases base (es decir, la relaci�n es-un) al asignar una referencia de clase derivada a una variable de clase base. [Nota: Esta aplicaci�n utiliza las clases `CommissionEmployee` y `BasePlusCommissionEmployee` de las Figuras 11.10 y 11.11, respectivamente.]

En el codigo 12.1 , las l�neas 11�12 crean un nuevo objeto `CommissionEmployee` y asignan su referencia a una variable `CommissionEmployee`, y las l�neas 15�16 crean un nuevo objeto `BasePlusCommissionEmployee` y asignan su referencia a una variable `BasePlusCommissionEmployee`.

Estas asignaciones son naturales; el prop�sito principal de una variable `CommissionEmployee` es contener una referencia a un objeto `CommissionEmployee`. Las l�neas 23�24 utilizan la referencia `commissionEmployee` para invocar los m�todos `ToString` y `Earnings`. Debido a que `commissionEmployee` se refiere a un objeto `CommissionEmployee`, se llaman a la versi�n de los m�todos de la clase base `CommissionEmployee`. De manera similar, las l�neas 31�33 utilizan la referencia `basePlusCommissionEmployee` para invocar los m�todos `ToString` y `Earnings` en el objeto `BasePlusCommissionEmployee`. Esto llama a la versi�n de los m�todos de la clase derivada `BasePlusCommissionEmployee`.

Luego, la l�nea 37 asigna la referencia al objeto de la clase derivada `basePlusCommissionEmployee` a una variable de la clase base `CommissionEmployee`, que las l�neas 41�43 utilizan para invocar los m�todos `ToString` y `Earnings`. Nota que la llamada `commissionEmployee2.ToString()` en la l�nea 41 realmente llama al m�todo `ToString` de la clase derivada `BasePlusCommissionEmployee`.

El compilador permite este "cruce" porque un objeto de una clase derivada es un objeto de su clase base (pero no viceversa). Cuando el compilador encuentra una llamada de m�todo virtual realizada a trav�s de una variable, verifica el tipo de clase de la variable para determinar si se puede llamar al m�todo. Si esa clase contiene la declaraci�n de m�todo adecuada (o hereda una), la llamada se compila. En tiempo de ejecuci�n, el tipo de objeto al que se refiere la variable determina el m�todo real a utilizar.
