using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataStructure
{
    

    public static class BusquedaBinaria
    {
        
        
        public static int[] Busqueda(int[] lista, int value)
        {
            if (lista.Length == 0)
            {
                return [-1];
            }
            else if (value == lista[lista.Length / 2])
            {
                return [value];
            }
            else if (value > lista[lista.Length / 2])
            {
                var aux = lista[(lista.Length / 2)..];
                //Console.ReadKey();
                return Busqueda(lista[(lista.Length/2)..], value);
            }
            else
            {
                var aux = lista[..(lista.Length / 2)];
                //Console.ReadKey();
                return Busqueda(lista[..(lista.Length / 2)], value);
            }
        }
    }
}
