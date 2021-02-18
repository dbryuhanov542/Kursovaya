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
    class Login
    {
        static public DataTable log(string a)
        {
                DataTable dt = new DataTable();
                MySqlConnectionStringBuilder mysqlconstr = new MySqlConnectionStringBuilder();
                mysqlconstr.Server = "127.0.0.1";
                mysqlconstr.Port = 3306;
                mysqlconstr.Database = "KursovayaDB";
                mysqlconstr.UserID = "root";
                mysqlconstr.Password = "";
                mysqlconstr.CharacterSet = "utf8";
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
                    MessageBox.Show(ex.Message);
                }
                return dt;

            }
        }
}
