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
    public partial class Main_form : Form
    {
        public Main_form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            textBox1.Text = "";
            richTextBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date_end = comboBox2.Text + "/" + comboBox3.Text + "/" + comboBox4.Text;
            string date = DateTime.Now.ToString("dd.MM.yyyy | HH:mm:ss");
            var con = new MySqlConnection(@"User Id=root;Password='';Host=localhost;Database=KursovayaDB;port=3306; charset = utf8");
            var command = new MySqlCommand(@"insert into KursovayaDB.requests (request_type, client_name, data_zakaza, date_end, price, comment) 
            values (@request_name, @client_name, @data_zakaza, @date_end, @price, @comment)", con);
            command.Parameters.AddWithValue("@request_name", comboBox1.Text);
            command.Parameters.AddWithValue("@client_name", textBox1.Text);
            command.Parameters.AddWithValue("@data_zakaza", date);
            command.Parameters.AddWithValue("@date_end", date_end);
            command.Parameters.AddWithValue("@price", textBox2.Text);
            command.Parameters.AddWithValue("@comment", richTextBox1.Text);
            con.Open();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Заявка успешно зарегистрирована.");
                comboBox1.Text = "";
                textBox2.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                textBox1.Text = "";
                richTextBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сохранение заявки не удалась \n Ошибка: " + ex.Message);
            }
        }

        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_form f4 = new Edit_form();
            f4.Show();
            this.Hide();
        }

        private void настройкиБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBset_form f5 = new DBset_form();
            f5.Show();
            this.Hide();
        }
    }
}
