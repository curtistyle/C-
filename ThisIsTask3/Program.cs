using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThisIsTask3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Task<int> tarea1 = Task.Run(() =>
            {
                int ac = 0;
                var idThread = Thread.CurrentThread.ManagedThreadId;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Tarea1 - IDThread: {idThread}");
                    Thread.Sleep(1000);

                    ac += i;
                }
                return ac;
            });

/*            var tarea1 = new Task<int>(() => 
            {
                int ac = 0;
                var idThread = Thread.CurrentThread.ManagedThreadId;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Tarea1 - IDThread: {idThread}");
                    Thread.Sleep(1000);

                    ac += i;
                }
                return ac;
            });*/

            
            tarea1.Wait();
            Console.WriteLine(tarea1.Result);

            Console.ReadLine();

        }

/*        static Task<int> TareaAcumulador()
        {
            var idThread = Thread.CurrentThread.ManagedThreadId;
            int acumulador = 0;

            for (int i = 0; i < 10; i++) 
            { 
                Console.WriteLine($"Tarea Acumulador - IDThread: {idThread}");
                acumulador += i;
            }

            return acumulador;
        }*/
    }
}
