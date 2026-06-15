using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        public string connString = "Server=KRN-20-202-C7\\MSSQLSERVER02;Database=Shoes;Integrated Security=True;TrustServerCertificate=True";
        public Form2(int role, string fio)
        {
            InitializeComponent();
            if (role == 0)
            {
                comboBox1.Hide();
                comboBox2.Hide();
                textBox1.Hide();
                label1.Text = "Пользователь - " + fio;
                button2.Hide();
            }
            else if (role == 3)
            {
                comboBox1.Hide();
                comboBox2.Hide();
                label1.Text = "Пользователь - " + fio;
                button2.Hide();
            }
            else if (role == 2)
            {
                comboBox2.Hide();
                label1.Text = "Пользователь - " + fio;
                button2.Hide();
            }
            else if (role == 1)
            {
                label1.Text = "Пользователь - " + fio;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Заходите еще", "До встречи", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form1 newform = new Form1();
            newform.Show();
            this.Hide();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string query = "SELECT * FROM Products";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserControl1 usercontrol = new UserControl1();
                usercontrol.Card(
                reader["nameproduct"].ToString(),
                reader["description"].ToString(),
                reader["producer"].ToString(),
                reader["provider"].ToString(),
                reader["sklad"].ToString(),
                reader["price"].ToString());
                flowLayoutPanel1.Controls.Add(usercontrol);
                }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string search = textBox1.Text.Trim();
            string query = "SELECT * FROM Products";
            flowLayoutPanel1.Controls.Clear();
            if (!string.IsNullOrEmpty(search))
            {
                query += " WHERE nameproduct LIKE '%" + search + "%'";
            }
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserControl1 usercontrol = new UserControl1();
                usercontrol.Card(
                reader["nameproduct"].ToString(),
                reader["description"].ToString(),
                reader["producer"].ToString(),
                reader["provider"].ToString(),
                reader["sklad"].ToString(),
                reader["price"].ToString());
                flowLayoutPanel1.Controls.Add(usercontrol);
            }
        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Products";
            if (comboBox1.SelectedIndex == 0)
            {
                query += " WHERE category = '1'";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                query += " WHERE category = '2'";
            }
            flowLayoutPanel1.Controls.Clear();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserControl1 usercontrol = new UserControl1();
                usercontrol.Card(
                reader["nameproduct"].ToString(),
                reader["description"].ToString(),
                reader["producer"].ToString(),
                reader["provider"].ToString(),
                reader["sklad"].ToString(),
                reader["price"].ToString());
                flowLayoutPanel1.Controls.Add(usercontrol);
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Products";
            if (comboBox2.SelectedIndex == 0)
            {
                query += " WHERE producer = '1'";
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                query += " WHERE producer = '2'";
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                query += " WHERE producer = '3'";
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                query += " WHERE producer = '4'";
            }
            else if (comboBox2.SelectedIndex == 4)
            {
                query += " WHERE producer = '5'";
            }
            else if (comboBox2.SelectedIndex == 5)
            {
                query += " WHERE producer = '6'";
            }
            flowLayoutPanel1.Controls.Clear();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserControl1 usercontrol = new UserControl1();
                usercontrol.Card(
                reader["nameproduct"].ToString(),
                reader["description"].ToString(),
                reader["producer"].ToString(),
                reader["provider"].ToString(),
                reader["sklad"].ToString(),
                reader["price"].ToString());
                flowLayoutPanel1.Controls.Add(usercontrol);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 newform = new Form3();
            newform.Show();
            this.Hide();
        }
    }
}
