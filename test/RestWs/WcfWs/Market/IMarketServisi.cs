using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using test.ProjectDTO;

namespace test.RestWs.WcfWs.Market
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMarketServisi" in both code and config file together.
    [ServiceContract]
    public interface IMarketServisi
    {
        [OperationContract]
        [WebGet(UriTemplate = "allMarkets",
          ResponseFormat = WebMessageFormat.Json)]
        List<MarketDTO> allMarketDTO();

        [OperationContract]
        [WebGet(UriTemplate = "market/{marketID}",
             ResponseFormat = WebMessageFormat.Json)]
        MarketDTO findByMarketDTO(string marketID);

        [OperationContract]
        [WebGet(UriTemplate = "marketBulIsmeGore/{marketName}",
             ResponseFormat = WebMessageFormat.Json)]
        List<MarketDTO> findByMarketDTOName(string marketName);

        [OperationContract]
        [WebGet(UriTemplate = "MarketBulKonumaGore/{currentKonum}",
             ResponseFormat = WebMessageFormat.Json)]
        List<MarketDTO> enYakinUcMarket(string currentKonum);

        [OperationContract]
        [WebGet(UriTemplate = "MarketUrun/{marketID}",
          ResponseFormat = WebMessageFormat.Json)]
        List <UrunlerDTO> findAllProductByMarket(string marketID);


    }
}
