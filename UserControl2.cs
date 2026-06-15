using System;
using System.Windows.Forms;
namespace WindowsFormsApp8
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }
        public void Card(string nomer_zakaza, string article, string dateorder, string datedelivery, string pickupcode)
        {
            label1.Text = "Номер заказа - " + nomer_zakaza;
            label2.Text = "Артикул - " + article;
            label3.Text = "Дата заказа - " + dateorder;
            label4.Text = "Дата доставки - " + datedelivery;
            label5.Text = "Код получения - " + pickupcode;
        }
    }
}
