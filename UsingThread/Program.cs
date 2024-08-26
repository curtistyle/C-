void Contador()
{
	for(Int16 index = 1; index < 12000; index++)
	{
		Console.WriteLine(index);
	}
}


Thread myThread = new Thread(new ThreadStart(Contador));

myThread.Start();
Console.WriteLine("Hello World!");
Console.WriteLine("Hello World!");
Console.WriteLine("Hello World!");
Console.WriteLine("Hello World!");
Console.WriteLine("Hello World!");
Console.Read();