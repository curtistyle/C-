using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThisIsTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            Task tarea = new Task(EjecutarTarea);
            s
            tarea.Start();
            */

            Task tarea1 = Task.Run(() => EjecutarTarea1());

            // hasta que no finalice la terea1 no comienza la tarea 2
            Task tarea2 = tarea1.ContinueWith(EjecutarTarea2);

            

            Console.ReadLine();
        }

        static void EjecutarTarea1()
        {
            for (int i = 0; i < 10; i++)
            {
                var idHilo = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(1000);

                Console.WriteLine("El id del hilo de la tarea es: " + idHilo);
            }
        }

        static void EjecutarTarea2(Task obj)
        {
            for (int i = 0;i < 10; i++)
            {
                var idHilo = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(1000);

                Console.WriteLine("El id del hilo de la tarea es: " + idHilo);
            }
        }

    }
}
