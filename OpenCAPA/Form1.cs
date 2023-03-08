using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCAPA_Engine;

namespace OpenCAPA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            DataLayer data = new DataLayer();
            listView1.Items.Add(data.LoadCapaItem());
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateForm forms = new CreateForm();
            forms.ShowDialog();
        }
    }
}