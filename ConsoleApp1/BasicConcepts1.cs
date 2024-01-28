

byte typeByte = 2;
sbyte typeSbyte = 3;
short typeShort = 4;
ushort typeUshort = 5;
int typeInt = 6;
uint typeUint = 7;
long typeLong = 8;
ulong typeULong = 9;
ulong typeFloat = 10;
float typeDouble = 11;
object typeObject = null;
char typeChar = '1';
string typeString = "12";
decimal typeDecimal = 13;
bool typeBoolean = false;
DateTime TypeDateTime = DateTime.MinValue;

Console.WriteLine("Primitive DataTypes:");
Console.WriteLine();
Console.WriteLine("This is " + typeByte.GetType().Name + " and his range 0 to 255");
Console.WriteLine(" - Bytes: 1");
Console.WriteLine("This is " + typeSbyte.GetType().Name + " and his range -128 to 127");
Console.WriteLine(" - Bytes: 1");
Console.WriteLine("This is " + typeShort.GetType().Name + " and his range -32,768 to 32,767");
Console.WriteLine(" - Bytes: 2");
Console.WriteLine("This is " + typeUshort.GetType().Name + " and his range 0 to 65,535");
Console.WriteLine(" - Bytes: 2");
Console.WriteLine("This is " + typeInt.GetType().Name + " and his range -2 billion to 2 billion");
Console.WriteLine(" - Bytes: 4");
Console.WriteLine("This is " + typeUint.GetType().Name + " and his range 0 to 4 billion");
Console.WriteLine(" - Bytes: 4");
Console.WriteLine("This is " + typeLong.GetType().Name + " and his range -9 quintillion to 9 quintillion");
Console.WriteLine(" - Bytes: 8");
Console.WriteLine("This is " + typeULong.GetType().Name + " and his range 0 to quintillion");
Console.WriteLine(" - Bytes: 8");
Console.WriteLine("This is " + typeFloat.GetType().Name + "and his range 7 significant digits");
Console.WriteLine(" - Bytes: 4");
Console.WriteLine("This is " + typeDouble.GetType().Name + " and his range 15 significant digits");
Console.WriteLine(" - Bytes: 8");
Console.WriteLine("This is " + typeObject.GetType().Name + " and All C# Objects");
Console.WriteLine(" - Bytes: 4 bytes address");
Console.WriteLine("This is " + typeChar.GetType().Name + " and his unicode characters");
Console.WriteLine(" - Bytes: 2");
Console.WriteLine("This is " + typeString.GetType().Name + " and length up to 2 billion bytes");
Console.WriteLine(" - Bytes: 4 bytes address");
Console.WriteLine("This is " + typeDecimal.GetType().Name + " and 28 to 29 significant digist");
Console.WriteLine(" - Bytes: 24");
Console.WriteLine("This is " + typeBoolean.GetType().Name + " true or false state");
Console.WriteLine(" - Bytes: 1");
Console.WriteLine("This is " + TypeDateTime.GetType().Name + " and his range 0:00:00am 1/1/01 to\r\n11:59:59pm 12/31/9999");
Console.WriteLine(" - Bytes: 8");



