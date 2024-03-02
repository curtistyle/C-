# Caso de estudio: Creación y uso de interfaces

Nuestro próximo ejemplo  reexamina el sistema de nómina de la Sección Anterior. Supongamos que la empresa involucrada desea realizar varias operaciones contables en una única aplicación de cuentas por pagar. Además de calcular las ganancias (`Emplyee.Earnings()`) de la nómina que deben pagarse a cada empleado, la empresa también debe calcular el pago debido en cada una de varias facturas (es decir, las facturas por los bienes adquiridos). Aunque se aplican a cosas no relacionadas (es decir, empleados y facturas), ambas operaciones tienen que ver con el cálculo de algún tipo de cantidad de pago. Para un empleado, el pago se refiere a las ganancias del empleado. Para una factura, el pago se refiere al costo total de los bienes enumerados en la factura. ¿Podemos calcular cosas tan diferentes como los pagos adeudados a empleados y facturas de forma polimórfica en una sola aplicación? ¿Existe una capacidad que pueda requerir que clases no relacionadas implementen un conjunto de métodos comunes (por ejemplo, un método que calcule una cantidad de pago)? Las interfaces ofrecen exactamente esta capacidad.

### Interacciones Estandarizadas

Las interfaces definen y estandarizan las formas en que las personas y los sistemas pueden interactuar entre sí. Por ejemplo, los controles en una radio sirven como una interfaz entre los usuarios de la radio y sus componentes internos. Los controles permiten a los usuarios realizar un conjunto limitado de operaciones (por ejemplo, cambiar la estación, ajustar el volumen, elegir entre AM y FM), y diferentes radios pueden implementar los controles de diferentes formas (por ejemplo, usando botones, diales, comandos de voz). La interfaz especifica qué operaciones debe permitir realizar una radio a los usuarios, pero no especifica cómo se realizan. De manera similar, la interfaz entre un conductor y un automóvil con transmisión manual incluye el volante, la palanca de cambios, el pedal del embrague, el pedal del acelerador y el pedal de freno. Esta misma interfaz se encuentra en casi todos los automóviles de transmisión manual, lo que permite a alguien que sabe cómo conducir un automóvil de transmisión manual en particular, conducir prácticamente cualquier otro. Los componentes de cada automóvil pueden verse un poco diferentes, pero el propósito general es el mismo: permitir que las personas conduzcan el automóvil.

### Interfaces en Software

Los objetos de software también se comunican a través de interfaces. Una interfaz en C# describe un conjunto de métodos y propiedades que pueden ser llamados en un objeto, por ejemplo, para indicarle que realice alguna tarea o devuelva cierta información. El siguiente ejemplo presenta una interfaz llamada `IPayable` que describe la funcionalidad de cualquier objeto que debe ser capaz de ser pagado y, por lo tanto, debe ofrecer un método para determinar el monto de pago adecuado que se debe pagar. Una declaración de interfaz comienza con la palabra clave interface y solo puede contener lo siguiente:
	- métodos abstractos,
	- propiedades abstractas,
	- indexadores abstractos (no cubiertos en este libro), y
	- eventos abstractos (los eventos se discuten en el Capítulo 14, Interfaces Gráficas de Usuario con Windows Forms: Parte 1).

Todos los miembros de la interfaz se declaran implícitamente como `piblic` y `abstract`. Además, cada interfaz puede extender una o más interfaces adicionales para crear una interfaz más elaborada que otras clases pueden implementar.

### Implementar una Interfaz

Una clase debe especificar que **implementa** la interfaz al listar el nombre de la interfaz después de los dos puntos (:) en la declaración de la clase. Esta es la misma sintaxis utilizada para indicar la herencia de una clase base. Una clase concreta que implementa la interfaz debe declarar cada miembro de la interfaz con la firma especificada en la declaración de la interfaz. Una clase que implementa una interfaz pero no implementa todos sus miembros es una clase `abstract`, debe declararse `abstract` y debe contener una declaración `abstract` para cada miembro no implementado de la interfaz. Implementar una interfaz es como firmar un contrato con el compilador que establece: "Proporcionaré una implementación para todos los miembros especificados por la interfaz, o los declararé abstractos".

### Métodos Comunes para Clases No Relacionadas

Una interfaz se utiliza típicamente cuando clases no relacionadas necesitan compartir métodos comunes. Esto permite que objetos de clases no relacionadas sean procesados de manera polimórfica; objetos de clases que implementan la misma interfaz pueden responder a las mismas llamadas de método. Puedes crear una interfaz que describa la funcionalidad deseada, luego implementar esta interfaz en cualquier clase que requiera esa funcionalidad. Por ejemplo, en la aplicación de cuentas por pagar desarrollada en esta sección, implementamos la interfaz `IPayable` en cada clase (por ejemplo, `Employee`, `Invoice`) que debe poder calcular un monto de pago.

### Interfaces vs. Clases Abstractas
A menudo, se utiliza una interfaz en lugar de una clase abstracta cuando no hay una implementación predeterminada para heredar, es decir, no hay campos ni implementaciones de métodos por defecto. Al igual que las clases abstractas, las interfaces suelen ser tipos públicos, por lo que normalmente se declaran en archivos por sí mismas con el mismo nombre que la interfaz y la extensión de archivo .cs.

## 12.7.1 Desarrollando una Jerarquía `IPayable`

Para construir una aplicación que pueda determinar pagos tanto para empleados como para facturas, primero creamos una interfaz llamada `IPayable`. La interfaz `IPayable` contiene el método `GetPaymentAmount` que devuelve un monto decimal a pagar por un objeto de cualquier clase que implemente la interfaz. El método `GetPaymentAmount` es una versión de propósito general del método `Earnings` de la jerarquía de Empleados: el método `Earnings` calcula un monto de pago específicamente para un Empleado, mientras que `GetPaymentAmount` se puede aplicar a una amplia gama de objetos no relacionados. Después de declarar la interfaz `IPayable`, introducimos la clase `Invoice`, que implementa la interfaz `IPayable`. Luego modificamos la clase `Employee` para que también implemente la interfaz `IPayable`.

Las clases `Invoice` y `Employe`e representan cosas para las cuales la empresa debe poder calcular un monto de pago. Ambas clases implementan `IPayable`, por lo que una aplicación puede invocar el método `GetPaymentAmount` en objetos de `Invoice` y `Employee` por igual. Esto permite el procesamiento polimórfico de Facturas (`Invoice`) y Empleados (`Employee`'s) requerido para la aplicación de cuentas por pagar de nuestra empresa.

## Diagrama UML que Contiene una Interfaz

El diagrama de clases UML en la Fig. 12.10 muestra la interfaz y la jerarquía de clases utilizadas en nuestra aplicación de cuentas por pagar. La jerarquía comienza con la interfaz `IPayable`. La UML distingue una interfaz de una clase colocando la palabra "interfaz" entre guillemets (« y ») sobre el nombre de la interfaz. La UML expresa la relación entre una clase y una interfaz a través de una realización. Se dice que una clase "realiza", o implementa, una interfaz. Un diagrama de clases modela una realización como una flecha punteada con una cabeza de flecha hueca que apunta desde la clase que implementa hacia la interfaz. El diagrama en la siguiente figura indica que las clases `Invoice` y `Employee` realizan (es decir, implementan) la interfaz `IPayable`. Como en el diagrama de clases de la Fig. 12.2, la clase `Employee` aparece en cursiva, indicando que es una clase abstracta.

La clase concreta `SalariedEmployee` extiende `Employee` y hereda la relación de realización de su clase base con la interfaz `IPayable`. La Figura 12.10 podría incluir toda la jerarquía de clases `Employee` de la Sección 12.5 - para mantener el ejemplo próximo pequeño, no incluimos las clases `HourlyEmployee`, `CommissionEmployee` y `BasePlusCommissionEmployee`.

![IPayable interface and class hierarchy UML class diagram.](img/img1.png)

## 12.7.2 Declaración de la Interfaz `IPayable`

La declaración de la interfaz `IPayable` comienza en la Cod. 12.11 en la línea 3. La interfaz `IPayable` contiene el método público abstracto `GetPaymentAmount` (línea 5). El método no puede ser declarado explícitamente como público o abstracto. Las interfaces pueden tener cualquier número de miembros y los métodos de la interfaz pueden tener parámetros.

## Creamos ahora la clase `Invoice` 

Creamos ahora la clase `Invoice` (*Factura*) (Cod. 12.12) para representar una factura simple que contiene información de facturación para un tipo de parte. La clase contiene las propiedades `PartNumber` (línea 7), `PartDescription` (línea 8), `quantity` (líneas 23–39) y `pricePerItem` (líneas 42–58) que indican el número de parte, la descripción de la parte, la cantidad de la parte ordenada y el precio por ítem. La clase `Invoice` también contiene un constructor (líneas 13–20) y un método `ToString` (líneas 61–63) que devuelve una representación de cadena de un objeto `Invoice`. Los accesores de establecimiento de las propiedades `quantity` y `pricePerItem` aseguran que la `quantity` y `pricePerItem` solo se asignen valores no negativos.

La línea 5 indica que la clase `Invoice` implementa la interfaz `IPayable`. Como todas las clases, la clase `Invoice` también hereda implícitamente de la clase `object`. Todos los objetos de una clase pueden implementar múltiples interfaces, en cuyo caso tienen la relación *es-un* con cada tipo de interfaz implementado.

Para implementar más de una interfaz, utiliza una lista separada por comas de los nombres de las interfaces después de los dos puntos (`:`) en la declaración de la clase, como en

```csharp
public class NombreClase : NombreClaseBase, PrimeraInterfaz, SegundaInterfaz, ...
```

Cuando una clase hereda de una clase base e implementa una o más interfaces, la declaración de la clase debe enumerar el nombre de la clase base antes que los nombres de las interfaces.

La clase `Invoice` implementa el único método en la interfaz `IPayable`, el método `GetPaymentAmount` se declara en la línea 66. El método calcula el monto requerido para pagar la factura. El método multiplica los valores de `quantity` y `pricePerItem` (obtenidos a través de las propiedades correspondientes) y devuelve el resultado. Este método cumple con el requisito de implementación para el método en la interfaz `IPayable`, hemos cumplido con el contrato de la interfaz con el compilador.

## 12.7.4 Modificando la Clase Employee para Implementar la Interfaz IPayable

Ahora modificamos la clase `Employee` para implementar la interfaz `IPayable` (Fig. 12.13). Esta declaración de clase es idéntica a la de la Figura 12.4 con dos excepciones:
- La línea 3 de la Figura 12.13 indica que la clase `Employee` ahora implementa la interfaz `IPayable`.
- La línea 27 implementa el método `GetPaymentAmount` de la interfaz `IPayable`.

Observa que `GetPaymentAmount` simplemente llama al método abstracto `Earnings` de `Employee`. En el momento de la ejecución, cuando `GetPaymentAmount` se llama en un objeto de una clase derivada de `Employee`, `GetPaymentAmount` llama al método `Earnings` concreto de esa clase, el cual sabe cómo calcular las ganancias para objetos de ese tipo derivado de clase.

### Clases Derivadas de `Employee` e Interfaz `IPayable`
Cuando una clase implementa una interfaz, se aplica la misma relación de *es-un* (is-a) que con la herencia. La clase `Employee` implementa `IPayable`, por lo que podemos decir que un `Employee` *es un* `IPayable`, y así cualquier objeto de una clase derivada de `Employee` también es un `IPayable`. Entonces, si actualizamos la jerarquía de clases en la Sección 12.5 con la nueva clase `Employee` en la Figura 12.13, entonces `SalariedEmployees`, `HourlyEmployees`, `CommissionEmployees` y `BasePlusCommissionEmployees` son todos objetos `IPayable`. Así como podemos asignar la referencia de un objeto de la clase derivada `SalariedEmployee` a una variable de clase base `Employee`, también podemos asignar la referencia de un objeto `SalariedEmployee` (o cualquier otro objeto de clase derivada de `Employee`) a una variable `IPayable`. `Invoice` implementa `IPayable`, por lo que un objeto `Invoice` también es un objeto `IPayable`, y podemos asignar la referencia de un objeto `Invoice` a una variable `IPayable`.

## 12.7.5 Utilizando la Interfaz `IPayable` para Procesar Facturas (`Invoice`) y Empleados (`Employe`'s) de manera Polimórfica

`PayableInterfaceTest` (Cod. 12.14) ilustra que la interfaz `IPayable` puede ser utilizada para procesar un conjunto de Facturas (`Invoice`) y Empleados (`Employee`'s) de manera polimórfica en una única aplicación. Las líneas 5-11 crean una `List<IPayable>` llamada `payableObjects` e inicializan la misma con cuatro nuevos objetos: dos objetos de tipo `Invoice` (líneas 7-8) y dos objetos de tipo `SalariedEmployee` (líneas 9-10). Estas asignaciones son permitidas porque una `Invoice` *es un* `IPayable`, un `SalariedEmployee` *es un* `Employee` y un `Employee` *es un* `IPayable`. Las líneas 16-21 utilizan una instrucción `foreach` para procesar cada objeto `IPayable` en `payableObjects` de manera polimórfica, mostrando el objeto como una cadena, junto con el pago debido. La línea 19 invoca implícitamente el método `ToString` usando la referencia de la interfaz `IPayable` `payable`, aunque `ToString` no está declarado en la interfaz `IPayable`, todas las referencias (incluyendo aquellas de tipos de interfaz) se refieren a objetos de clases que extienden `object` y, por lo tanto, tienen un método `ToString`. La línea 20 invoca el método `IPayable` `GetPaymentAmount` para obtener el monto del pago para cada objeto en `payableObjects`, independientemente del tipo real del objeto. La salida revela que las llamadas a métodos en las líneas 19 y 20 invocan la implementación adecuada de los métodos `ToString` y `GetPaymentAmount` de la clase correspondiente.

