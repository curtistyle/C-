using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThisIsTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadlizarTodasLasTareas();

            Console.ReadLine();
        }

        static void ReadlizarTodasLasTareas()
        {
            var tarea1 = Task.Run(() =>
            {
                EjecutarTarea1();
            });

            // espera a que la tarea1 termine, asi ejecuta las siguientes tarea.
            //tarea1.Wait();

            var tarea2 = Task.Run(() =>
            {
                EjecutarTarea2();
            });

            // espera a que la tarea1 y tarea2 termine para ejecutar la tarea3
            Task.WaitAll(tarea1, tarea2);
            
            // espera a que al menos una terea se complete para ejecutar la tarea3
            //Task.WaitAny(tarea1, tarea2);

            var tarea3 = Task.Run(() =>
            {
                EjecutarTarea3();
            });
        }

        static void EjecutarTarea1()
        {
            for (int i = 0; i < 5; i++)
            {
                var idThread = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(1000);

                Console.WriteLine($"Tarea \'1\' ID Thread= {idThread}");
            }
        }

        static void EjecutarTarea2()
        {
            for (int i = 0; i < 5; i++)
            {
                var idThread = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(500);

                Console.WriteLine($"Tarea \'2\' ID Thread= {idThread}");
            }
        }

        static void EjecutarTarea3()
        {
            for (int i = 0; i < 5; i++)
            {
                var idThread = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(500);

                Console.WriteLine($"Tarea \'3\' ID Thread= {idThread}");
            }
        }
    }
}
