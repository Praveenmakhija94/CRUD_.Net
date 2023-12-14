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
using System.Xml.Linq;

namespace WindowsJune17_CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'netClassDataSet.School' table. You can move, or remove it, as needed.
            this.schoolTableAdapter.Fill(this.netClassDataSet.School);

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            string name = textBox1.Text;
            string city = textBox2.Text;
            if (name == "" || city == "")
            {
                MessageBox.Show("Please enter data in Name & City");
            }
            else
            {
                string connectionString = "Data source=DESKTOP-28LP6P0\\MSSQLSERVER02; Database=NetClass; Integrated Security=True";

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();


                string query = "Insert into School(Name,City) values('" + name + "','" + city + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data source=DESKTOP-28LP6P0\\MSSQLSERVER02; Database=NetClass; Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            int id = Convert.ToInt32(textBox3.Text);
            bool isExists = IsRecordExists(id);
            if (isExists)
            {
                string query = "Delete from school where Id=" + id;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Deleted");
            }
            else
            {
                MessageBox.Show("Record is not avilable in the database for this id");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data source=DESKTOP-28LP6P0\\MSSQLSERVER02; Database=NetClass; Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string name = textBox1.Text;
            string city = textBox2.Text;
            int Id = Convert.ToInt32(textBox3.Text);

            //id is exist in database
            bool isExists = IsRecordExists(Id);
            if (isExists)
            {



                string query = "Update School set Name='" + name + "','" + city + "','" + Id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
            }
            else
            {
                MessageBox.Show("Record is not avilable");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "Data source=DESKTOP-28LP6P0\\MSSQLSERVER02; Database=NetClass; Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

          

            string query = "Select * from Students";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt= new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource=dt;

        }
        public void FillData()
        {
            string connectionString = "Data source=DESKTOP-28LP6P0\\MSSQLSERVER02; Database=NetClass; Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string query = "Select * from Students";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }


        public bool IsRecordExists(int id)
        {
            string connectionString = "Data source=DESKTOP-28LP6P0\\MSSQLSERVER02; Database=NetClass; Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();



            string query = "Select * from Students where Id=" + id;
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

           if(dt.Rows.Count>0)
            
                return true;
           else
                return false;

            
        }

        public void clearData()
        {
            textBox1.Text = " ";
                textBox2.Text = " ";
            textBox3.Text = " ";
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var datetime = DateTime.Now;

            int id = Convert.ToInt32(textBox3.Text);
            string connectionString = "Data source=DESKTOP-28LP6P0\\MSSQLSERVER02; Database=NetClass; Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string query = "Select * from Students where Id=" + id;
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                textBox1.Text = dt.Rows[0][1].ToString();
                textBox2.Text = dt.Rows[0][2].ToString();
            }
            else
                MessageBox.Show("Record is not available in the database for this Id");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
