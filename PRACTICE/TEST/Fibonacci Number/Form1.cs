// Fibonacci Form Cidigo 21.1
// Realizar un cálculo intensivo desde una aplicación GUI
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fibonacci_Number
{
    public partial class Form1 : Form
    {
        private long n1 = 0;
        private long n2 = 1;
        private int count = 1; // numero de fibonacci actual para mostrar
        
        public Form1()
        {
            InitializeComponent();
        }

        // inicia una tarea asíncrona para calcular el número de Fibonacci especificado
        private async void calculateButton_Click(object sender, EventArgs e)
        {
            // recive la entrada del usuario
            int number = int.Parse(textBox1.Text);
            
            asyncResult.Text = "Calculating...";

            // Tarea para realizar el cálculo de Fibonacci en un hilo separado
            Task<long> fibonacciTask = Task.Run(() => Fibonacci(number));
            
            // espera a que se complete la tarea (fibonacciTask) en un hilo 
            await fibonacciTask;
            
            // muestra el resultado cuando se haya completado la tarea
            asyncResult.Text = fibonacciTask.Result.ToString();
        }

        // calcular el siguiente número de Fibonacci de forma iterativa
        private void nextNumberButton_Click(object sender, EventArgs e)
        {
            // calcula el siguiente numero de fibonacci
            long temp = n1 + n2;
            n1 = n2;
            n2 = temp;
            ++count;

            // muestra el siguente numero de fibonacci
            displayLabel.Text = $"Fibonacci of {count}:";
            syncResult.Text = n2.ToString();
        }

        // método recursivo fibonacci; calcula el enésimo número de fbnci
        public long Fibonacci(long n)
        {
            if (n == 0 || n == 1) 
            {
                return n;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
    }
}
