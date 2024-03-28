namespace ListViewControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textID.Text) || string.IsNullOrEmpty(textName.Text))
            {
                return;
            }
            ListViewItem item = new ListViewItem(textID.Text);
            item.SubItems.Add(textName.Text);
            listView1.Items.Add(item);
            textID.Clear();
            textName.Clear();
            textID.Focus();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All File|*.*", ValidateNames=true, Multiselect = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach(string f in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(f);
                        ListViewItem items = new ListViewItem(fi.Name);
                        items.SubItems.Add(fi.FullName);
                        listView1.Items.Add(items);
                    }
                }
            }
        }
    }
}
