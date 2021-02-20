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
        //
        //Функция стандартного подключения
        //В основном используется в аутентификации пользователя
        //
        public static DataTable Connect(string a)
        {
            DataTable dt = new DataTable();
            if (Properties.Settings.Default.serverIp != "" && Properties.Settings.Default.port_num != "" && Properties.Settings.Default.DBname != "" && Properties.Settings.Default.DBlog != "")
            {
                MySqlConnectionStringBuilder mysqlconstr = new MySqlConnectionStringBuilder
                {
                    Server = Properties.Settings.Default.serverIp,
                    Port = Convert.ToUInt32(Properties.Settings.Default.port_num),
                    Database = Properties.Settings.Default.DBname,
                    UserID = Properties.Settings.Default.DBlog,
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
            }
            return dt;
        }

        //
        //Функция добавления записи
        //
        static public DataTable Add(string comm, string req_type, string cl_name, string ord_date, string date_end, string price, string comment)
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlconstr = new MySqlConnectionStringBuilder
            {
                Server = Properties.Settings.Default.serverIp,
                Port = Convert.ToUInt32(Properties.Settings.Default.port_num),
                Database = Properties.Settings.Default.DBname,
                UserID = Properties.Settings.Default.DBlog,
                Password = Properties.Settings.Default.DBpass,
                CharacterSet = "utf8"
            };
            MySqlConnection conn = new MySqlConnection(mysqlconstr.ToString());
            string queryString = @comm;
            MySqlCommand command = new MySqlCommand(queryString, conn);
            command.Parameters.AddWithValue("@request_name", req_type);
            command.Parameters.AddWithValue("@client_name", cl_name);
            command.Parameters.AddWithValue("@data_zakaza", ord_date);
            command.Parameters.AddWithValue("@date_end", date_end);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@comment", comment);
            conn.Open();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Заявка успешно зарегистрирована.");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сохранение заявки не удалось. Ошибка: " + ex.Message);
            }
            return dt;
        }

        //
        //Функция добавления новых пользователей
        //
        static public DataTable Registrate(string comm, string user_log, string user_pass, string user_name, string user_rank)
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlconstr = new MySqlConnectionStringBuilder
            {
                Server = Properties.Settings.Default.serverIp,
                Port = Convert.ToUInt32(Properties.Settings.Default.port_num),
                Database = Properties.Settings.Default.DBname,
                UserID = Properties.Settings.Default.DBlog,
                Password = Properties.Settings.Default.DBpass,
                CharacterSet = "utf8"
            };
            MySqlConnection conn = new MySqlConnection(mysqlconstr.ToString());
            string queryString = @comm;
            MySqlCommand command = new MySqlCommand(queryString, conn);
            command.Parameters.AddWithValue("@login", user_log);
            command.Parameters.AddWithValue("@password", user_pass);
            command.Parameters.AddWithValue("@user_data", user_name);
            command.Parameters.AddWithValue("@user_rank", user_rank);

            conn.Open();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Пользователь успешно зарегистрирован.");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Регистрация не удалась. Ошибка: " + ex.Message);
            }
            return dt;
        }
    }
}
