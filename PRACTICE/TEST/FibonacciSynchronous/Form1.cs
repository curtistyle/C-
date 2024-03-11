// Cod 21.2 SynchronousTestForm
// Fibonacci calculations performed sequentially
using System;
using System.Windows.Forms;

namespace FibonacciAsynchronous
{
    public partial class SynchronousTestForm : Form
    {
        public SynchronousTestForm()
        {
            InitializeComponent();
        }

        // start asynchronous calls to Fibonacci
        private void startButton_Click(object sender, EventArgs e)
        {
            // calculate Fibonacci (41)
            outputTextBox.Text = "Start Task to calculate Fibonacci(41)\r\n";
            outputTextBox.Refresh(); // force outputTextBox to repaint
            DateTime startTime1 = DateTime.Now; // time before calculation
            long result1 = Fibonacci(41); // synchronous call
            DateTime endTime1 = DateTime.Now; // time alter calculation

            // display results for Fibonacci
            outputTextBox.AppendText($"Fibonacci(41) = {result1}\r\n");
            double minutes = (endTime1 - startTime1).TotalMinutes;
            outputTextBox.AppendText($"Calculation time = {minutes:F6} minutes\r\n\r\n");

           
            // calculate Fibonnaci(40)
            outputTextBox.AppendText("Calculating Fibonacci(40)\r\n");
            outputTextBox.Refresh(); // force outputTextBox to repaint
            DateTime startTime2 = DateTime.Now;
            long result2 = Fibonacci(40); // synchronous call
            DateTime endTime2 = DateTime.Now;

            // display results for Fibonacci(40)
            outputTextBox.AppendText($"Fibonacci(40) = {result2}\r\n");
            minutes = (endTime2 - startTime2).TotalMinutes;
            outputTextBox.AppendText($"Calculation here = {minutes:F6} minutes\r\n\r\n");
          
            
            // show total calculation time
            double totalMinutes = (endTime2 - startTime2).TotalMinutes;
            outputTextBox.AppendText($"Total calculation time = {totalMinutes:F6} minutes\r\n");
        }

        // Recursively calculates Fibonacci numbers
        public long Fibonacci(long n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return Fibonacci( n - 1 ) + Fibonacci( n - 2 );
            }
        }
    }
}
