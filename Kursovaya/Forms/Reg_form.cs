using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kursovaya
{
    public partial class Reg_form : Form
    {
        public Reg_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new MySqlConnection(@"User Id=root;Password='';Host=localhost;Database=KursovayaDB;port=3306");
            var command = new MySqlCommand(@"insert into KursovayaDB.user_data (username, userpass) values (@login, @password)", con);
            command.Parameters.AddWithValue("@login", textBox1.Text);
            command.Parameters.AddWithValue("@password", textBox2.Text);
            con.Open();

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Введите данные для входа");
            }
            else
            {
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Пользователь успешно зарегистрирован");
                    Auth_form f1 = new Auth_form();
                    f1.Show();
                    Hide();
                }


                catch (Exception ex)
                {
                    MessageBox.Show("Регистрация не удалась \n Ошибка: " + ex.Message);
                    Auth_form f1 = new Auth_form();
                    f1.Show();
                    Hide();
                }
            }
        }
    }
}
