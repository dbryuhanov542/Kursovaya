using System;
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
    public partial class Edit_form : Form
    {
        public Edit_form()
        {
            InitializeComponent();
            dataGridView1.MultiSelect = false;
        }

        // TODO: Реализовать функцию поиска по БД

        private void Form4_Load(object sender, EventArgs e)
        {
            DataTable data = Functions.Connect("select * from requests");
            dataGridView1.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main_form f3 = new Main_form();
            f3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите данные для ввода.");
            }
            else
            {
                dataGridView1.CurrentCell.Value = textBox1.Text;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //selected_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            string s = dataGridView1.CurrentCell.Value.ToString();
            textBox1.Text = s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable data = Functions.Connect(@" DELETE FROM KursovayaDB.requests WHERE id =" + 
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            DataTable data1 = Functions.Connect("select * from requests");
            dataGridView1.DataSource = data1;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable data1 = Functions.Connect(@"SELECT * FROM `kursovayadb`.`requests` WHERE (CONVERT(`id` USING utf8) LIKE '%" + textBox2.Text + "%' OR CONVERT(`request_type` USING utf8) LIKE '" + textBox2.Text + "' OR CONVERT(`client_name` USING utf8) LIKE '" + textBox2.Text + "' OR CONVERT(`data_zakaza` USING utf8) LIKE '" + textBox2.Text + "' OR CONVERT(`date_end` USING utf8) LIKE '" + textBox2.Text + "' OR CONVERT(`price` USING utf8) LIKE '" + textBox2.Text + "' OR CONVERT(`comment` USING utf8) LIKE '" + textBox2.Text + "')");
            dataGridView1.DataSource = data1;
        }
    }
}
