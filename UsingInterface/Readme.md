# Caso de estudio: Creaci�n y uso de interfaces

Nuestro pr�ximo ejemplo  reexamina el sistema de n�mina de la Secci�n Anterior. Supongamos que la empresa involucrada desea realizar varias operaciones contables en una �nica aplicaci�n de cuentas por pagar. Adem�s de calcular las ganancias (`Emplyee.Earnings()`) de la n�mina que deben pagarse a cada empleado, la empresa tambi�n debe calcular el pago debido en cada una de varias facturas (es decir, las facturas por los bienes adquiridos). Aunque se aplican a cosas no relacionadas (es decir, empleados y facturas), ambas operaciones tienen que ver con el c�lculo de alg�n tipo de cantidad de pago. Para un empleado, el pago se refiere a las ganancias del empleado. Para una factura, el pago se refiere al costo total de los bienes enumerados en la factura. �Podemos calcular cosas tan diferentes como los pagos adeudados a empleados y facturas de forma polim�rfica en una sola aplicaci�n? �Existe una capacidad que pueda requerir que clases no relacionadas implementen un conjunto de m�todos comunes (por ejemplo, un m�todo que calcule una cantidad de pago)? Las interfaces ofrecen exactamente esta capacidad.

### Interacciones Estandarizadas

Las interfaces definen y estandarizan las formas en que las personas y los sistemas pueden interactuar entre s�. Por ejemplo, los controles en una radio sirven como una interfaz entre los usuarios de la radio y sus componentes internos. Los controles permiten a los usuarios realizar un conjunto limitado de operaciones (por ejemplo, cambiar la estaci�n, ajustar el volumen, elegir entre AM y FM), y diferentes radios pueden implementar los controles de diferentes formas (por ejemplo, usando botones, diales, comandos de voz). La interfaz especifica qu� operaciones debe permitir realizar una radio a los usuarios, pero no especifica c�mo se realizan. De manera similar, la interfaz entre un conductor y un autom�vil con transmisi�n manual incluye el volante, la palanca de cambios, el pedal del embrague, el pedal del acelerador y el pedal de freno. Esta misma interfaz se encuentra en casi todos los autom�viles de transmisi�n manual, lo que permite a alguien que sabe c�mo conducir un autom�vil de transmisi�n manual en particular, conducir pr�cticamente cualquier otro. Los componentes de cada autom�vil pueden verse un poco diferentes, pero el prop�sito general es el mismo: permitir que las personas conduzcan el autom�vil.

### Interfaces en Software

Los objetos de software tambi�n se comunican a trav�s de interfaces. Una interfaz en C# describe un conjunto de m�todos y propiedades que pueden ser llamados en un objeto, por ejemplo, para indicarle que realice alguna tarea o devuelva cierta informaci�n. El siguiente ejemplo presenta una interfaz llamada `IPayable` que describe la funcionalidad de cualquier objeto que debe ser capaz de ser pagado y, por lo tanto, debe ofrecer un m�todo para determinar el monto de pago adecuado que se debe pagar. Una declaraci�n de interfaz comienza con la palabra clave interface y solo puede contener lo siguiente:
	- m�todos abstractos,
	- propiedades abstractas,
	- indexadores abstractos (no cubiertos en este libro), y
	- eventos abstractos (los eventos se discuten en el Cap�tulo 14, Interfaces Gr�ficas de Usuario con Windows Forms: Parte 1).

Todos los miembros de la interfaz se declaran impl�citamente como `piblic` y `abstract`. Adem�s, cada interfaz puede extender una o m�s interfaces adicionales para crear una interfaz m�s elaborada que otras clases pueden implementar.

### Implementar una Interfaz

Una clase debe especificar que **implementa** la interfaz al listar el nombre de la interfaz despu�s de los dos puntos (:) en la declaraci�n de la clase. Esta es la misma sintaxis utilizada para indicar la herencia de una clase base. Una clase concreta que implementa la interfaz debe declarar cada miembro de la interfaz con la firma especificada en la declaraci�n de la interfaz. Una clase que implementa una interfaz pero no implementa todos sus miembros es una clase `abstract`, debe declararse `abstract` y debe contener una declaraci�n `abstract` para cada miembro no implementado de la interfaz. Implementar una interfaz es como firmar un contrato con el compilador que establece: "Proporcionar� una implementaci�n para todos los miembros especificados por la interfaz, o los declarar� abstractos".

### M�todos Comunes para Clases No Relacionadas

Una interfaz se utiliza t�picamente cuando clases no relacionadas necesitan compartir m�todos comunes. Esto permite que objetos de clases no relacionadas sean procesados de manera polim�rfica; objetos de clases que implementan la misma interfaz pueden responder a las mismas llamadas de m�todo. Puedes crear una interfaz que describa la funcionalidad deseada, luego implementar esta interfaz en cualquier clase que requiera esa funcionalidad. Por ejemplo, en la aplicaci�n de cuentas por pagar desarrollada en esta secci�n, implementamos la interfaz `IPayable` en cada clase (por ejemplo, `Employee`, `Invoice`) que debe poder calcular un monto de pago.

### Interfaces vs. Clases Abstractas
A menudo, se utiliza una interfaz en lugar de una clase abstracta cuando no hay una implementaci�n predeterminada para heredar, es decir, no hay campos ni implementaciones de m�todos por defecto. Al igual que las clases abstractas, las interfaces suelen ser tipos p�blicos, por lo que normalmente se declaran en archivos por s� mismas con el mismo nombre que la interfaz y la extensi�n de archivo .cs.

## 12.7.1 Desarrollando una Jerarqu�a `IPayable`

Para construir una aplicaci�n que pueda determinar pagos tanto para empleados como para facturas, primero creamos una interfaz llamada `IPayable`. La interfaz `IPayable` contiene el m�todo `GetPaymentAmount` que devuelve un monto decimal a pagar por un objeto de cualquier clase que implemente la interfaz. El m�todo `GetPaymentAmount` es una versi�n de prop�sito general del m�todo `Earnings` de la jerarqu�a de Empleados: el m�todo `Earnings` calcula un monto de pago espec�ficamente para un Empleado, mientras que `GetPaymentAmount` se puede aplicar a una amplia gama de objetos no relacionados. Despu�s de declarar la interfaz `IPayable`, introducimos la clase `Invoice`, que implementa la interfaz `IPayable`. Luego modificamos la clase `Employee` para que tambi�n implemente la interfaz `IPayable`.

Las clases `Invoice` y `Employe`e representan cosas para las cuales la empresa debe poder calcular un monto de pago. Ambas clases implementan `IPayable`, por lo que una aplicaci�n puede invocar el m�todo `GetPaymentAmount` en objetos de `Invoice` y `Employee` por igual. Esto permite el procesamiento polim�rfico de Facturas (`Invoice`) y Empleados (`Employee`'s) requerido para la aplicaci�n de cuentas por pagar de nuestra empresa.

## Diagrama UML que Contiene una Interfaz

El diagrama de clases UML en la Fig. 12.10 muestra la interfaz y la jerarqu�a de clases utilizadas en nuestra aplicaci�n de cuentas por pagar. La jerarqu�a comienza con la interfaz `IPayable`. La UML distingue una interfaz de una clase colocando la palabra "interfaz" entre guillemets (� y �) sobre el nombre de la interfaz. La UML expresa la relaci�n entre una clase y una interfaz a trav�s de una realizaci�n. Se dice que una clase "realiza", o implementa, una interfaz. Un diagrama de clases modela una realizaci�n como una flecha punteada con una cabeza de flecha hueca que apunta desde la clase que implementa hacia la interfaz. El diagrama en la siguiente figura indica que las clases `Invoice` y `Employee` realizan (es decir, implementan) la interfaz `IPayable`. Como en el diagrama de clases de la Fig. 12.2, la clase `Employee` aparece en cursiva, indicando que es una clase abstracta.

La clase concreta `SalariedEmployee` extiende `Employee` y hereda la relaci�n de realizaci�n de su clase base con la interfaz `IPayable`. La Figura 12.10 podr�a incluir toda la jerarqu�a de clases `Employee` de la Secci�n 12.5 - para mantener el ejemplo pr�ximo peque�o, no incluimos las clases `HourlyEmployee`, `CommissionEmployee` y `BasePlusCommissionEmployee`.

![IPayable interface and class hierarchy UML class diagram.](img/img1.png)

## 12.7.2 Declaraci�n de la Interfaz `IPayable`

La declaraci�n de la interfaz `IPayable` comienza en la Cod. 12.11 en la l�nea 3. La interfaz `IPayable` contiene el m�todo p�blico abstracto `GetPaymentAmount` (l�nea 5). El m�todo no puede ser declarado expl�citamente como p�blico o abstracto. Las interfaces pueden tener cualquier n�mero de miembros y los m�todos de la interfaz pueden tener par�metros.

## Creamos ahora la clase `Invoice` 

Creamos ahora la clase `Invoice` (*Factura*) (Cod. 12.12) para representar una factura simple que contiene informaci�n de facturaci�n para un tipo de parte. La clase contiene las propiedades `PartNumber` (l�nea 7), `PartDescription` (l�nea 8), `quantity` (l�neas 23�39) y `pricePerItem` (l�neas 42�58) que indican el n�mero de parte, la descripci�n de la parte, la cantidad de la parte ordenada y el precio por �tem. La clase `Invoice` tambi�n contiene un constructor (l�neas 13�20) y un m�todo `ToString` (l�neas 61�63) que devuelve una representaci�n de cadena de un objeto `Invoice`. Los accesores de establecimiento de las propiedades `quantity` y `pricePerItem` aseguran que la `quantity` y `pricePerItem` solo se asignen valores no negativos.

La l�nea 5 indica que la clase `Invoice` implementa la interfaz `IPayable`. Como todas las clases, la clase `Invoice` tambi�n hereda impl�citamente de la clase `object`. Todos los objetos de una clase pueden implementar m�ltiples interfaces, en cuyo caso tienen la relaci�n *es-un* con cada tipo de interfaz implementado.

Para implementar m�s de una interfaz, utiliza una lista separada por comas de los nombres de las interfaces despu�s de los dos puntos (`:`) en la declaraci�n de la clase, como en

```csharp
public class NombreClase : NombreClaseBase, PrimeraInterfaz, SegundaInterfaz, ...
```

Cuando una clase hereda de una clase base e implementa una o m�s interfaces, la declaraci�n de la clase debe enumerar el nombre de la clase base antes que los nombres de las interfaces.

La clase `Invoice` implementa el �nico m�todo en la interfaz `IPayable`, el m�todo `GetPaymentAmount` se declara en la l�nea 66. El m�todo calcula el monto requerido para pagar la factura. El m�todo multiplica los valores de `quantity` y `pricePerItem` (obtenidos a trav�s de las propiedades correspondientes) y devuelve el resultado. Este m�todo cumple con el requisito de implementaci�n para el m�todo en la interfaz `IPayable`, hemos cumplido con el contrato de la interfaz con el compilador.

## 12.7.4 Modificando la Clase Employee para Implementar la Interfaz IPayable

Ahora modificamos la clase `Employee` para implementar la interfaz `IPayable` (Fig. 12.13). Esta declaraci�n de clase es id�ntica a la de la Figura 12.4 con dos excepciones:
- La l�nea 3 de la Figura 12.13 indica que la clase `Employee` ahora implementa la interfaz `IPayable`.
- La l�nea 27 implementa el m�todo `GetPaymentAmount` de la interfaz `IPayable`.

Observa que `GetPaymentAmount` simplemente llama al m�todo abstracto `Earnings` de `Employee`. En el momento de la ejecuci�n, cuando `GetPaymentAmount` se llama en un objeto de una clase derivada de `Employee`, `GetPaymentAmount` llama al m�todo `Earnings` concreto de esa clase, el cual sabe c�mo calcular las ganancias para objetos de ese tipo derivado de clase.

### Clases Derivadas de `Employee` e Interfaz `IPayable`
Cuando una clase implementa una interfaz, se aplica la misma relaci�n de *es-un* (is-a) que con la herencia. La clase `Employee` implementa `IPayable`, por lo que podemos decir que un `Employee` *es un* `IPayable`, y as� cualquier objeto de una clase derivada de `Employee` tambi�n es un `IPayable`. Entonces, si actualizamos la jerarqu�a de clases en la Secci�n 12.5 con la nueva clase `Employee` en la Figura 12.13, entonces `SalariedEmployees`, `HourlyEmployees`, `CommissionEmployees` y `BasePlusCommissionEmployees` son todos objetos `IPayable`. As� como podemos asignar la referencia de un objeto de la clase derivada `SalariedEmployee` a una variable de clase base `Employee`, tambi�n podemos asignar la referencia de un objeto `SalariedEmployee` (o cualquier otro objeto de clase derivada de `Employee`) a una variable `IPayable`. `Invoice` implementa `IPayable`, por lo que un objeto `Invoice` tambi�n es un objeto `IPayable`, y podemos asignar la referencia de un objeto `Invoice` a una variable `IPayable`.

## 12.7.5 Utilizando la Interfaz `IPayable` para Procesar Facturas (`Invoice`) y Empleados (`Employe`'s) de manera Polim�rfica

`PayableInterfaceTest` (Cod. 12.14) ilustra que la interfaz `IPayable` puede ser utilizada para procesar un conjunto de Facturas (`Invoice`) y Empleados (`Employee`'s) de manera polim�rfica en una �nica aplicaci�n. Las l�neas 5-11 crean una `List<IPayable>` llamada `payableObjects` e inicializan la misma con cuatro nuevos objetos: dos objetos de tipo `Invoice` (l�neas 7-8) y dos objetos de tipo `SalariedEmployee` (l�neas 9-10). Estas asignaciones son permitidas porque una `Invoice` *es un* `IPayable`, un `SalariedEmployee` *es un* `Employee` y un `Employee` *es un* `IPayable`. Las l�neas 16-21 utilizan una instrucci�n `foreach` para procesar cada objeto `IPayable` en `payableObjects` de manera polim�rfica, mostrando el objeto como una cadena, junto con el pago debido. La l�nea 19 invoca impl�citamente el m�todo `ToString` usando la referencia de la interfaz `IPayable` `payable`, aunque `ToString` no est� declarado en la interfaz `IPayable`, todas las referencias (incluyendo aquellas de tipos de interfaz) se refieren a objetos de clases que extienden `object` y, por lo tanto, tienen un m�todo `ToString`. La l�nea 20 invoca el m�todo `IPayable` `GetPaymentAmount` para obtener el monto del pago para cada objeto en `payableObjects`, independientemente del tipo real del objeto. La salida revela que las llamadas a m�todos en las l�neas 19 y 20 invocan la implementaci�n adecuada de los m�todos `ToString` y `GetPaymentAmount` de la clase correspondiente.

