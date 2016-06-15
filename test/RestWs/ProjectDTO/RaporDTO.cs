using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace test.ProjectDTO
{
    [DataContract]
    public class RaporDTO
    {
        [DataMember]
        public KullaniciDTO Kullanici { get; set; }
        [DataMember]
        public List<UrunlerDTO> lstUrun { get; set; }
        [DataMember]
        public MarketDTO Market { get; set; }
    }
}