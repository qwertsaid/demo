using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApp8
{
    public partial class Form3 : Form
    {
        public string connString = "Server=KRN-20-202-C7\\MSSQLSERVER02;Database=Shoes;Integrated Security=True;TrustServerCertificate=True";
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string query = "SELECT * FROM Orders";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserControl2 usercontrol = new UserControl2();
                usercontrol.Card(
                reader["nomer_zakaza"].ToString(),
                reader["article"].ToString(),
                reader["dateorder"].ToString(),
                reader["datedelivery"].ToString(),
                reader["pickupcode"].ToString());
                flowLayoutPanel1.Controls.Add(usercontrol);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newform = new Form1();
            newform.Show();
            this.Hide();
        }
    }
}
