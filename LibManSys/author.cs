using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace LibManSys
{
    public partial class author : Form
    {
        public author()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-7C4GOGU\\SQLEXPRESS;Initial Catalog=slibrary;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        string sql;
        bool Mode = true;
        string id;
        
        private void author_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            string address = txtaddress.Text;
            string phone = txtphone.Text;


            if (Mode == true)
            {
                sql = "insert into author(name,address,phone )values(@name,@address,@phone)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@phone", phone);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("author Created Successfully");
                txtname.Clear();
                txtaddress.Clear();
                txtphone.Clear();



                txtname.Focus();
            }
            else
            {
                sql = "UPDATE category SET catname = @catname, status = @status WHERE id = @id";
                con.Open();
                cmd = new SqlCommand(sql, con);
               // cmd.Parameters.AddWithValue("@catname", catname);
                //cmd.Parameters.AddWithValue("@status", status);
                //cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Category Updated!");
                txtname.Clear();
                //txtstatus.SelectedIndex = -1;
                txtname.Focus();
            }



        }
    }
}
