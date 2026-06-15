using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public string connString = "Server=KRN-20-202-C7\\MSSQLSERVER02;Database=Shoes;Integrated Security=True;TrustServerCertificate=True";
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы успешно вошли как гость", "Добро пожаловать", MessageBoxButtons.OK, MessageBoxIcon.Information);
            int role = 0;
            string fio = "Гость";
            Form2 newform = new Form2(role, fio);
            newform.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните оба поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string query = "SELECT * FROM Users WHERE login=@login AND password=@password";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@login", login);
            sqlCommand.Parameters.AddWithValue("@password", password);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Вы успешно авторизировались", "Добро пожаловать", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int role = reader.GetInt32(1);
                string fio = reader.GetString(2) + " " + reader.GetString(3) + " " + reader.GetString(4);
                Form2 newform = new Form2(role, fio);
                newform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
