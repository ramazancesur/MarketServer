using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web.Script.Services;
using test.ProjectDTO;


namespace test.RestWs.Dao.Market
{
    public interface IMarketDao
    {
        List<MarketDTO> allMarketDTO();

        MarketDTO findByMarketDTO(int id);

        List<MarketDTO> findByMarketDTOName(string marketName);

        List<MarketDTO> enYakinUcMarket(double currentLangutude, double currentLogitude);

        List<UrunlerDTO> findAllProductByMarket(int marketID);
        
    }
}
