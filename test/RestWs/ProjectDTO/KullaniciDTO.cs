using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace test.ProjectDTO
{
    [DataContract]
    public class KullaniciDTO
    {
        [DataMember]
        public string AdiSoyadi { get; set; }
        [DataMember]
        public string EMail { get; set; }
        [DataMember]
        public string Sifre { get; set; }
        [DataMember]
        public int KullaniciID { get; set; }
    }
}