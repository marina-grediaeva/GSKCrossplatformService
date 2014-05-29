using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GSKCrossplatformService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IGSKCrossplatformService
    {

        [OperationContract]
        [WebGet(UriTemplate = "/{_Name}/{_Surname}")]
        Model.NameSurname GetNameSurname(string _Name, string _Surname);

    }

}
