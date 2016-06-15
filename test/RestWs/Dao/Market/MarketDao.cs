using System;
using test.ProjectDTO;
using test.Resources;
using test.RestWs.Dao.Kullanici;
using test.Entity;
using test.RestWs.Dao.Urun;
using test.Helper;
using System.Linq;
using System.Collections.Generic;

namespace test.RestWs.Dao.Market
{
    public class MarketDao : IMarketDao
    {
        DatabaseMarketler databaseMarketler;
        UrunDao urunDao;
        MarketDTO MarketDTO;
        Marketler Market;
      
        private void init()
        {
            databaseMarketler = new DatabaseMarketler();
            urunDao = new UrunDao();
        }
        public MarketDao()
        {
            init();
        }
        UrunlerDTO urunlerDTO;
        List<UrunlerDTO> lstUrunlerDTO = new List<UrunlerDTO>();
        public List<MarketDTO> allMarketDTO()
        {
            urunlerDTO = new UrunlerDTO();
            List<MarketDTO> allMarketDTO = new List<MarketDTO>();
            List<Marketler> MarketList = new List<Marketler>();
            MarketList = databaseMarketler.allMarketlerList();
            foreach (var market in MarketList)
            {
                MarketDTO = new MarketDTO();
               
                MarketDTO.MarketAdi = market.Market_Adi;
                MarketDTO.MarketID = market.Market_Id;
                MarketDTO.Konum = databaseMarketler.getMarketKonumu(market.Konum_Id);
                allMarketDTO.Add(MarketDTO);
            }
            return allMarketDTO;

        }

       public List<Urunler> findUrunListByMarketID(int marketID)
        {
            List<Urunler> lstUrunler = databaseMarketler.getAllUrunlerByMarketID(marketID);
            return lstUrunler;
        }
      


        public MarketDTO findByMarketDTO(int id)
        {

            // bu method tekrar düzenlenecek

            //urunlerim çoğu kısmı marketşer oluşturulken oluştu 
            Market = databaseMarketler.getMarketlerbyID(id);
            MarketDTO = new MarketDTO();
            MarketDTO.MarketID = Market.Market_Id;
            MarketDTO.MarketAdi = Market.Market_Adi;
            MarketDTO.Konum = databaseMarketler.getMarketKonumu(Market.Konum_Id);
            return MarketDTO;
        }

        public List<MarketDTO> findByMarketDTOName(string marketName)
        {
            List<MarketDTO> lstMarketDTO = new List<MarketDTO>();
            List<Marketler> lstMarket = databaseMarketler.getMarketbyName(marketName);
            foreach (Marketler market in lstMarket)
            {
                MarketDTO = new MarketDTO();
                lstUrunlerDTO = new List<UrunlerDTO>();
                MarketDTO.MarketAdi = market.Market_Adi;
                MarketDTO.MarketID = market.Market_Id;
                lstMarketDTO.Add(MarketDTO);
            }
            return lstMarketDTO ;
        }

        public List<UrunlerDTO> findAllProductByMarket(int marketID)
        {
            UrunlerDTO urunDTO;
            List<UrunlerDTO> lstUrunDTO = new List<UrunlerDTO>();
            List<Urunler> lstUrun = databaseMarketler.getAllUrunlerByMarketID(marketID);
            foreach (Urunler urunler in lstUrun)
            {
                urunDTO = new UrunlerDTO();
                urunDTO = urunDao.findbyUrunID(urunler.Urun_Id);
                lstUrunDTO.Add(urunDTO);        
            }
            return lstUrunDTO;
        }
     
        LocationProcess locationProcess = new LocationProcess();
        public List<MarketDTO> enYakinUcMarket(double lat1, double lon1)
        {
            string marketLatitute;
            string marketLongitute;
            char unit = 'K';
            List<MarketDTO> lstMarketDTO = allMarketDTO();
            var dictionary = new Dictionary<string, Double>();
            foreach (var marketDTO in lstMarketDTO)
            {
                marketDTO.Konum = marketDTO.Konum.Replace(",", ".");
                marketLongitute = marketDTO.Konum.Split(';')[1];
                marketLatitute = marketDTO.Konum.Split(';')[0];
        

                dictionary.Add(marketDTO.MarketID.ToString(),
                locationProcess.distance(lat1, lon1,
                    Convert.ToDouble(marketLatitute, System.Globalization.CultureInfo.InvariantCulture), 
                    Convert.ToDouble(marketLongitute, System.Globalization.CultureInfo.InvariantCulture), unit));
            }

            var lstUzaklikSiralama = from marketler in dictionary
                                     orderby marketler.Value ascending
                                     select marketler;

            int sayac = 0;
            lstMarketDTO = new List<MarketDTO>();
            foreach (var item in lstUzaklikSiralama)
            {
                if (sayac < 3)
                {
                    lstMarketDTO.Add(findByMarketDTO(Convert.ToInt32(item.Key)));
                }
                sayac = sayac + 1;
            }
            return lstMarketDTO;
        }
    }
}