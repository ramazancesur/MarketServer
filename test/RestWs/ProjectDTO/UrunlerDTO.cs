using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using test.RestWs.ProjectDTO;

namespace test.ProjectDTO
{
    [DataContract]
    public class UrunlerDTO
    {
        [DataMember]
        public int UrunID { get; set; }

        [DataMember]
        public string UrunAdi { get; set; }

        [DataMember]
        public Nullable<double> Fiyat { get; set; }

        [DataMember]
        public string Marka { get; set; }

        [DataMember]
        public KategoriDTO kategoriDTO { get; set; } 

        [DataMember]
        public Nullable<int> MarketID { get; set; }

        [DataMember]
        public string UrunBirimAciklama { get; set; }
    }
}