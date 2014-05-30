using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;

namespace GSKCrossplatformService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class GSKCrossplatformService : IGSKCrossplatformService
    {
        #region IGSKCrossplatformService

        public string TryConnect(string _Username, string _Password)
        {
            string c = ConfigurationManager.AppSettings["SQLSERVER_CONNECTION_STRING"];
            if(String.IsNullOrEmpty(c))
                c = @"server=c64a04ae-21e2-4ac9-be43-a33a0149e801.mysql.sequelizer.com;database=dbc64a04ae21e24ac9be43a33a0149e801;uid=jfcpgrpkstftvcmc;pwd=vkxeJQXaAgWobMUGtTbGUXFUtNhdYBVEDDRnopHPwejh2vweaNzgf6sFMLT4HUi8";
            using (MySqlConnection conn = new MySqlConnection(c))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {

                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = @" SELECT * 
                                             FROM   `users`
                                             WHERE  `login` = @login and
                                                    `password` = @password;";

                        cmd.Parameters.AddWithValue("@login", _Username);
                        cmd.Parameters.AddWithValue("@password", _Password);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                                return null;
                            else
                                return "Имя пользователи и/или пароль не опознаны";
                        }

                    }
                }
                catch (Exception exc)
                {
                    return exc.Message;
                }
            }
        }

        #endregion
    }
}
