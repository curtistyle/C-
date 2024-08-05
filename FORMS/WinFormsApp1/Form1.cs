using System.Collections;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonResultado_Click(object sender, EventArgs e)
        {

            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            if (radioButtonSuma.Checked)
            {
                keyValuePairs["Resultado"] = Operaciones.Suma(textBoxX.Text, textBoxY.Text);

                Form2 form2 = new Form2(keyValuePairs);
                
                form2.ShowDialog();
                
            }
            else if (radioButtonResta.Checked)
            {
                keyValuePairs["Resultado"] = Operaciones.Resta(textBoxX.Text, textBoxY.Text);

                Form2 form2 = new Form2(keyValuePairs);
                
                form2.ShowDialog();
               
            }
        }
    }

    static internal class Operaciones
    {
        public static int Suma(string x, string y)
        {
            int value_x = int.Parse(x);
            int value_y = int.Parse(y);

            return value_x + value_y;
        }

        public static int Resta(string x, string y)
        {
            int value_x = int.Parse(x);
            int value_y = int.Parse(y);

            return value_x - value_y;
        }
    }
}
