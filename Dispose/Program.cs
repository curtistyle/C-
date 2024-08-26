using Dispose;

string path = @"D:\Progarmacion\C-\Dispose\myText.txt";

// Exception
/*var writer = new Writer(path);
var writer2 = new Writer(path);

writer.Write("1");
writer2.Write("2");*/

using (var writer = new Writer(path)) writer.Write("1");
using (var writer2 = new Writer(path)) writer2.Write("2");

