## Introduction 

Sería bueno si pudiéramos centrar nuestra atención en realizar solo una tarea a la vez y hacerla bien. Esto suele ser difícil en un mundo complejo en el que hay tantas cosas sucediendo al mismo tiempo. Este capítulo presenta las capacidades de C# para desarrollar programas que crean y gestionan múltiples tareas. Como demostraremos, esto puede mejorar significativamente el rendimiento del programa, especialmente en sistemas multinúcleo.

### Concurrencia
Cuando decimos que dos tareas están operando **concurrentemente**, nos referimos a que ambas están progresando al mismo tiempo. Hasta hace poco, la mayoría de las computadoras tenían solo un procesador. Los sistemas operativos en tales computadoras ejecutan tareas concurrentemente al cambiar rápidamente entre ellas, realizando una pequeña porción de cada una antes de pasar a la siguiente, para que todas las tareas sigan progresando. Por ejemplo, es común que las computadoras personales compilen un programa, envíen un archivo a una impresora, reciban mensajes de correo electrónico a través de una red y más, de manera concurrente. Tareas como estas que proceden de manera independiente entre sí se consideran ejecutadas de forma asíncrona y se denominan **tareas asíncronas** (*asynchronous task*).


### Paralelismo
Cuando decimos que dos tareas están operando en **paralelo**, nos referimos a que se están ejecutando simultáneamente. En este sentido, el paralelismo es un subconjunto de la concurrencia. El cuerpo humano realiza una gran variedad de operaciones en paralelo. La respiración, la circulación sanguínea, la digestión, el pensamiento y caminar, por ejemplo, pueden ocurrir en paralelo, al igual que todos los sentidos: la vista, el oído, el tacto, el olfato y el gusto. Se cree que este paralelismo es posible porque se piensa que el cerebro humano contiene miles de millones de "procesadores". Las computadoras actuales con múltiples núcleos tienen varios procesadores que pueden realizar tareas en paralelo.

### Multihilo (Multithreading)
C# pone a tu disposición la concurrencia a través del lenguaje y las API. Los programas en C# pueden tener múltiples hilos de ejecución, *donde cada hilo tiene su propia pila de llamadas a métodos*, lo que le permite ejecutarse simultáneamente con otros hilos mientras comparte recursos de la aplicación, como la memoria y los archivos. Esta capacidad se denomina **multihilo** (*Multithreading*).

### La Multitarea es Difícil
A las personas les resulta difícil cambiar entre trenes de pensamiento concurrentes. Para entender por qué los programas multihilo pueden ser difíciles de escribir y entender, prueba el siguiente experimento:
Abre tres libros en la página 1 e intenta leer los libros de manera concurrente. Lee algunas palabras del primer libro, luego algunas del segundo, luego algunas del tercero, y vuelve a leer las siguientes palabras del primer libro, del segundo, y así sucesivamente. Después de este experimento, apreciarás muchos de los desafíos de la multitarea: cambiar entre los libros, leer brevemente, recordar tu lugar en cada libro, mover el libro que estás leyendo más cerca para poder verlo y apartar los libros que no estás leyendo, todo esto mientras intentas comprender el contenido de los libros en medio de este caos.

>**Performance Tip 21.1**
Un problema con las aplicaciones de un solo hilo que puede llevar a una baja capacidad de respuesta es que las actividades prolongadas deben completarse antes de que otras puedan comenzar. En una aplicación multihilo, los hilos pueden distribuirse en varios núcleos (si están disponibles) para que múltiples tareas se ejecuten en paralelo y la aplicación pueda operar de manera más eficiente. El multihilo también puede aumentar el rendimiento en sistemas de un solo procesador; cuando un hilo no puede avanzar (por ejemplo, porque está esperando el resultado de una operación de entrada/salida), otro puede utilizar el procesador.

### Programación Asíncrona, async y await
Para aprovechar al máximo las arquitecturas multinúcleo, es necesario escribir aplicaciones que puedan procesar tareas de forma asíncrona. La programación asíncrona es una técnica para escribir aplicaciones que contienen tareas que pueden ejecutarse de forma asíncrona, lo que puede mejorar el rendimiento de la aplicación y la capacidad de respuesta de la interfaz de usuario en aplicaciones con tareas de larga duración o intensivas en cálculos. Antes de lenguajes como C#, dichas aplicaciones se implementaban con primitivas del sistema operativo disponibles solo para programadores de sistemas experimentados. Luego, C# y otros lenguajes de programación comenzaron a permitir a los desarrolladores de aplicaciones especificar operaciones concurrentes. Inicialmente, estas capacidades eran complejas de usar, lo que llevaba a errores frecuentes y sutiles.

El modificador `async` y el operador `await` simplifican en gran medida la programación asíncrona, reducen errores y permiten que tus aplicaciones aprovechen la potencia de procesamiento en las computadoras multinúcleo, teléfonos inteligentes y tabletas de hoy. Muchas clases de .NET para acceso web, procesamiento de archivos, redes, procesamiento de imágenes y más, tienen métodos que devuelven objetos `Task` para usar con `async` y `await`, de modo que puedas aprovechar el modelo de programación asíncrona. Este capítulo presenta una introducción simple a la programación asíncrona con `async` y `await`.

## 21.2 Fundamentos de async y await
Antes de la introducción de `async` y `await`, era común que un método llamado de manera síncrona (es decir, realizando tareas una tras otra en orden) en el hilo de llamada lanzara una tarea de larga duración de manera asíncrona y proporcionara a esa tarea un método de devolución de llamada (o, en algunos casos, registrara un controlador de eventos) que se invocaría una vez que se completara la tarea asíncrona. Este estilo de codificación se simplifica con `async` y `await`.

### 21.2.1 Modificador async
El modificador `async` indica que un método o expresión lambda contiene al menos una expresión await. Un método asíncrono ejecuta su cuerpo en el mismo hilo que el método de llamada. (A lo largo del resto de esta discusión, utilizaremos el término "método" para referirnos a "método o expresión lambda".)

### 21.2.2 Expresión await
Una expresión `await`, que solo puede aparecer en un método asíncrono, consta del operador `await` seguido de una expresión que devuelve una entidad awaitable, normalmente un objeto `Task` (como verás en la Sección 21.3), aunque es posible crear tus propias entidades awaitable. La creación de entidades awaitable está más allá del alcance de nuestra discusión. Para obtener más información, consulta 

http://blogs.msdn.com/b/pfxteam/archive/2011/01/13/10115642.aspx

Cuando un método asíncrono encuentra una expresión `await`:
• Si la tarea asíncrona ya ha completado, el método asíncrono simplemente continúa ejecutándose.
• De lo contrario, el control del programa regresa al llamador del método asíncrono hasta que la tarea asíncrona complete su ejecución. Esto permite que el llamador realice otras tareas que no dependen de los resultados de la tarea asíncrona.

Cuando la tarea asíncrona se completa, el control regresa al método asíncrono y continúa con la siguiente instrucción después de la expresión `await`.

### 21.2.3 `async`, `await` y `Thread`
El mecanismo `async` y `await` no crea nuevos hilos. Si se necesitan hilos, el método que llamas para iniciar una tarea asíncrona en la que esperas los resultados es responsable de crear los hilos que se utilizan para realizar la tarea asíncrona. Por ejemplo, mostraremos cómo utilizar el método `Run` de la clase `Task` en varios ejemplos para iniciar nuevos hilos de ejecución y ejecutar tareas de forma asíncrona. El método `Run` de la clase `Task` devuelve un objeto `Task` en el que un método puede esperar el resultado.

## 21.3 Ejecutar una Tarea Asíncrona desde una Aplicación GUI
Esta sección demuestra los beneficios de ejecutar tareas intensivas en cálculos de forma asíncrona en una aplicación GUI.

### 21.3.1 Realización de una Tarea de forma Asíncrona
En el codigo 21.1 demuestra la ejecución de una tarea asíncrona desde una aplicación GUI. En la mitad superior de la GUI, puedes ingresar un número entero y hacer clic en Calcular para calcular el valor Fibonacci de ese número entero (discutido en breve) utilizando una implementación recursiva intensiva en cálculos. Comenzando con enteros en los 40 (en nuestra computadora de prueba), el cálculo recursivo puede llevar segundos o incluso minutos en calcular. Si este cálculo se realizara de manera síncrona, la GUI se congelaría durante ese tiempo y el usuario no podría interactuar con la aplicación (como demostraremos en el Codigo 21.2). Lanzamos el cálculo de forma asíncrona y lo ejecutamos en un hilo separado para que la GUI siga siendo receptiva. Para demostrar esto, en la mitad inferior de la GUI, puedes hacer clic en Siguiente Número repetidamente para calcular el siguiente número Fibonacci simplemente sumando los dos números anteriores en la secuencia. En nuesra aplicacion, usamos la mitad superior de la GUI para calcular Fibonacci(45), lo que llevó más de un minuto en nuestra computadora de prueba. Mientras ese cálculo procedía en un hilo separado, hicimos clic en Siguiente Número repetidamente para demostrar que aún podíamos interactuar con la GUI y que el cálculo iterativo de Fibonacci es mucho más eficiente.

### Un Algoritmo Intensivo en Cálculos: Cálculo Recursivo de Números Fibonacci
Los ejemplos en esta sección y en las Secciones 21.4–21.5 realizan cada uno un cálculo recursivo intensivo en cálculos para la serie Fibonacci (definida en el método Fibonacci en las líneas 53–63). La serie Fibonacci

```Csharp
0, 1, 1, 2, 3, 5, 8, 13, 21, …
```

comienza con 0 y 1, y cada número Fibonacci subsiguiente es la suma de los dos números Fibonacci anteriores. La serie Fibonacci se puede definir recursivamente de la siguiente manera:

```
Fibonacci(0) = 0
Fibonacci(1) = 1
Fibonacci(n) = Fibonacci(n – 1) + Fibonacci(n – 2)
```

#### Complejidad Exponencial
Es necesario tener precaución con los métodos recursivos como el que utilizamos aquí para generar números Fibonacci. La cantidad de llamadas recursivas requeridas para calcular el enésimo número Fibonacci está en el orden de 2\^n. Esto rápidamente se vuelve inmanejable a medida que n aumenta. Calcular solo el vigésimo número Fibonacci requeriría del orden de 2\^20 o alrededor de un millón de llamadas, calcular el trigésimo número Fibonacci requeriría del orden de 2^30 o alrededor de mil millones de llamadas, y así sucesivamente. ¡Esta complejidad exponencial puede desafiar incluso a las computadoras más potentes del mundo! Calcular simplemente Fibonacci(47) de manera recursiva, incluso en las computadoras de escritorio y portátiles más recientes de hoy, puede llevar minutos.

### 21.3.2 Método calculateButton_Click
El controlador de eventos del botón **Calcular** (líneas 21–36) inicia la llamada al método `Fibonacci` en un hilo separado y muestra los resultados cuando la llamada se completa. El método se declara como `async` (línea 21) para indicar al compilador que el método iniciará una tarea asíncrona y esperará los resultados. En un método asíncrono, escribes código que parece ejecutarse de manera secuencial, y el compilador maneja los complicados problemas de gestionar la ejecución asíncrona. Esto hace que tu código sea más fácil de escribir, depurar, modificar y mantener, y reduce los errores.

### 21.3.3 Método `Run` de la Clase `Task`: Ejecución de forma Asíncrona en un Hilo Separado
La línea 29 crea y inicia una `Task<TResult>` (en el espacio de nombres System.Threading.Tasks), que promete devolver un resultado de tipo genérico `TResult` en algún momento futuro. La clase `Task` es parte de la Biblioteca Paralela de Tareas (*Task Paralllel Library*, TPL, por sus siglas en inglés) de .NET para programación paralela y asíncrona. La versión del método estático `Run` de la clase `Task` utilizada en la línea 29 recibe como argumento un delegado `Func<TResult>` y ejecuta un método en un hilo separado. El delegado `Func<TResult>` representa cualquier método que no tome argumentos y devuelva un resultado del tipo especificado por el parámetro de tipo `TResult`. El tipo de retorno del método que pasas a `Run` se utiliza por el compilador como el argumento de tipo para el delegado `Func` de `Run` y para la `Task` que `Run` devuelve.

El método Fibonacci requiere un argumento, por lo que la línea 29 pasa la expresión lambda

```
() => Fibonacci(number)
```

que no toma argumentos; esta lambda encapsula la llamada a `Fibonacci` con el argumento `number` (*el valor ingresado por el usuario*). La expresión lambda devuelve implícitamente el resultado de la llamada a `Fibonacci` (un `long`), por lo que cumple con los requisitos del delegado `Func<TResult>`. En este ejemplo, el método estático `Run` de `Task` crea y devuelve una `Task<long>`. El compilador infiere el tipo `long` a partir del tipo de retorno del método `Fibonacci`. Podríamos declarar la variable local `fibonacciTask` (línea 29) con var; usamos explícitamente el tipo `Task<long>` por claridad, ya que el tipo de retorno del método `Run` de `Task` no es evidente desde la llamada.

### 21.3.4 Esperando el Resultado
A continuación, la línea 32 espera (`await`) el resultado de la tarea `fibonacciTask` que se está ejecutando de forma asíncrona. Si `fibonacciTask` ya está completa, la ejecución continúa con la línea 35. De lo contrario, el control regresa al llamador de `calculateButton_Click` (el hilo de manejo de eventos de la GUI) hasta que esté disponible el resultado de `fibonacciTask`. Esto permite que la GUI siga siendo receptiva mientras se ejecuta la tarea. Una vez que la tarea se completa, `calculateButton_Click` continúa su ejecución en la línea 35, que utiliza la propiedad `Result` de la tarea para obtener el valor devuelto por `Fibonacci` y mostrarlo en `asyncResultLabel`.

Un método asíncrono puede realizar declaraciones entre aquellas que inician una tarea asíncrona y esperan los resultados. En tal caso, el método continúa ejecutando esas declaraciones después de iniciar la tarea asíncrona hasta que llega a la expresión `await`. Las líneas 29 y 32 se pueden escribir de manera más concisa como

```csharp
long result = await Task.Run(() => Fibonacci(number));
```

En este caso, el operador `await` desempaqueta y devuelve el resultado de la tarea, es decir, el valor long devuelto por el método `Fibonacci`. Luego puedes usar directamente el valor `long` sin acceder a la propiedad `Result` de la tarea.

### 21.3.5 Calculando el Siguiente Valor Fibonacci de forma Síncrona
Cuando haces clic en Siguiente Número, se ejecuta el controlador de eventos `nextNumberButton_Click` (líneas 39–50). Las líneas 42–45 suman los dos números `Fibonacci` anteriores almacenados en las variables de instancia `n1` y `n2` para determinar el siguiente número en la secuencia, actualizan las variables de instancia `n1` y `n2` con sus nuevos valores e incrementan la variable de instancia `count`. Luego, las líneas 48–49 actualizan la interfaz gráfica para mostrar el número Fibonacci que acaba de calcularse.

El código en el controlador de eventos de Siguiente Número (**Next Number**) se realiza en el hilo de ejecución de la GUI que procesa las interacciones del usuario con los controles. Manejar cálculos cortos en este hilo no hace que la GUI se vuelva no receptiva. Debido a que el cálculo más largo de Fibonacci se realiza en un hilo separado, es posible obtener el siguiente número Fibonacci mientras el cálculo recursivo aún está en progreso.