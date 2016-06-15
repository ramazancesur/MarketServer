using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using test.ProjectDTO;
using test.RestWs.Dao.Market;

namespace test.RestWs.WcfWs.Market
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MarketServisi" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MarketServisi.svc or MarketServisi.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MarketServisi : IMarketServisi
    {
        IMarketDao marketDao = new MarketDao();
        public List<MarketDTO> allMarketDTO()
        {
            List<MarketDTO> lstMarketDTO = marketDao.allMarketDTO();
            return lstMarketDTO;
        }

        public List<MarketDTO> enYakinUcMarket(string currentKonum)
        {
            string[] locations = currentKonum.Split(';');
            double latitute = double.Parse(locations[0], CultureInfo.InvariantCulture);
            double longitute = double.Parse(locations[1], CultureInfo.InvariantCulture);
            List<MarketDTO> lstMarketDTO = marketDao.enYakinUcMarket(latitute,longitute);
            return lstMarketDTO;
        }

       
        public List<UrunlerDTO> findAllProductByMarket(string marketID)
        {
            List<UrunlerDTO> lstUrunlerDTO = marketDao.findAllProductByMarket(Convert.ToInt32(marketID));
            return lstUrunlerDTO;
        }

        public MarketDTO findByMarketDTO(string id)
        {
            MarketDTO marketDTO = marketDao.findByMarketDTO(Convert.ToInt32(id));
            return marketDTO;
        }

        public List<MarketDTO> findByMarketDTOName(string marketName)
        {
            List<MarketDTO> lstMarketDTO = marketDao.findByMarketDTOName(marketName);
            return lstMarketDTO;
        }
    }
}
