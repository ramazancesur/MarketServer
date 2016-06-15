using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.ProjectDTO
{
    public class RaporDTO
    {
        public KullaniciDTO Kullanici { get; set; }
        public List<UrunlerDTO> lstUrun { get; set; }
        public MarketDTO Market { get; set; }
    }
}