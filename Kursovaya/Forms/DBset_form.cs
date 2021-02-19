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

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server = textBox1.Text;
            string port = textBox2.Text;
            string DBname = textBox3.Text;
            string DBlog = textBox4.Text;
            string DBpass = textBox5.Text;
            Properties.Settings.Default.serverIp = server;
            label18.Text = Properties.Settings.Default.serverIp.ToString();
            Properties.Settings.Default.port_num = port;
            label17.Text = Properties.Settings.Default.port_num.ToString();
            Properties.Settings.Default.DBname = DBname;
            label16.Text = Properties.Settings.Default.DBname.ToString();
            Properties.Settings.Default.DBlog = DBlog;
            label15.Text = Properties.Settings.Default.DBlog.ToString();
            Properties.Settings.Default.DBpass = DBpass;
            label14.Text = Properties.Settings.Default.DBpass.ToString();
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main_form fm = new Main_form();
            fm.Show();
            this.Hide();
        }

    }
}
