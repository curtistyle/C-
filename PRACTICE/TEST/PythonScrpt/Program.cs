using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

string pathPy = @"D:\Progarmacion\C-\PRACTICE\TEST\PythonScrpt\main.py";

ScriptRuntime py = Python.CreateRuntime();
dynamic pyProgram = py.UseFile(pathPy);

dynamic list = pyProgram.getList();

foreach (var item in list)
{
    Console.WriteLine(item);
}