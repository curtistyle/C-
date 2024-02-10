using ClassesAndObjects;

// create and initialize a Time object
var time = new Time();

// out string representations of the time
Console.WriteLine($"The initial universal time is: {time.ToUniversalString()}");
Console.WriteLine($"The initial standar time is: {time.ToString()}");
Console.WriteLine();

// change time and output updated time
time.SetTime(13, 27, 6);
Console.WriteLine($"Universal time after SetTime is: {time.ToUniversalString()}");
Console.WriteLine($"Standard time after SetTime is: {time.ToString()}");
Console.WriteLine(); // output blank line

// attempt to set time with invalid values
try
{
    time.SetTime(99, 99, 99);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message + "\n");
}

 // display time after attempt to set invalid values 
Console.WriteLine("After attempting invalid settings: ");
Console.WriteLine($"Universal time: {time.ToUniversalString()}");
Console.WriteLine($"Standard time: {time.ToString()}");