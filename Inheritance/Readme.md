# Inheritance

## Introduction

Este cap�tulo contin�a nuestra discusi�n sobre la programaci�n orientada a objetos (OOP) al introducir una de sus caracter�sticas principales: la herencia, una forma de reutilizaci�n de software en la que se crea una nueva clase absorbiendo los miembros de una clase existente y mejor�ndolos con capacidades nuevas o modificadas. La herencia te permite ahorrar tiempo durante el desarrollo de aplicaciones al reutilizar software probado, de alto rendimiento y depurado de alta calidad. Esto tambi�n aumenta la probabilidad de que un sistema se implemente de manera efectiva.

La clase existente de la que hereda una nueva clase se llama clase base, y la nueva clase es la clase derivada. Cada clase derivada puede convertirse en la clase base para futuras clases derivadas. Una clase derivada normalmente agrega sus propios campos, propiedades y m�todos. Por lo tanto, es m�s espec�fica que su clase base y representa un grupo de objetos m�s especializados. T�picamente, la clase derivada exhibe los comportamientos de su clase base y otros adicionales que son espec�ficos de ella misma.

La clase base directa es la clase base de la que una clase derivada hereda expl�citamente. Una clase base indirecta es cualquier clase por encima de la clase base directa en la jerarqu�a de clases, que define las relaciones de herencia entre clases. La jerarqu�a de clases comienza con la clase `object` (un palabra clave en C# que es un alias para `System.Object` en la Biblioteca de Clases del Framework).

Cada clase extiende (o "hereda de") object directa o indirectamente. La secci�n 11.7 enumera los m�todos de la clase `object`, que todas las dem�s clases heredan. En la herencia simple, una clase se deriva de una clase base directa. C# solo admite la herencia simple. En el Cap�tulo 12, OOP: Polimorfismo e Interfaces, explicamos c�mo puedes usar interfaces para obtener muchos de los beneficios de la herencia m�ltiple (es decir, heredar de m�ltiples clases base directas) mientras evitas los problemas asociados que ocurren en algunos lenguajes de programaci�n.

La experiencia en la construcci�n de sistemas de software indica que cantidades significativas de c�digo tratan casos especiales estrechamente relacionados. Cuando est�s preocupado por casos especiales, los detalles pueden oscurecer la imagen general. Con la programaci�n orientada a objetos, puedes, cuando sea apropiado, centrarte en las similitudes entre objetos en el sistema en lugar de en los casos especiales.

Distinguimos entre la relaci�n "es-un" y la relaci�n "tiene-un". "Es-un" representa la herencia. En una relaci�n "es-un", un objeto de una clase derivada tambi�n puede tratarse como un objeto de su clase base. Por ejemplo, un coche es un veh�culo, y un cami�n es un veh�culo. Por otro lado, "tiene-un" representa la composici�n (ver Cap�tulo 10). En una relaci�n "tiene-un", un objeto contiene como miembros referencias a otros objetos. Por ejemplo, un coche tiene un volante, y un objeto coche tiene una referencia a un objeto volante.

Las nuevas clases pueden heredar de clases en bibliotecas de clases. Las organizaciones desarrollan sus propias bibliotecas de clases y pueden aprovechar otras disponibles en todo el mundo. Es probable que alg�n d�a, la mayor�a del nuevo software se construya a partir de componentes reutilizables estandarizados, al igual que los autom�viles y la mayor�a del hardware inform�tico se construyen hoy en d�a. Esto facilitar� el desarrollo de software m�s potente, abundante y econ�mico.

## Base classes and Derived Classes

A menudo, un objeto de una clase tambi�n *es un* objeto de otra clase. Por ejemplo, en geometr�a, un rect�ngulo *es un* cuadril�tero (al igual que los cuadrados, paralelogramos y trapecios). Por lo tanto, se puede decir que la clase `Rect�ngulo` hereda de la clase `Cuadril�tero`. En este contexto, la clase `Cuadril�tero` es una *clase base* y la clase `Rect�ngulo` es una *clase derivada*. Un rect�ngulo *es un* tipo espec�fico de cuadril�tero, pero ser�a incorrecto afirmar que todo cuadril�tero *es un* rect�ngulo, ya que el cuadril�tero podr�a ser un paralelogramo u otra forma. En la siguiente figura enumera varios ejemplos simples de clases base y clases derivadas; las clases base tienden a ser m�s generales y las clases derivadas tienden a ser m�s espec�ficas.

![Inheritance example](img/Diagram1.png)

Debido a que cada objeto *de una* clase derivada es tambi�n un objeto de su clase base, y una clase base puede *tener muchas* clases derivadas, el conjunto de objetos representados por una clase base suele ser m�s grande que el conjunto de objetos representados por cualquiera de sus clases derivadas. Por ejemplo, la clase base `Veh�culo` representa *todos* los veh�culos: autom�viles, camiones, barcos, bicicletas, etc. En cambio, la clase derivada `Autom�vil` representa un subconjunto m�s peque�o y espec�fico de veh�culos.
Las relaciones de herencia forman estructuras jer�rquicas en forma de �rbol (*Como en la siguiente figura*). Una clase base existe en una relaci�n jer�rquica con sus clases derivadas. Cuando las clases participan en relaciones de herencia, se "afilian" con otras clases. Una clase se convierte en una clase base, suministrando miembros a otras clases, o una clase derivada, heredando sus miembros de otra clase. A veces, una clase es tanto una clase base como una clase derivada.
Desarrollemos una jerarqu�a de clases de ejemplo, tambi�n llamada jerarqu�a de herencia (*Siguiente figura*). El diagrama de clases UML muestra una comunidad universitaria que tiene muchos tipos de miembros, incluidos empleados, estudiantes y ex alumnos. Los empleados son o bien miembros del profesorado o miembros del personal. Los miembros del profesorado son administradores (como decanos y jefes de departamento) o profesores. La jerarqu�a podr�a contener muchas otras clases. Por ejemplo, los estudiantes pueden ser estudiantes de posgrado o de pregrado. Los estudiantes de pregrado pueden ser de primer a�o, segundo a�o, tercer a�o o cuarto a�o.

![Inheritance hierarchy UML class diagram for university CommunityMembers](img/Diagram2.png)

Cada flecha con una cabeza de flecha triangular hueca en el diagrama de jerarqu�a representa una relaci�n *es-un*. Al seguir las flechas, podemos afirmar, por ejemplo, que "un `Employee` es un `CommunityMember`" y "un `Teacher` es un Miembro del `Faculty`". `CommunityMember` es la clase base directa de `Employee`, `Student` y `Alumnus`, e *indirectamente* de todas las dem�s clases en el diagrama. Comenzando desde abajo, se pueden seguir las flechas y aplicar la relaci�n es-un hasta la clase base m�s alta. Por ejemplo, un `Administrator` es un `Faculty`, es un `Employe` y es un `CommunityMember`. 
Ahora consideremos la jerarqu�a de la siguiente figura, que comienza con la clase base `Shape`. Esta clase es ampliada por las clases derivadas `TwoDimensionalShape` y `ThreeDimensionalShape`; una `Shape` es o bien una `TwoDimensionalShape` o una `ThreeDimensionalShape`. El tercer nivel de esta jerarqu�a contiene `Shape`s Bidimensionales y Tridimensionales espec�ficas. Podemos seguir las flechas desde abajo hasta la clase base m�s alta en esta jerarqu�a para identificar las relaciones *es-un*. Por ejemplo, un `Triangle` es una `TwoDiamensionalShape` y es una `Shape`, mientras que una `Sphere` es una `ThreeDimensionalShape` y es una `Shape`. Esta jerarqu�a podr�a contener muchas otras clases. Por ejemplo, las elipses y los trapecios tambi�n son Formas Bidimensionales.

![UML Class diagram showing an inheritance hierarchy for `ShapeS`](img/Diagram3.png)

No todas las relaciones entre clases son relaciones de herencia. Mas adelante discutiremos la relaci�n *tiene-un*, en la que las clases tienen miembros que son referencias a objetos de otras clases. Tales relaciones crean clases mediante la **composici�n** de clases existentes. Por ejemplo, dadas las clases `Empleado`, `FechaDeNacimiento` y `N�meroDeTel�fono`, ser�a incorrecto decir que un `Empleado` es una `FechaDeNacimiento` o que un `Empleado` es un `N�meroDeTel�fono`. Sin embargo, un `Empleado` *tiene una* `FechaDeNacimiento`, y un `Empleado` *tiene un* `N�meroDeTel�fono`.
Es posible tratar objetos de clases base y clases derivadas de manera similar: sus similitudes se expresan en los miembros de la clase base. Los objetos de todas las clases que extienden una clase base com�n pueden tratarse como objetos de esa clase base; dichos objetos tienen una relaci�n *es-un* con la clase base. Sin embargo, los objetos de la clase base no pueden tratarse como objetos de sus clases derivadas. Por ejemplo, todos los autos son veh�culos, pero no todos los veh�culos son autos (otros veh�culos podr�an ser camiones, aviones, bicicletas, etc.). Este cap�tulo y el Cap�tulo 12 consideran muchos ejemplos de relaciones es-un.
Una clase derivada puede personalizar m�todos que hereda de su clase base. En tales casos, la clase derivada puede anular (redefinir) el m�todo de la clase base con una implementaci�n adecuada, como veremos a menudo en los ejemplos de c�digo del cap�tulo.

Mi traducci�n para el texto proporcionado es la siguiente:

---

## Miembros protegidos (`protected` members)

Hemos discutido anteriormente los modificadores de acceso `public` y `private`. Los miembros p�blicos de una clase son accesibles dondequiera que la aplicaci�n tenga una referencia a un objeto de esa clase o de una de sus clases derivadas. Los miembros privados de una clase son accesibles solo dentro de la propia clase. Los miembros privados de una clase base son heredados por sus clases derivadas, pero no son accesibles directamente por los m�todos y propiedades de la clase derivada. En esta secci�n, introducimos el modificador de acceso `protected`. El uso del acceso protegido ofrece un nivel intermedio de acceso entre `public` y `private`. Los miembros protegidos de una clase base pueden ser accedidos por los miembros de esa clase base y por los miembros de sus clases derivadas, pero no por los clientes de la clase.

Todos los miembros de una clase base que no son privados mantienen su modificador de acceso original cuando se convierten en miembros de la clase derivada: los miembros p�blicos de la clase base se convierten en miembros p�blicos de la clase derivada, y los miembros protegidos de la clase base se convierten en miembros protegidos de la clase derivada.

Los m�todos de la clase derivada pueden referirse a los miembros p�blicos y protegidos heredados de la clase base simplemente usando los nombres de los miembros. Cuando un m�todo de la clase derivada anula un m�todo de la clase base, la versi�n de la clase base puede ser accedida desde la clase derivada precediendo el nombre del m�todo de la clase base con la palabra clave `base` y el operador de acceso de miembros (`.`).

## Relaci�n entre Clases Base y Clases Derivadas

En esta secci�n, utilizamos una jerarqu�a de herencia que contiene tipos de empleados en la aplicaci�n de n�mina de una empresa para discutir la relaci�n entre una clase base y una clase derivada. En esta empresa:

- Los empleados por comisi�n, que ser�n representados como objetos de una clase base, reciben un porcentaje de sus ventas, mientras que

- Los empleados con salario base y comisi�n, que ser�n representados como objetos de una clase derivada, reciben un salario base m�s un porcentaje de sus ventas.

Dividimos nuestra discusi�n sobre la relaci�n entre estos tipos de empleados en un conjunto evolutivo de cinco ejemplos que fueron dise�ados cuidadosamente para ense�ar las capacidades clave para la ingenier�a de software con herencia:

1. El primer ejemplo crea la clase CommissionEmployee, que hereda directamente de la clase object. La clase declara propiedades auto-implementadas p�blicas para el nombre, apellido y n�mero de seguro social, y variables de instancia privadas para la tasa de comisi�n y el monto bruto (es decir, total) de ventas.
2. El segundo ejemplo declara la clase BasePlusCommissionEmployee, que tambi�n hereda directamente de object. La clase declara propiedades auto-implementadas p�blicas para el nombre, apellido y n�mero de seguro social, y variables de instancia privadas para la tasa de comisi�n, el monto bruto de ventas y el salario base. Creamos la clase escribiendo cada l�nea de c�digo que la clase requiere; pronto veremos que es m�s eficiente crear esta clase mediante la herencia de CommissionEmployee.

3. El tercer ejemplo declara una clase BasePlusCommissionEmployee separada que extiende la clase CommissionEmployee, es decir, un BasePlusCommissionEmployee es un CommissionEmployee que tambi�n tiene un salario base. BasePlusCommissionEmployee intenta acceder a los miembros privados de la clase CommissionEmployee, pero esto resulta en errores de compilaci�n porque una clase derivada no puede acceder a las variables de instancia privadas de su clase base.

4. El cuarto ejemplo muestra que si las variables de instancia de la clase base CommissionEmployee se declaran como protegidas, una clase BasePlusCommissionEmployee que hereda de CommissionEmployee puede acceder a esos datos directamente.

5. El quinto y �ltimo ejemplo demuestra las mejores pr�cticas al establecer las variables de instancia de CommissionEmployee nuevamente como privadas en la clase CommissionEmployee para garantizar una buena ingenier�a de software. Luego mostramos c�mo una clase BasePlusCommissionEmployee separada que hereda de la clase CommissionEmployee puede usar los m�todos y propiedades p�blicas de CommissionEmployee para manipular las variables de instancia privadas de CommissionEmployee de manera controlada.

En los primeros cuatro ejemplos, accederemos directamente a las variables de instancia en varios casos donde se deber�an usar propiedades. En el quinto ejemplo, aplicaremos t�cnicas efectivas de ingenier�a de software que hemos presentado hasta este punto en el libro para crear clases que sean f�ciles de mantener, modificar y depurar.

