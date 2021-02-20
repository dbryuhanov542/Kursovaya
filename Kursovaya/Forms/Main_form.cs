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
            if (comboBox1.Text != "")
            {
                if (textBox1.Text != "") 
                {
                    if (textBox2.Text != "")
                    {
                        string date_end = comboBox2.Text + "/" + comboBox3.Text + "/" + comboBox4.Text;
                        string date = DateTime.Now.ToString("dd.MM.yyyy | HH:mm:ss");
                        string comm = @"insert into KursovayaDB.requests (request_type, client_name, data_zakaza, date_end, price, comment) 
                    values (@request_name, @client_name, @data_zakaza, @date_end, @price, @comment)";
                        DataTable data = Functions.Add(comm, comboBox1.Text, textBox1.Text, date, date_end, textBox2.Text, richTextBox1.Text);
                    }
                    else
                    {
                        MessageBox.Show("Введите стоимость заказа.");
                    }
                }
                else
                {
                    MessageBox.Show("Введите Ф.И.О клиента.");
                }
            }
            else
            {
                MessageBox.Show("Выберите тип услуги.");
            }
        }

        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_form f4 = new Edit_form();
            f4.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Auth_form form = new Auth_form();
            form.Show();
            this.Hide();
        }
    }
}
