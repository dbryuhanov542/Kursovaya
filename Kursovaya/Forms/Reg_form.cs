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

            string reg_comm = @"insert into KursovayaDB.user_data (username, userpass, user_data, user_rank) values (@login, @password, @user_data, @user_rank)";

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Не все поля заполнены.");
            }
            else
            {
                    DataTable data = Functions.Registrate(reg_comm, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                    Auth_form f1 = new Auth_form();
                    f1.Show();
                    this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Auth_form form = new Auth_form();
            form.Show();
            this.Hide();
        }
    }
}
