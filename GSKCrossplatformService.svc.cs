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

namespace GSKCrossplatformService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class GSKCrossplatformService : IGSKCrossplatformService
    {
        #region IGSKCrossplatformService

        public string TryConnect(string _Username, string _Password)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MYSQL_CONNECTION_STRING"]))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {

                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = @" SELECT * 
                                             FROM   `users`
                                             WHERE  `login` = @login and
                                                    `password = @password;";

                        cmd.Parameters.AddWithValue("@login", _Username);
                        cmd.Parameters.AddWithValue("@Password", _Password);
                        using (SqlDataReader reader = cmd.ExecuteReader())
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
