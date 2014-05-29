using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GSKCrossplatformService.Model
{
    [DataContract]
    public class NameSurname
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 2)]
        public string Surname { get; set; }


    }
}