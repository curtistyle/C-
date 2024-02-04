
using System.Collections;

Dias dia = Dias.Lunes;

Console.WriteLine(dia.ToString().GetType().Name);

/*
Console.WriteLine("foreach: ");
foreach (String diaDeLaSemana in Enum.GetNames(typeof(Dias)))
{
    Console.WriteLine(diaDeLaSemana);
}
*/

Console.WriteLine("Ingrese un dia de la semana; ");
int opc = int.Parse(Console.ReadLine());

Dias diaSeleccionado = (Dias)opc;

Console.WriteLine(diaSeleccionado);




enum Dias { Lunes, Martes, Miercoles, Jueves, Viernes };

