﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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

        public Model.NameSurname GetNameSurname(string _Name, string _Surname)
        {
            Model.NameSurname model = new Model.NameSurname()
            {
                Name = _Name,
                Surname = _Surname
            };
            return model;

        }

        #endregion
    }
}
