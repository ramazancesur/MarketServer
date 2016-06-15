using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace test.RestWs.ProjectDTO
{
    [DataContract]
    public class KategoriDTO
    {
        [DataMember]
        public int kategoriID { get; set; }

        [DataMember]
        public string kategoriAdi { get; set; }
    }
}