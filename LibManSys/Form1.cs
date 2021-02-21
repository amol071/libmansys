using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=slibrary;User ID=amol;Password=amol");
        SqlCommand cmd;
        SqlDataReader dr;
        
        string sql;
        bool Mode = true;
        string id;

        private void button1_Click(object sender, EventArgs e)
        {
            string catname = txtname.Text;
            string status = txtstatus.SelectedItem.ToString();
            if (Mode == true)
            {
                sql = "insert into category(catname,status)values(@catname,@status)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@catname", catname);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Created Successfully");
                txtname.Clear();
                txtstatus.SelectedIndex = -1;
                txtname.Focus();
            }
        }
    }
}
