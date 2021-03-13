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
            load();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-7C4GOGU\\SQLEXPRESS;Initial Catalog=slibrary;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        string sql;
        bool Mode = true;
        string id;

        public void load()
        {
            sql = "select * from category";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2]);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string catname = txtname.Text;
            string status = txtstatus.SelectedItem.ToString();
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (Mode == true)
            {
                sql = "insert into category(catname,status)values(@catname,@status)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@catname", catname);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Category Created Successfully");
                txtname.Clear();
                txtstatus.SelectedIndex = -1;
                txtname.Focus();
            }
            else
            {
                sql = "UPDATE category SET catname = @catname, status = @status WHERE id = @id";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@catname", catname);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Category Updated!");
                txtname.Clear();
                txtstatus.SelectedIndex = -1;
                txtname.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Hi");

            if (e.ColumnIndex == dataGridView1.Columns["edit"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                getid(id);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["delete"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sql = "DELETE FROM category where id=@id";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Deleted!");
                txtname.Clear();
                txtstatus.SelectedIndex = -1;
                txtname.Focus();
                con.Close();
            }
        }

        public void getid(string id)
        {
            sql = "SELECT * FROM category WHERE id = '" + id + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtname.Text = dr[1].ToString();
                txtstatus.Text = dr[2].ToString();
            }
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
