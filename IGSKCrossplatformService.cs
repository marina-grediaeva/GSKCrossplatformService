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
        //отсылает null если подключение удалось, если не удалось, то отсылает текст возникшего исключения
        [OperationContract]
        [WebGet(UriTemplate = "/TryConnect/?username={_Username}&password={_Password}")]
        string TryConnect(string _Username, string _Password);


    }

}
