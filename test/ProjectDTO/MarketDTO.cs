using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.ProjectDTO
{
    public class MarketDTO
    {
        public string MarketAdi { get; set; }
        // Enlem ve Boylam Birleştir ve ; koy arasına
        public string Konum { get; set; }
        public List<UrunlerDTO> lstUrunler { get; set; }
        

    }
}