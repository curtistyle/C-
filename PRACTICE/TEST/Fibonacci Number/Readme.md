## Introduction 

Ser�a bueno si pudi�ramos centrar nuestra atenci�n en realizar solo una tarea a la vez y hacerla bien. Esto suele ser dif�cil en un mundo complejo en el que hay tantas cosas sucediendo al mismo tiempo. Este cap�tulo presenta las capacidades de C# para desarrollar programas que crean y gestionan m�ltiples tareas. Como demostraremos, esto puede mejorar significativamente el rendimiento del programa, especialmente en sistemas multin�cleo.

### Concurrencia
Cuando decimos que dos tareas est�n operando **concurrentemente**, nos referimos a que ambas est�n progresando al mismo tiempo. Hasta hace poco, la mayor�a de las computadoras ten�an solo un procesador. Los sistemas operativos en tales computadoras ejecutan tareas concurrentemente al cambiar r�pidamente entre ellas, realizando una peque�a porci�n de cada una antes de pasar a la siguiente, para que todas las tareas sigan progresando. Por ejemplo, es com�n que las computadoras personales compilen un programa, env�en un archivo a una impresora, reciban mensajes de correo electr�nico a trav�s de una red y m�s, de manera concurrente. Tareas como estas que proceden de manera independiente entre s� se consideran ejecutadas de forma as�ncrona y se denominan **tareas as�ncronas** (*asynchronous task*).


### Paralelismo
Cuando decimos que dos tareas est�n operando en **paralelo**, nos referimos a que se est�n ejecutando simult�neamente. En este sentido, el paralelismo es un subconjunto de la concurrencia. El cuerpo humano realiza una gran variedad de operaciones en paralelo. La respiraci�n, la circulaci�n sangu�nea, la digesti�n, el pensamiento y caminar, por ejemplo, pueden ocurrir en paralelo, al igual que todos los sentidos: la vista, el o�do, el tacto, el olfato y el gusto. Se cree que este paralelismo es posible porque se piensa que el cerebro humano contiene miles de millones de "procesadores". Las computadoras actuales con m�ltiples n�cleos tienen varios procesadores que pueden realizar tareas en paralelo.

### Multihilo (Multithreading)
C# pone a tu disposici�n la concurrencia a trav�s del lenguaje y las API. Los programas en C# pueden tener m�ltiples hilos de ejecuci�n, *donde cada hilo tiene su propia pila de llamadas a m�todos*, lo que le permite ejecutarse simult�neamente con otros hilos mientras comparte recursos de la aplicaci�n, como la memoria y los archivos. Esta capacidad se denomina **multihilo** (*Multithreading*).

### La Multitarea es Dif�cil
A las personas les resulta dif�cil cambiar entre trenes de pensamiento concurrentes. Para entender por qu� los programas multihilo pueden ser dif�ciles de escribir y entender, prueba el siguiente experimento:
Abre tres libros en la p�gina 1 e intenta leer los libros de manera concurrente. Lee algunas palabras del primer libro, luego algunas del segundo, luego algunas del tercero, y vuelve a leer las siguientes palabras del primer libro, del segundo, y as� sucesivamente. Despu�s de este experimento, apreciar�s muchos de los desaf�os de la multitarea: cambiar entre los libros, leer brevemente, recordar tu lugar en cada libro, mover el libro que est�s leyendo m�s cerca para poder verlo y apartar los libros que no est�s leyendo, todo esto mientras intentas comprender el contenido de los libros en medio de este caos.

>**Performance Tip 21.1**
Un problema con las aplicaciones de un solo hilo que puede llevar a una baja capacidad de respuesta es que las actividades prolongadas deben completarse antes de que otras puedan comenzar. En una aplicaci�n multihilo, los hilos pueden distribuirse en varios n�cleos (si est�n disponibles) para que m�ltiples tareas se ejecuten en paralelo y la aplicaci�n pueda operar de manera m�s eficiente. El multihilo tambi�n puede aumentar el rendimiento en sistemas de un solo procesador; cuando un hilo no puede avanzar (por ejemplo, porque est� esperando el resultado de una operaci�n de entrada/salida), otro puede utilizar el procesador.

### Programaci�n As�ncrona, async y await
Para aprovechar al m�ximo las arquitecturas multin�cleo, es necesario escribir aplicaciones que puedan procesar tareas de forma as�ncrona. La programaci�n as�ncrona es una t�cnica para escribir aplicaciones que contienen tareas que pueden ejecutarse de forma as�ncrona, lo que puede mejorar el rendimiento de la aplicaci�n y la capacidad de respuesta de la interfaz de usuario en aplicaciones con tareas de larga duraci�n o intensivas en c�lculos. Antes de lenguajes como C#, dichas aplicaciones se implementaban con primitivas del sistema operativo disponibles solo para programadores de sistemas experimentados. Luego, C# y otros lenguajes de programaci�n comenzaron a permitir a los desarrolladores de aplicaciones especificar operaciones concurrentes. Inicialmente, estas capacidades eran complejas de usar, lo que llevaba a errores frecuentes y sutiles.

El modificador `async` y el operador `await` simplifican en gran medida la programaci�n as�ncrona, reducen errores y permiten que tus aplicaciones aprovechen la potencia de procesamiento en las computadoras multin�cleo, tel�fonos inteligentes y tabletas de hoy. Muchas clases de .NET para acceso web, procesamiento de archivos, redes, procesamiento de im�genes y m�s, tienen m�todos que devuelven objetos `Task` para usar con `async` y `await`, de modo que puedas aprovechar el modelo de programaci�n as�ncrona. Este cap�tulo presenta una introducci�n simple a la programaci�n as�ncrona con `async` y `await`.

## 21.2 Fundamentos de async y await
Antes de la introducci�n de `async` y `await`, era com�n que un m�todo llamado de manera s�ncrona (es decir, realizando tareas una tras otra en orden) en el hilo de llamada lanzara una tarea de larga duraci�n de manera as�ncrona y proporcionara a esa tarea un m�todo de devoluci�n de llamada (o, en algunos casos, registrara un controlador de eventos) que se invocar�a una vez que se completara la tarea as�ncrona. Este estilo de codificaci�n se simplifica con `async` y `await`.

### 21.2.1 Modificador async
El modificador `async` indica que un m�todo o expresi�n lambda contiene al menos una expresi�n await. Un m�todo as�ncrono ejecuta su cuerpo en el mismo hilo que el m�todo de llamada. (A lo largo del resto de esta discusi�n, utilizaremos el t�rmino "m�todo" para referirnos a "m�todo o expresi�n lambda".)

### 21.2.2 Expresi�n await
Una expresi�n `await`, que solo puede aparecer en un m�todo as�ncrono, consta del operador `await` seguido de una expresi�n que devuelve una entidad awaitable, normalmente un objeto `Task` (como ver�s en la Secci�n 21.3), aunque es posible crear tus propias entidades awaitable. La creaci�n de entidades awaitable est� m�s all� del alcance de nuestra discusi�n. Para obtener m�s informaci�n, consulta 

http://blogs.msdn.com/b/pfxteam/archive/2011/01/13/10115642.aspx

Cuando un m�todo as�ncrono encuentra una expresi�n `await`:
� Si la tarea as�ncrona ya ha completado, el m�todo as�ncrono simplemente contin�a ejecut�ndose.
� De lo contrario, el control del programa regresa al llamador del m�todo as�ncrono hasta que la tarea as�ncrona complete su ejecuci�n. Esto permite que el llamador realice otras tareas que no dependen de los resultados de la tarea as�ncrona.

Cuando la tarea as�ncrona se completa, el control regresa al m�todo as�ncrono y contin�a con la siguiente instrucci�n despu�s de la expresi�n `await`.

### 21.2.3 `async`, `await` y `Thread`
El mecanismo `async` y `await` no crea nuevos hilos. Si se necesitan hilos, el m�todo que llamas para iniciar una tarea as�ncrona en la que esperas los resultados es responsable de crear los hilos que se utilizan para realizar la tarea as�ncrona. Por ejemplo, mostraremos c�mo utilizar el m�todo `Run` de la clase `Task` en varios ejemplos para iniciar nuevos hilos de ejecuci�n y ejecutar tareas de forma as�ncrona. El m�todo `Run` de la clase `Task` devuelve un objeto `Task` en el que un m�todo puede esperar el resultado.

## 21.3 Ejecutar una Tarea As�ncrona desde una Aplicaci�n GUI
Esta secci�n demuestra los beneficios de ejecutar tareas intensivas en c�lculos de forma as�ncrona en una aplicaci�n GUI.

### 21.3.1 Realizaci�n de una Tarea de forma As�ncrona
En el codigo 21.1 demuestra la ejecuci�n de una tarea as�ncrona desde una aplicaci�n GUI. En la mitad superior de la GUI, puedes ingresar un n�mero entero y hacer clic en Calcular para calcular el valor Fibonacci de ese n�mero entero (discutido en breve) utilizando una implementaci�n recursiva intensiva en c�lculos. Comenzando con enteros en los 40 (en nuestra computadora de prueba), el c�lculo recursivo puede llevar segundos o incluso minutos en calcular. Si este c�lculo se realizara de manera s�ncrona, la GUI se congelar�a durante ese tiempo y el usuario no podr�a interactuar con la aplicaci�n (como demostraremos en el Codigo 21.2). Lanzamos el c�lculo de forma as�ncrona y lo ejecutamos en un hilo separado para que la GUI siga siendo receptiva. Para demostrar esto, en la mitad inferior de la GUI, puedes hacer clic en Siguiente N�mero repetidamente para calcular el siguiente n�mero Fibonacci simplemente sumando los dos n�meros anteriores en la secuencia. En nuesra aplicacion, usamos la mitad superior de la GUI para calcular Fibonacci(45), lo que llev� m�s de un minuto en nuestra computadora de prueba. Mientras ese c�lculo proced�a en un hilo separado, hicimos clic en Siguiente N�mero repetidamente para demostrar que a�n pod�amos interactuar con la GUI y que el c�lculo iterativo de Fibonacci es mucho m�s eficiente.

### Un Algoritmo Intensivo en C�lculos: C�lculo Recursivo de N�meros Fibonacci
Los ejemplos en esta secci�n y en las Secciones 21.4�21.5 realizan cada uno un c�lculo recursivo intensivo en c�lculos para la serie Fibonacci (definida en el m�todo Fibonacci en las l�neas 53�63). La serie Fibonacci

```Csharp
0, 1, 1, 2, 3, 5, 8, 13, 21, �
```

comienza con 0 y 1, y cada n�mero Fibonacci subsiguiente es la suma de los dos n�meros Fibonacci anteriores. La serie Fibonacci se puede definir recursivamente de la siguiente manera:

```
Fibonacci(0) = 0
Fibonacci(1) = 1
Fibonacci(n) = Fibonacci(n � 1) + Fibonacci(n � 2)
```

#### Complejidad Exponencial
Es necesario tener precauci�n con los m�todos recursivos como el que utilizamos aqu� para generar n�meros Fibonacci. La cantidad de llamadas recursivas requeridas para calcular el en�simo n�mero Fibonacci est� en el orden de 2\^n. Esto r�pidamente se vuelve inmanejable a medida que n aumenta. Calcular solo el vig�simo n�mero Fibonacci requerir�a del orden de 2\^20 o alrededor de un mill�n de llamadas, calcular el trig�simo n�mero Fibonacci requerir�a del orden de 2^30 o alrededor de mil millones de llamadas, y as� sucesivamente. �Esta complejidad exponencial puede desafiar incluso a las computadoras m�s potentes del mundo! Calcular simplemente Fibonacci(47) de manera recursiva, incluso en las computadoras de escritorio y port�tiles m�s recientes de hoy, puede llevar minutos.

### 21.3.2 M�todo calculateButton_Click
El controlador de eventos del bot�n **Calcular** (l�neas 21�36) inicia la llamada al m�todo `Fibonacci` en un hilo separado y muestra los resultados cuando la llamada se completa. El m�todo se declara como `async` (l�nea 21) para indicar al compilador que el m�todo iniciar� una tarea as�ncrona y esperar� los resultados. En un m�todo as�ncrono, escribes c�digo que parece ejecutarse de manera secuencial, y el compilador maneja los complicados problemas de gestionar la ejecuci�n as�ncrona. Esto hace que tu c�digo sea m�s f�cil de escribir, depurar, modificar y mantener, y reduce los errores.

### 21.3.3 M�todo `Run` de la Clase `Task`: Ejecuci�n de forma As�ncrona en un Hilo Separado
La l�nea 29 crea y inicia una `Task<TResult>` (en el espacio de nombres System.Threading.Tasks), que promete devolver un resultado de tipo gen�rico `TResult` en alg�n momento futuro. La clase `Task` es parte de la Biblioteca Paralela de Tareas (*Task Paralllel Library*, TPL, por sus siglas en ingl�s) de .NET para programaci�n paralela y as�ncrona. La versi�n del m�todo est�tico `Run` de la clase `Task` utilizada en la l�nea 29 recibe como argumento un delegado `Func<TResult>` y ejecuta un m�todo en un hilo separado. El delegado `Func<TResult>` representa cualquier m�todo que no tome argumentos y devuelva un resultado del tipo especificado por el par�metro de tipo `TResult`. El tipo de retorno del m�todo que pasas a `Run` se utiliza por el compilador como el argumento de tipo para el delegado `Func` de `Run` y para la `Task` que `Run` devuelve.

El m�todo Fibonacci requiere un argumento, por lo que la l�nea 29 pasa la expresi�n lambda

```
() => Fibonacci(number)
```

que no toma argumentos; esta lambda encapsula la llamada a `Fibonacci` con el argumento `number` (*el valor ingresado por el usuario*). La expresi�n lambda devuelve impl�citamente el resultado de la llamada a `Fibonacci` (un `long`), por lo que cumple con los requisitos del delegado `Func<TResult>`. En este ejemplo, el m�todo est�tico `Run` de `Task` crea y devuelve una `Task<long>`. El compilador infiere el tipo `long` a partir del tipo de retorno del m�todo `Fibonacci`. Podr�amos declarar la variable local `fibonacciTask` (l�nea 29) con var; usamos expl�citamente el tipo `Task<long>` por claridad, ya que el tipo de retorno del m�todo `Run` de `Task` no es evidente desde la llamada.

### 21.3.4 Esperando el Resultado
A continuaci�n, la l�nea 32 espera (`await`) el resultado de la tarea `fibonacciTask` que se est� ejecutando de forma as�ncrona. Si `fibonacciTask` ya est� completa, la ejecuci�n contin�a con la l�nea 35. De lo contrario, el control regresa al llamador de `calculateButton_Click` (el hilo de manejo de eventos de la GUI) hasta que est� disponible el resultado de `fibonacciTask`. Esto permite que la GUI siga siendo receptiva mientras se ejecuta la tarea. Una vez que la tarea se completa, `calculateButton_Click` contin�a su ejecuci�n en la l�nea 35, que utiliza la propiedad `Result` de la tarea para obtener el valor devuelto por `Fibonacci` y mostrarlo en `asyncResultLabel`.

Un m�todo as�ncrono puede realizar declaraciones entre aquellas que inician una tarea as�ncrona y esperan los resultados. En tal caso, el m�todo contin�a ejecutando esas declaraciones despu�s de iniciar la tarea as�ncrona hasta que llega a la expresi�n `await`. Las l�neas 29 y 32 se pueden escribir de manera m�s concisa como

```csharp
long result = await Task.Run(() => Fibonacci(number));
```

En este caso, el operador `await` desempaqueta y devuelve el resultado de la tarea, es decir, el valor long devuelto por el m�todo `Fibonacci`. Luego puedes usar directamente el valor `long` sin acceder a la propiedad `Result` de la tarea.

### 21.3.5 Calculando el Siguiente Valor Fibonacci de forma S�ncrona
Cuando haces clic en Siguiente N�mero, se ejecuta el controlador de eventos `nextNumberButton_Click` (l�neas 39�50). Las l�neas 42�45 suman los dos n�meros `Fibonacci` anteriores almacenados en las variables de instancia `n1` y `n2` para determinar el siguiente n�mero en la secuencia, actualizan las variables de instancia `n1` y `n2` con sus nuevos valores e incrementan la variable de instancia `count`. Luego, las l�neas 48�49 actualizan la interfaz gr�fica para mostrar el n�mero Fibonacci que acaba de calcularse.

El c�digo en el controlador de eventos de Siguiente N�mero (**Next Number**) se realiza en el hilo de ejecuci�n de la GUI que procesa las interacciones del usuario con los controles. Manejar c�lculos cortos en este hilo no hace que la GUI se vuelva no receptiva. Debido a que el c�lculo m�s largo de Fibonacci se realiza en un hilo separado, es posible obtener el siguiente n�mero Fibonacci mientras el c�lculo recursivo a�n est� en progreso.