using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeoriaConjuntos
{
    public class Conjunto<T>
    {
        private List<T> elementos;

        public Conjunto(T[] args)
        {
            elementos = new List<T>(args);
        }

        public int Length
        {
            get
            {
                return elementos.Capacity;
            }
        }
        


    }
}
