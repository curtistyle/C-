# Dictionary `Collections`

Un diccionario es el t�rmino general para una colecci�n de pares **clave-valor** (*key,value*). En esta secci�n, discutiremos los fundamentos de c�mo funciona un `Dictionary`, luego demostraremos la colecci�n relacionada SortedDictionary.

## 19.4.1 Fundamentos del Dictionary
Cuando una aplicaci�n crea objetos de tipos nuevos o existentes, necesita administrar esos objetos de manera eficiente. Esto incluye ordenar y recuperar objetos. Ordenar y recuperar informaci�n con matrices es eficiente si alg�n aspecto de tus datos coincide directamente con el valor clave y si esas claves son �nicas y est�n estrechamente empaquetadas. Si tienes 100 empleados con n�meros de seguro social de nueve d�gitos y deseas almacenar y recuperar datos de empleados utilizando el n�mero de seguro social como clave, nominalmente requerir�a una matriz con 1,000,000,000 elementos, porque hay 1,000,000,000 n�meros �nicos de nueve d�gitos. Si tienes una matriz tan grande, podr�as obtener un alto rendimiento almacenando y recuperando registros de empleados simplemente utilizando el n�mero de seguro social como �ndice de la matriz, pero ser�a un enorme desperdicio de memoria. Muchas aplicaciones tienen este problema, ya sea que las claves sean del tipo incorrecto (es decir, no enteros no negativos), o que sean del tipo correcto pero est�n dispersas de manera dispersa sobre un rango grande.

### Hashing
Lo que se necesita es un esquema de alta velocidad para convertir claves como n�meros de seguro social y n�meros de piezas de inventario en �ndices de matriz �nicos. Entonces, cuando una aplicaci�n necesita almacenar algo, el esquema podr�a convertir la clave r�pidamente en un �ndice y el registro de informaci�n se podr�a almacenar en esa ubicaci�n en la matriz. La recuperaci�n ocurre de la misma manera, una vez que la aplicaci�n tiene una clave para la cual desea recuperar el registro de datos, la aplicaci�n simplemente aplica la conversi�n a la clave, lo que produce el �ndice de matriz donde reside los datos en la matriz y recupera los datos.
El esquema que describimos aqu� es la base de una t�cnica llamada hashing. �Por qu� el nombre? Porque, cuando convertimos una clave en un �ndice de matriz, literalmente mezclamos los bits, haciendo un "hash" del n�mero. El n�mero en realidad no tiene ning�n significado real m�s all� de su utilidad para almacenar y recuperar este registro de datos en particular. Las estructuras de datos que utilizan hashing com�nmente se llaman **tablas hash** (como la clase `Hashtable` en el espacio de nombres `System.Collections`). Una tabla hash es una forma de implementar un diccionario, la clase `Dictionary<K, V>` en el espacio de nombres `System.Collections.Generic` se implementa como una tabla hash.

### Colisiones
Un fallo en el esquema ocurre cuando hay colisiones (es decir, dos claves diferentes "hash" en la misma celda, o elemento, en la matriz). Dado que no podemos ordenar dos registros de datos diferentes en el mismo espacio, necesitamos encontrar un hogar alternativo para todos los registros m�s all� del primero que hash a un �ndice de matriz particular. Un esquema para hacer esto es "hash otra vez" (es decir, reaplicar la transformaci�n de hashing a la clave para proporcionar una siguiente celda candidata en la matriz). El proceso de hashing est� dise�ado de manera que con solo unos pocos hash, se encontrar� una celda disponible.
Otro esquema utiliza un hash para localizar la primera celda candidata. Si la celda est� ocupada, se buscan sucesivamente celdas linealmente hasta que se encuentre una celda disponible. La recuperaci�n funciona de la misma manera: la clave se hashea una vez, la celda resultante se verifica para determinar si contiene los datos deseados. Si lo hace, la b�squeda est� completa. Si no, se buscan sucesivamente celdas linealmente hasta que se encuentren los datos deseados. La soluci�n m�s popular para las colisiones de tablas hash es que cada celda de la tabla sea un "cubo hash", t�picamente, una lista enlazada de todos los pares de clave-valor que hash a esa celda. Esta es la soluci�n que implementa la clase Dictionary del Framework .NET.

### Factor de Carga
El factor de carga afecta el rendimiento de los esquemas de hash. El factor de carga es la proporci�n entre el n�mero de objetos almacenados en la tabla hash y el n�mero total de celdas de la tabla hash. A medida que esta proporci�n aumenta, la probabilidad de colisiones tiende a aumentar.

> **Consejo de rendimiento 19.1**
El factor de carga en una tabla hash es un ejemplo cl�sico de un compromiso entre espacio y tiempo: al aumentar el factor de carga, obtenemos una mejor utilizaci�n de la memoria, pero la aplicaci�n se ejecuta m�s lento debido a un aumento en las colisiones de hash. Al disminuir el factor de carga, obtenemos una mejor velocidad debido a la reducci�n de colisiones de hash, pero obtenemos una peor utilizaci�n de la memoria porque una parte m�s grande de la tabla hash permanece vac�a.

### Funci�n de Hash
Una funci�n de hash realiza un c�lculo que determina d�nde colocar los datos en la tabla hash. La funci�n de hash se aplica a la clave en un par de **clave-valor** (*key,value*) de objetos. Cualquier objeto puede ser utilizado como una clave. Por esta raz�n, la clase object define el m�todo `GetHashCode`, el cual todos los objetos heredan. La mayor�a de las clases que son candidatas a ser utilizadas como claves en una tabla hash, como por ejemplo `string`, sobrescriben este m�todo para proporcionar uno que realice c�lculos eficientes de c�digos hash para un tipo espec�fico.

## 19.4.2 Uso de la Colecci�n `SortedDictionary`
El Framework .NET proporciona varias implementaciones de diccionarios que implementan la interfaz `IDictionary<K,V>` . La aplicaci�n del cidgo 19.4 demuestra la clase gen�rica `SortedDictionary`. A diferencia de la clase `Dictionary`, que se implementa como una tabla hash, la clase `SortedDictionary` almacena sus pares **clave-valor** en un �rbol de b�squeda binario. Como sugiere el nombre de la clase, las entradas en `SortedDictionary` est�n ordenadas por clave.
Para los tipos de clave que implementan `IComparable<T>`, `SortedDictionary` utiliza los resultados del m�todo `CompareTo` de `IComparable<T>` para ordenar las claves. A pesar de estos detalles de implementaci�n, utilizamos los mismos m�todos p�blicos, propiedades e indexadores con las clases `Dictionary` y `SortedDictionary.` En muchos escenarios, estas clases son intercambiables; esta es la belleza de la programaci�n orientada a objetos.

> *Debido a que la clase `SortedDictionary` mantiene sus elementos ordenados en un �rbol binario, obtener o insertar un par clave-valor lleva tiempo O(log n), lo cual es r�pido en comparaci�n con la b�squeda lineal y luego la inserci�n.*

Las l�neas 1-3 contienen directivas de uso para los espacios de nombres `System` (para la clase `Console`), `System.Text.RegularExpressions` (para la clase `Regex`) y `System.Collections.Generic` (para la clase `SortedDictionary`). La clase gen�rica `SortedDictionary` toma dos argumentos de tipo:
- el primero especifica el tipo de clave (es decir, `string`) y
- el segundo el tipo de valor (es decir, `int`).
La clase `SortedDictionaryTest` declara tres m�todos est�ticos:
- El m�todo `CollectWords` (l�neas 19-48) ingresa una oraci�n y devuelve un `SortedDictionary<string, int>` en el que las claves son las palabras de la oraci�n y los valores son la cantidad de veces que aparece cada palabra en la oraci�n.
- El m�todo `DisplayDictionary` (l�neas 51-65) muestra el `SortedDictionary` que se le pasa en formato de columna.
- El m�todo `Main` (l�neas 10-16) simplemente invoca `CollectWords` (l�nea 13), luego pasa el `SortedDictionary<string, int>` devuelto por `CollectWords` a `DisplayDictionary` en la l�nea 15.

### Metodo CollecWords
El m�todo `CollectWord`s (l�neas 19-48) comienza inicializando la variable local dictionary con un nuevo `SortedDictionary<string, int>` (l�nea 22). Las l�neas 24-25 solicitan al usuario e ingresan una oraci�n como una cadena. Utilizamos el m�todo est�tico `Split` de la clase `Regex` (introducido en la secci�n en l�nea del Cap�tulo 16 en http://www.deitel.com/books/CSharp6FP) en la l�nea 28 para dividir la cadena por sus caracteres de espacio en blanco. En la expresi�n regular `\s+`, `\s` significa espacio en blanco y `+` significa uno o m�s de la expresi�n a su izquierda, por lo que las palabras est�n separadas por uno o m�s caracteres de espacio en blanco, que se descartan. Esto crea un array de "palabras", que luego almacenamos en la variable local `words`.

### Los m�todos `ContainsKey` y `Add` de `SortedDictionary`.
Los m�todos `ContainsKey` y `Add` de `SortedDictionary` (l�neas 31-45) iteran a trav�s del array `words`. Cada palabra se convierte a min�sculas con el m�todo `ToLower` de `string`, luego se almacena en la variable `key` (l�nea 33). Luego, la l�nea 36 llama al m�todo `ContainsKey` de `SortedDictionary` para determinar si la palabra est� en el diccionario. Si es as�, esa palabra ocurri� previamente en la oraci�n. Si el `SortedDictionary` no contiene una entrada para la palabra, la l�nea 43 utiliza el m�todo `Add` de `SortedDictionary` para crear una nueva entrada en el diccionario, con la palabra en min�sculas como la clave y 1 como el valor.

> **Error com�n de programaci�n 19.2**
Utilizar el m�todo Add para agregar una clave que ya existe en la tabla hash provoca un ArgumentException.

### �ndice del SortedDictionary
Si la palabra ya es una clave en la tabla hash, la l�nea 38 utiliza el �ndice del `SortedDictionary` para obtener y establecer el valor asociado a la clave (el recuento de palabras) en el diccionario. Utilizar el accessor `set` con una clave que no existe en la tabla hash crea una nueva entrada, como si hubieras utilizado el m�todo `Add`, por lo que la l�nea 43 podr�a haber sido escrita como:

```
dictionary[key] = 1;
```

### M�todo `DisplayDictionary`
La l�nea 47 devuelve el diccionario al m�todo `Main`, que luego lo pasa al m�todo `DisplayDictionary` (l�neas 51-65), que muestra todos los pares **clave-valor**. Este m�todo utiliza la propiedad de solo lectura `Keys` (l�nea 59) para obtener una `ICollection<T>` que contiene todas las claves. Dado que la interfaz `ICollection<T>` extiende `IEnumerable<T>`, podemos usar esta colecci�n en la instrucci�n `foreach` en las l�neas 59-62 para iterar sobre las claves. Este bucle accede y muestra cada clave y su valor correspondiente utilizando la variable de iteraci�n y el accessor de obtenci�n del �ndice del `Sorted Dictionary`. Cada clave y valor se muestra alineado a la izquierda en un ancho de campo de 12 posiciones. Dado que un `SortedDictionary` almacena sus pares **clave-valor** en un �rbol binario de b�squeda, los pares **clave-valor** se muestran con las claves en orden ordenado. La l�nea 64 utiliza la propiedad `Count` de `SortedDictionary` para obtener el n�mero de pares **clave-valor** en el diccionario.

### Propiedad Values de SortedDictionary
Si no necesitas las claves, la clase `SortedDictionary` tambi�n proporciona una propiedad `Values` de solo lectura que obtiene una `ICollection<T>` de todos los valores almacenados en el `SortedDictionary`. Podr�as usar esta propiedad para iterar a trav�s de los valores almacenados en el `SortedDictionary` sin preocuparte por sus claves correspondientes.

