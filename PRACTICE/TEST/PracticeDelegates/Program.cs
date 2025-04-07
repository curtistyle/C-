

IntView i, x, c, ic, all;

i = new IntView(View.AsInt);
x = new IntView(View.AsHexa);
c = new IntView(View.AsChar);

Console.Write("\ni:    "); i(32);
Console.Write("\nx:    "); x(32);
Console.Write("\nc:    "); c(32);

all = i + x + c;  // callback in that oreder 
Console.Write("\nall: "); all(32);

ic = all - x;
Console.Write("\nic:  "); ic(32);

delegate void IntView(int c);

class View
{
	public static void AsChar(int c)
	{
		Console.Write("'{0}' ", (char)c);
	}

	public static void AsHexa(int c)
	{
		Console.Write("0x{0:X} ", c);
	}

	public static void AsInt(int c)
	{
		Console.Write("{0} ", c);
	}
}

