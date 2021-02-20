using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    public partial class DBset_form : Form
    {

        public DBset_form()
        {
            InitializeComponent();
        }

        string server = Properties.Settings.Default.serverIp.ToString();
        string port_num = Properties.Settings.Default.port_num.ToString();
        string db_name = Properties.Settings.Default.DBname.ToString();
        string db_log = Properties.Settings.Default.DBlog.ToString();
        string db_pass = Properties.Settings.Default.DBpass.ToString();
        bool conn_status;

        private void Form5_Load(object sender, EventArgs e)
        {
            
            label18.Text = server;
            label17.Text = port_num;
            label16.Text = db_name;
            label15.Text = db_log;
            label14.Text = db_pass;
            textBox1.Text = server;
            textBox2.Text = port_num;
            textBox3.Text = db_name;
            textBox4.Text = db_log;
            textBox5.Text = db_pass;



            if (label18.Text != server)
            {
                conn_status = false ;
            }
            if (conn_status == false)
            {
                label19.Text = "Подключение отсутствует.";
                label19.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label19.Text = "Подключение установлено.";
                label19.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server = textBox1.Text;
            string port = textBox2.Text;
            string DBname = textBox3.Text;
            string DBlog = textBox4.Text;
            string DBpass = textBox5.Text;
            Properties.Settings.Default.serverIp = server;
            Properties.Settings.Default.port_num = port;
            Properties.Settings.Default.DBname = DBname;
            Properties.Settings.Default.DBlog = DBlog;
            Properties.Settings.Default.DBpass = DBpass;
            Properties.Settings.Default.Save();
            label18.Text = Properties.Settings.Default.serverIp.ToString();
            label17.Text = Properties.Settings.Default.port_num.ToString();
            label16.Text = Properties.Settings.Default.DBname.ToString();
            label15.Text = Properties.Settings.Default.DBlog.ToString();
            label14.Text = Properties.Settings.Default.DBpass.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Auth_form fm = new Auth_form();
            fm.Show();
            this.Hide();
        }

    }
}
