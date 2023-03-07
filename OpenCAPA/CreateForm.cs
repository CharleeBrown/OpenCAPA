namespace OpenCAPA
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
            
            listView1.View = View.Details;
            listView1.Columns.Add("Main");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem("test");
            item.SubItems.Add("Other");
            //listBox1.Items.Add("TEst");
            listView1.Items.Add(item);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedItem = listView1.SelectedItems[0];
            MessageBox.Show(selectedItem.SubItems[1].Text);
        }
    }
}
