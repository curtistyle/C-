// rectangular arrays

using System.Collections;

int[,] matriz = { { 1, 0}, { 0, 1 } };

// jagged arrays (arreglo irregular)

int[][] jagged =
{
    new int[] { 1, 2 },
    new int[] { 3 },
    new int[] { 4, 5, 6 }
};

// 

int[][] c;

c = new int[2][];   // create 2 rows
c[0] = new int[5];  // create 5 columns for row 0
c[1] = new int[3];  // create 3 columns for row 1


// Two-Dimensional Array example: displaying element values

void InitArray()
{
    int[,] rectangular = { { 1, 2, 3 }, { 4, 5, 6 } };

    int[][] jagged = { new int[] { 1, 2 },
                       new int[] { 3 },
                       new int[] { 4, 5, 6 },
    };

    OutputArray(rectangular);
    Console.WriteLine();
    AnotherOutputArray(jagged);

    static void OutputArray(int[,] array)
    {
        Console.WriteLine("Values in the rectangular array by row are");

        for (var row = 0; row < array.GetLength(0); row++)
        {
            for (var col = 0; col < array.GetLength(1); col++)
            {
                Console.Write($"{array[row, col]}   ");
            }
            Console.WriteLine();
        }

    }
    
    static void AnotherOutputArray(int[][] array)
    {
        Console.WriteLine("Values in the jagged array by row are");

        foreach (var row in array)
        {
            foreach (var element in row)
            {
                Console.Write($"{element}   ");
            }

            Console.WriteLine();
        }
    }
}

InitArray();