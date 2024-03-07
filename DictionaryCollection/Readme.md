# Dictionary `Collections`

Un diccionario es el término general para una colección de pares **clave-valor** (*key,value*). En esta sección, discutiremos los fundamentos de cómo funciona un `Dictionary`, luego demostraremos la colección relacionada SortedDictionary.

## 19.4.1 Fundamentos del Dictionary
Cuando una aplicación crea objetos de tipos nuevos o existentes, necesita administrar esos objetos de manera eficiente. Esto incluye ordenar y recuperar objetos. Ordenar y recuperar información con matrices es eficiente si algún aspecto de tus datos coincide directamente con el valor clave y si esas claves son únicas y están estrechamente empaquetadas. Si tienes 100 empleados con números de seguro social de nueve dígitos y deseas almacenar y recuperar datos de empleados utilizando el número de seguro social como clave, nominalmente requeriría una matriz con 1,000,000,000 elementos, porque hay 1,000,000,000 números únicos de nueve dígitos. Si tienes una matriz tan grande, podrías obtener un alto rendimiento almacenando y recuperando registros de empleados simplemente utilizando el número de seguro social como índice de la matriz, pero sería un enorme desperdicio de memoria. Muchas aplicaciones tienen este problema, ya sea que las claves sean del tipo incorrecto (es decir, no enteros no negativos), o que sean del tipo correcto pero estén dispersas de manera dispersa sobre un rango grande.

### Hashing
Lo que se necesita es un esquema de alta velocidad para convertir claves como números de seguro social y números de piezas de inventario en índices de matriz únicos. Entonces, cuando una aplicación necesita almacenar algo, el esquema podría convertir la clave rápidamente en un índice y el registro de información se podría almacenar en esa ubicación en la matriz. La recuperación ocurre de la misma manera, una vez que la aplicación tiene una clave para la cual desea recuperar el registro de datos, la aplicación simplemente aplica la conversión a la clave, lo que produce el índice de matriz donde reside los datos en la matriz y recupera los datos.
El esquema que describimos aquí es la base de una técnica llamada hashing. ¿Por qué el nombre? Porque, cuando convertimos una clave en un índice de matriz, literalmente mezclamos los bits, haciendo un "hash" del número. El número en realidad no tiene ningún significado real más allá de su utilidad para almacenar y recuperar este registro de datos en particular. Las estructuras de datos que utilizan hashing comúnmente se llaman **tablas hash** (como la clase `Hashtable` en el espacio de nombres `System.Collections`). Una tabla hash es una forma de implementar un diccionario, la clase `Dictionary<K, V>` en el espacio de nombres `System.Collections.Generic` se implementa como una tabla hash.

### Colisiones
Un fallo en el esquema ocurre cuando hay colisiones (es decir, dos claves diferentes "hash" en la misma celda, o elemento, en la matriz). Dado que no podemos ordenar dos registros de datos diferentes en el mismo espacio, necesitamos encontrar un hogar alternativo para todos los registros más allá del primero que hash a un índice de matriz particular. Un esquema para hacer esto es "hash otra vez" (es decir, reaplicar la transformación de hashing a la clave para proporcionar una siguiente celda candidata en la matriz). El proceso de hashing está diseñado de manera que con solo unos pocos hash, se encontrará una celda disponible.
Otro esquema utiliza un hash para localizar la primera celda candidata. Si la celda está ocupada, se buscan sucesivamente celdas linealmente hasta que se encuentre una celda disponible. La recuperación funciona de la misma manera: la clave se hashea una vez, la celda resultante se verifica para determinar si contiene los datos deseados. Si lo hace, la búsqueda está completa. Si no, se buscan sucesivamente celdas linealmente hasta que se encuentren los datos deseados. La solución más popular para las colisiones de tablas hash es que cada celda de la tabla sea un "cubo hash", típicamente, una lista enlazada de todos los pares de clave-valor que hash a esa celda. Esta es la solución que implementa la clase Dictionary del Framework .NET.

### Factor de Carga
El factor de carga afecta el rendimiento de los esquemas de hash. El factor de carga es la proporción entre el número de objetos almacenados en la tabla hash y el número total de celdas de la tabla hash. A medida que esta proporción aumenta, la probabilidad de colisiones tiende a aumentar.

> **Consejo de rendimiento 19.1**
El factor de carga en una tabla hash es un ejemplo clásico de un compromiso entre espacio y tiempo: al aumentar el factor de carga, obtenemos una mejor utilización de la memoria, pero la aplicación se ejecuta más lento debido a un aumento en las colisiones de hash. Al disminuir el factor de carga, obtenemos una mejor velocidad debido a la reducción de colisiones de hash, pero obtenemos una peor utilización de la memoria porque una parte más grande de la tabla hash permanece vacía.

### Función de Hash
Una función de hash realiza un cálculo que determina dónde colocar los datos en la tabla hash. La función de hash se aplica a la clave en un par de **clave-valor** (*key,value*) de objetos. Cualquier objeto puede ser utilizado como una clave. Por esta razón, la clase object define el método `GetHashCode`, el cual todos los objetos heredan. La mayoría de las clases que son candidatas a ser utilizadas como claves en una tabla hash, como por ejemplo `string`, sobrescriben este método para proporcionar uno que realice cálculos eficientes de códigos hash para un tipo específico.

## 19.4.2 Uso de la Colección `SortedDictionary`
El Framework .NET proporciona varias implementaciones de diccionarios que implementan la interfaz `IDictionary<K,V>` . La aplicación del cidgo 19.4 demuestra la clase genérica `SortedDictionary`. A diferencia de la clase `Dictionary`, que se implementa como una tabla hash, la clase `SortedDictionary` almacena sus pares **clave-valor** en un árbol de búsqueda binario. Como sugiere el nombre de la clase, las entradas en `SortedDictionary` están ordenadas por clave.
Para los tipos de clave que implementan `IComparable<T>`, `SortedDictionary` utiliza los resultados del método `CompareTo` de `IComparable<T>` para ordenar las claves. A pesar de estos detalles de implementación, utilizamos los mismos métodos públicos, propiedades e indexadores con las clases `Dictionary` y `SortedDictionary.` En muchos escenarios, estas clases son intercambiables; esta es la belleza de la programación orientada a objetos.

> *Debido a que la clase `SortedDictionary` mantiene sus elementos ordenados en un árbol binario, obtener o insertar un par clave-valor lleva tiempo O(log n), lo cual es rápido en comparación con la búsqueda lineal y luego la inserción.*

Las líneas 1-3 contienen directivas de uso para los espacios de nombres `System` (para la clase `Console`), `System.Text.RegularExpressions` (para la clase `Regex`) y `System.Collections.Generic` (para la clase `SortedDictionary`). La clase genérica `SortedDictionary` toma dos argumentos de tipo:
- el primero especifica el tipo de clave (es decir, `string`) y
- el segundo el tipo de valor (es decir, `int`).
La clase `SortedDictionaryTest` declara tres métodos estáticos:
- El método `CollectWords` (líneas 19-48) ingresa una oración y devuelve un `SortedDictionary<string, int>` en el que las claves son las palabras de la oración y los valores son la cantidad de veces que aparece cada palabra en la oración.
- El método `DisplayDictionary` (líneas 51-65) muestra el `SortedDictionary` que se le pasa en formato de columna.
- El método `Main` (líneas 10-16) simplemente invoca `CollectWords` (línea 13), luego pasa el `SortedDictionary<string, int>` devuelto por `CollectWords` a `DisplayDictionary` en la línea 15.

### Metodo CollecWords
El método `CollectWord`s (líneas 19-48) comienza inicializando la variable local dictionary con un nuevo `SortedDictionary<string, int>` (línea 22). Las líneas 24-25 solicitan al usuario e ingresan una oración como una cadena. Utilizamos el método estático `Split` de la clase `Regex` (introducido en la sección en línea del Capítulo 16 en http://www.deitel.com/books/CSharp6FP) en la línea 28 para dividir la cadena por sus caracteres de espacio en blanco. En la expresión regular `\s+`, `\s` significa espacio en blanco y `+` significa uno o más de la expresión a su izquierda, por lo que las palabras están separadas por uno o más caracteres de espacio en blanco, que se descartan. Esto crea un array de "palabras", que luego almacenamos en la variable local `words`.

### Los métodos `ContainsKey` y `Add` de `SortedDictionary`.
Los métodos `ContainsKey` y `Add` de `SortedDictionary` (líneas 31-45) iteran a través del array `words`. Cada palabra se convierte a minúsculas con el método `ToLower` de `string`, luego se almacena en la variable `key` (línea 33). Luego, la línea 36 llama al método `ContainsKey` de `SortedDictionary` para determinar si la palabra está en el diccionario. Si es así, esa palabra ocurrió previamente en la oración. Si el `SortedDictionary` no contiene una entrada para la palabra, la línea 43 utiliza el método `Add` de `SortedDictionary` para crear una nueva entrada en el diccionario, con la palabra en minúsculas como la clave y 1 como el valor.

> **Error común de programación 19.2**
Utilizar el método Add para agregar una clave que ya existe en la tabla hash provoca un ArgumentException.

### Índice del SortedDictionary
Si la palabra ya es una clave en la tabla hash, la línea 38 utiliza el índice del `SortedDictionary` para obtener y establecer el valor asociado a la clave (el recuento de palabras) en el diccionario. Utilizar el accessor `set` con una clave que no existe en la tabla hash crea una nueva entrada, como si hubieras utilizado el método `Add`, por lo que la línea 43 podría haber sido escrita como:

```
dictionary[key] = 1;
```

### Método `DisplayDictionary`
La línea 47 devuelve el diccionario al método `Main`, que luego lo pasa al método `DisplayDictionary` (líneas 51-65), que muestra todos los pares **clave-valor**. Este método utiliza la propiedad de solo lectura `Keys` (línea 59) para obtener una `ICollection<T>` que contiene todas las claves. Dado que la interfaz `ICollection<T>` extiende `IEnumerable<T>`, podemos usar esta colección en la instrucción `foreach` en las líneas 59-62 para iterar sobre las claves. Este bucle accede y muestra cada clave y su valor correspondiente utilizando la variable de iteración y el accessor de obtención del índice del `Sorted Dictionary`. Cada clave y valor se muestra alineado a la izquierda en un ancho de campo de 12 posiciones. Dado que un `SortedDictionary` almacena sus pares **clave-valor** en un árbol binario de búsqueda, los pares **clave-valor** se muestran con las claves en orden ordenado. La línea 64 utiliza la propiedad `Count` de `SortedDictionary` para obtener el número de pares **clave-valor** en el diccionario.

### Propiedad Values de SortedDictionary
Si no necesitas las claves, la clase `SortedDictionary` también proporciona una propiedad `Values` de solo lectura que obtiene una `ICollection<T>` de todos los valores almacenados en el `SortedDictionary`. Podrías usar esta propiedad para iterar a través de los valores almacenados en el `SortedDictionary` sin preocuparte por sus claves correspondientes.

