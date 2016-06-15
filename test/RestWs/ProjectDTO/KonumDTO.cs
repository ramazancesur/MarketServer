using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using test.Entity;

namespace test.ProjectDTO
{
    [DataContract]
    public class KonumDTO
    {


        [DataMember]
        public string MarketAdi { get; set; }
        [DataMember]
        public string Konum { get; set; }
    }
}