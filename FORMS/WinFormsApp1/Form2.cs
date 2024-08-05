namespace WinFormsApp1
{
    public partial class Form2 : Form
    {


        public Form2(Dictionary<string, int> resultado)
        {
            InitializeComponent();
            
            labelResultado.Text += resultado["Resultado"].ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
