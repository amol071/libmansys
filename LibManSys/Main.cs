using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        //Category Button
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 category = new Form1();
            category.Show();
        }
    }
}
