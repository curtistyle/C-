# Inheritance

## Introduction

Este capítulo continúa nuestra discusión sobre la programación orientada a objetos (OOP) al introducir una de sus características principales: la herencia, una forma de reutilización de software en la que se crea una nueva clase absorbiendo los miembros de una clase existente y mejorándolos con capacidades nuevas o modificadas. La herencia te permite ahorrar tiempo durante el desarrollo de aplicaciones al reutilizar software probado, de alto rendimiento y depurado de alta calidad. Esto también aumenta la probabilidad de que un sistema se implemente de manera efectiva.

La clase existente de la que hereda una nueva clase se llama clase base, y la nueva clase es la clase derivada. Cada clase derivada puede convertirse en la clase base para futuras clases derivadas. Una clase derivada normalmente agrega sus propios campos, propiedades y métodos. Por lo tanto, es más específica que su clase base y representa un grupo de objetos más especializados. Típicamente, la clase derivada exhibe los comportamientos de su clase base y otros adicionales que son específicos de ella misma.

La clase base directa es la clase base de la que una clase derivada hereda explícitamente. Una clase base indirecta es cualquier clase por encima de la clase base directa en la jerarquía de clases, que define las relaciones de herencia entre clases. La jerarquía de clases comienza con la clase `object` (un palabra clave en C# que es un alias para `System.Object` en la Biblioteca de Clases del Framework).

Cada clase extiende (o "hereda de") object directa o indirectamente. La sección 11.7 enumera los métodos de la clase `object`, que todas las demás clases heredan. En la herencia simple, una clase se deriva de una clase base directa. C# solo admite la herencia simple. En el Capítulo 12, OOP: Polimorfismo e Interfaces, explicamos cómo puedes usar interfaces para obtener muchos de los beneficios de la herencia múltiple (es decir, heredar de múltiples clases base directas) mientras evitas los problemas asociados que ocurren en algunos lenguajes de programación.

La experiencia en la construcción de sistemas de software indica que cantidades significativas de código tratan casos especiales estrechamente relacionados. Cuando estás preocupado por casos especiales, los detalles pueden oscurecer la imagen general. Con la programación orientada a objetos, puedes, cuando sea apropiado, centrarte en las similitudes entre objetos en el sistema en lugar de en los casos especiales.

Distinguimos entre la relación "es-un" y la relación "tiene-un". "Es-un" representa la herencia. En una relación "es-un", un objeto de una clase derivada también puede tratarse como un objeto de su clase base. Por ejemplo, un coche es un vehículo, y un camión es un vehículo. Por otro lado, "tiene-un" representa la composición (ver Capítulo 10). En una relación "tiene-un", un objeto contiene como miembros referencias a otros objetos. Por ejemplo, un coche tiene un volante, y un objeto coche tiene una referencia a un objeto volante.

Las nuevas clases pueden heredar de clases en bibliotecas de clases. Las organizaciones desarrollan sus propias bibliotecas de clases y pueden aprovechar otras disponibles en todo el mundo. Es probable que algún día, la mayoría del nuevo software se construya a partir de componentes reutilizables estandarizados, al igual que los automóviles y la mayoría del hardware informático se construyen hoy en día. Esto facilitará el desarrollo de software más potente, abundante y económico.

## Base classes and Derived Classes

A menudo, un objeto de una clase también *es un* objeto de otra clase. Por ejemplo, en geometría, un rectángulo *es un* cuadrilátero (al igual que los cuadrados, paralelogramos y trapecios). Por lo tanto, se puede decir que la clase `Rectángulo` hereda de la clase `Cuadrilátero`. En este contexto, la clase `Cuadrilátero` es una *clase base* y la clase `Rectángulo` es una *clase derivada*. Un rectángulo *es un* tipo específico de cuadrilátero, pero sería incorrecto afirmar que todo cuadrilátero *es un* rectángulo, ya que el cuadrilátero podría ser un paralelogramo u otra forma. En la siguiente figura enumera varios ejemplos simples de clases base y clases derivadas; las clases base tienden a ser más generales y las clases derivadas tienden a ser más específicas.

![Inheritance example](img/Diagram1.png)

Debido a que cada objeto *de una* clase derivada es también un objeto de su clase base, y una clase base puede *tener muchas* clases derivadas, el conjunto de objetos representados por una clase base suele ser más grande que el conjunto de objetos representados por cualquiera de sus clases derivadas. Por ejemplo, la clase base `Vehículo` representa *todos* los vehículos: automóviles, camiones, barcos, bicicletas, etc. En cambio, la clase derivada `Automóvil` representa un subconjunto más pequeño y específico de vehículos.
Las relaciones de herencia forman estructuras jerárquicas en forma de árbol (*Como en la siguiente figura*). Una clase base existe en una relación jerárquica con sus clases derivadas. Cuando las clases participan en relaciones de herencia, se "afilian" con otras clases. Una clase se convierte en una clase base, suministrando miembros a otras clases, o una clase derivada, heredando sus miembros de otra clase. A veces, una clase es tanto una clase base como una clase derivada.
Desarrollemos una jerarquía de clases de ejemplo, también llamada jerarquía de herencia (*Siguiente figura*). El diagrama de clases UML muestra una comunidad universitaria que tiene muchos tipos de miembros, incluidos empleados, estudiantes y ex alumnos. Los empleados son o bien miembros del profesorado o miembros del personal. Los miembros del profesorado son administradores (como decanos y jefes de departamento) o profesores. La jerarquía podría contener muchas otras clases. Por ejemplo, los estudiantes pueden ser estudiantes de posgrado o de pregrado. Los estudiantes de pregrado pueden ser de primer año, segundo año, tercer año o cuarto año.

![Inheritance hierarchy UML class diagram for university CommunityMembers](img/Diagram2.png)

Cada flecha con una cabeza de flecha triangular hueca en el diagrama de jerarquía representa una relación *es-un*. Al seguir las flechas, podemos afirmar, por ejemplo, que "un `Employee` es un `CommunityMember`" y "un `Teacher` es un Miembro del `Faculty`". `CommunityMember` es la clase base directa de `Employee`, `Student` y `Alumnus`, e *indirectamente* de todas las demás clases en el diagrama. Comenzando desde abajo, se pueden seguir las flechas y aplicar la relación es-un hasta la clase base más alta. Por ejemplo, un `Administrator` es un `Faculty`, es un `Employe` y es un `CommunityMember`. 
Ahora consideremos la jerarquía de la siguiente figura, que comienza con la clase base `Shape`. Esta clase es ampliada por las clases derivadas `TwoDimensionalShape` y `ThreeDimensionalShape`; una `Shape` es o bien una `TwoDimensionalShape` o una `ThreeDimensionalShape`. El tercer nivel de esta jerarquía contiene `Shape`s Bidimensionales y Tridimensionales específicas. Podemos seguir las flechas desde abajo hasta la clase base más alta en esta jerarquía para identificar las relaciones *es-un*. Por ejemplo, un `Triangle` es una `TwoDiamensionalShape` y es una `Shape`, mientras que una `Sphere` es una `ThreeDimensionalShape` y es una `Shape`. Esta jerarquía podría contener muchas otras clases. Por ejemplo, las elipses y los trapecios también son Formas Bidimensionales.

![UML Class diagram showing an inheritance hierarchy for `ShapeS`](img/Diagram3.png)

No todas las relaciones entre clases son relaciones de herencia. Mas adelante discutiremos la relación *tiene-un*, en la que las clases tienen miembros que son referencias a objetos de otras clases. Tales relaciones crean clases mediante la **composición** de clases existentes. Por ejemplo, dadas las clases `Empleado`, `FechaDeNacimiento` y `NúmeroDeTeléfono`, sería incorrecto decir que un `Empleado` es una `FechaDeNacimiento` o que un `Empleado` es un `NúmeroDeTeléfono`. Sin embargo, un `Empleado` *tiene una* `FechaDeNacimiento`, y un `Empleado` *tiene un* `NúmeroDeTeléfono`.
Es posible tratar objetos de clases base y clases derivadas de manera similar: sus similitudes se expresan en los miembros de la clase base. Los objetos de todas las clases que extienden una clase base común pueden tratarse como objetos de esa clase base; dichos objetos tienen una relación *es-un* con la clase base. Sin embargo, los objetos de la clase base no pueden tratarse como objetos de sus clases derivadas. Por ejemplo, todos los autos son vehículos, pero no todos los vehículos son autos (otros vehículos podrían ser camiones, aviones, bicicletas, etc.). Este capítulo y el Capítulo 12 consideran muchos ejemplos de relaciones es-un.
Una clase derivada puede personalizar métodos que hereda de su clase base. En tales casos, la clase derivada puede anular (redefinir) el método de la clase base con una implementación adecuada, como veremos a menudo en los ejemplos de código del capítulo.

Mi traducción para el texto proporcionado es la siguiente:

---

## Miembros protegidos (`protected` members)

Hemos discutido anteriormente los modificadores de acceso `public` y `private`. Los miembros públicos de una clase son accesibles dondequiera que la aplicación tenga una referencia a un objeto de esa clase o de una de sus clases derivadas. Los miembros privados de una clase son accesibles solo dentro de la propia clase. Los miembros privados de una clase base son heredados por sus clases derivadas, pero no son accesibles directamente por los métodos y propiedades de la clase derivada. En esta sección, introducimos el modificador de acceso `protected`. El uso del acceso protegido ofrece un nivel intermedio de acceso entre `public` y `private`. Los miembros protegidos de una clase base pueden ser accedidos por los miembros de esa clase base y por los miembros de sus clases derivadas, pero no por los clientes de la clase.

Todos los miembros de una clase base que no son privados mantienen su modificador de acceso original cuando se convierten en miembros de la clase derivada: los miembros públicos de la clase base se convierten en miembros públicos de la clase derivada, y los miembros protegidos de la clase base se convierten en miembros protegidos de la clase derivada.

Los métodos de la clase derivada pueden referirse a los miembros públicos y protegidos heredados de la clase base simplemente usando los nombres de los miembros. Cuando un método de la clase derivada anula un método de la clase base, la versión de la clase base puede ser accedida desde la clase derivada precediendo el nombre del método de la clase base con la palabra clave `base` y el operador de acceso de miembros (`.`).

## Relación entre Clases Base y Clases Derivadas

En esta sección, utilizamos una jerarquía de herencia que contiene tipos de empleados en la aplicación de nómina de una empresa para discutir la relación entre una clase base y una clase derivada. En esta empresa:

- Los empleados por comisión, que serán representados como objetos de una clase base, reciben un porcentaje de sus ventas, mientras que

- Los empleados con salario base y comisión, que serán representados como objetos de una clase derivada, reciben un salario base más un porcentaje de sus ventas.

Dividimos nuestra discusión sobre la relación entre estos tipos de empleados en un conjunto evolutivo de cinco ejemplos que fueron diseñados cuidadosamente para enseñar las capacidades clave para la ingeniería de software con herencia:

1. El primer ejemplo crea la clase CommissionEmployee, que hereda directamente de la clase object. La clase declara propiedades auto-implementadas públicas para el nombre, apellido y número de seguro social, y variables de instancia privadas para la tasa de comisión y el monto bruto (es decir, total) de ventas.
2. El segundo ejemplo declara la clase BasePlusCommissionEmployee, que también hereda directamente de object. La clase declara propiedades auto-implementadas públicas para el nombre, apellido y número de seguro social, y variables de instancia privadas para la tasa de comisión, el monto bruto de ventas y el salario base. Creamos la clase escribiendo cada línea de código que la clase requiere; pronto veremos que es más eficiente crear esta clase mediante la herencia de CommissionEmployee.

3. El tercer ejemplo declara una clase BasePlusCommissionEmployee separada que extiende la clase CommissionEmployee, es decir, un BasePlusCommissionEmployee es un CommissionEmployee que también tiene un salario base. BasePlusCommissionEmployee intenta acceder a los miembros privados de la clase CommissionEmployee, pero esto resulta en errores de compilación porque una clase derivada no puede acceder a las variables de instancia privadas de su clase base.

4. El cuarto ejemplo muestra que si las variables de instancia de la clase base CommissionEmployee se declaran como protegidas, una clase BasePlusCommissionEmployee que hereda de CommissionEmployee puede acceder a esos datos directamente.

5. El quinto y último ejemplo demuestra las mejores prácticas al establecer las variables de instancia de CommissionEmployee nuevamente como privadas en la clase CommissionEmployee para garantizar una buena ingeniería de software. Luego mostramos cómo una clase BasePlusCommissionEmployee separada que hereda de la clase CommissionEmployee puede usar los métodos y propiedades públicas de CommissionEmployee para manipular las variables de instancia privadas de CommissionEmployee de manera controlada.

En los primeros cuatro ejemplos, accederemos directamente a las variables de instancia en varios casos donde se deberían usar propiedades. En el quinto ejemplo, aplicaremos técnicas efectivas de ingeniería de software que hemos presentado hasta este punto en el libro para crear clases que sean fáciles de mantener, modificar y depurar.

