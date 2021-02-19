﻿using System;
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
    public partial class Auth_form : Form
    {

        public Auth_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Введите данные для входа");
            }
            else
            {
                DataTable data = Functions.Connect("select * from KursovayaDB.user_data where username = '"
                   + textBox1.Text + "' and userpass = '" + textBox2.Text + "'");
                if (data.Rows.Count == 1)
                {
                    Main_form f3 = new Main_form();
                    f3.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Reg_form f2 = new Reg_form();
            f2.Show();
            Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            DBset_form dBset = new DBset_form();
            dBset.Show();
            Hide();
        }
    }
}
