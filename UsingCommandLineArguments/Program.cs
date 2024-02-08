void Main()
{
    static void InitArray(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Error: Please re-enter the entire command, including\n" +
                              "an array size, initial value and increment.");
        }
        else
        {
            // obtenemos el tamaño de la matriz desde el primer argumento de la línea de comandos
            var arrayLength = int.Parse(args[0]);
            var array = new int[arrayLength]; // creamos el arreglo

            //obtenemos el valor inicial y lo incrementa desde el argumento de la línea de comandos
            var initialValue = int.Parse(args[1]);
            var increment = int.Parse(args[2]);


            Console.WriteLine("array=", array.Length);
            // calculamos el valor para cada elemento de la matriz
            for (var counter = 0; counter < array.Length; ++counter)
            {
                array[counter] = initialValue + increment * counter;
            }

            // muestra el indice y el valor de la matriz
            Console.WriteLine($"{"Index"}{"Value",8}");
            for (int counter = 0; counter < array.Length; counter++)
            {
                Console.WriteLine($"{counter,5}{array[counter], 8}");
            }
        }
    }

    InitArray(["10", "1", "2"]);
}

Main();