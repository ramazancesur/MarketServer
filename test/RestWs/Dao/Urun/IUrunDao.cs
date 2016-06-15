using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using test.ProjectDTO;

namespace test.RestWs.Dao.Urun
{
    interface IUrunDao
    { 
        List<UrunlerDTO> allUrunler();

        List<UrunlerDTO> findUrunbyName(string urunName);

        UrunlerDTO findbyUrunID(int id);

        List<UrunlerDTO> findbyEcuz(string urunName);

        List<UrunlerDTO> findByMarka(string markaAdi);

        List<UrunlerDTO> findUrunByKategori(string kategoriName);

        List<UrunlerDTO> findUrunByMarketAndUrunAdi(string MarketAdi, string urunAdi);

        List<UrunlerDTO> findUrunByKategoriandMarket(string kategoriName, string MarketID);
        
    }
}
