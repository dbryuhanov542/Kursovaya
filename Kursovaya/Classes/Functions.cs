using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kursovaya
{
    //Класс, содержащий методы функций, вызываемые в основной программе
    class Functions
    {
        //Функция
        public static DataTable Connect(string a)
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlconstr = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                Port = 3306,
                Database = "KursovayaDB",
                UserID = "root",
                Password = "",
                CharacterSet = "utf8"
            };
            MySqlConnection connect = new MySqlConnection(mysqlconstr.ToString());
            string queryString = @a;
            MySqlCommand command = new MySqlCommand(queryString, connect);
            try
            {
                connect.Open();

                MySqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Операция не удалась /n Ошибка: " + ex.Message);
            }

            return dt;
        }


        static public DataTable Add(string comm, string req_type, string cl_name, string ord_date, string date_end, string price, string comment)
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlconstr = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                Port = 3306,
                Database = "KursovayaDB",
                UserID = "root",
                Password = "",
                CharacterSet = "utf8"
            };
            MySqlConnection connect = new MySqlConnection(mysqlconstr.ToString());
            string queryString = @comm;
            MySqlCommand command = new MySqlCommand(queryString, connect);
            command.Parameters.AddWithValue("@request_name", req_type);
            command.Parameters.AddWithValue("@client_name", cl_name);
            command.Parameters.AddWithValue("@data_zakaza", ord_date);
            command.Parameters.AddWithValue("@date_end", date_end);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@comment", comment);
            connect.Open();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Заявка успешно зарегистрирована.");
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("555Сохранение заявки не удалось /n Ошибка: " + ex.Message);
            }
            return dt;
        }
    }
}
