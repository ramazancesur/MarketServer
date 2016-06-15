using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using test.Entity;

namespace test.ProjectDTO
{
    [DataContract]
    public class MarketDTO
    {
        [DataMember]
        public string MarketAdi { get; set; }
        // Enlem ve Boylam Birleştir ve ; koy arasına
        [DataMember]
        public string Konum { get; set; }
     
        [DataMember]
        public int MarketID { get; set; }
    }
}