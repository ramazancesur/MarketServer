using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using test.ProjectDTO;

namespace test.RestWs.WsfWs.Urun
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUrun" in both code and config file together.
    [ServiceContract]
    public interface IUrunServices
    {
        [OperationContract]
        [WebGet(UriTemplate = "allProduct",
              ResponseFormat = WebMessageFormat.Json)]
        List<UrunlerDTO> allUrunler();

        [OperationContract]
        [WebGet(UriTemplate = "urunBul/{urunName}",
              ResponseFormat = WebMessageFormat.Json)]
        List<UrunlerDTO> findUrunbyName(string urunName);

        [OperationContract]
        [WebGet(UriTemplate = "urun/{id}",
              ResponseFormat = WebMessageFormat.Json)]
        UrunlerDTO findbyUrunID(string id);

        [OperationContract]
        [WebGet(UriTemplate = "urunFiyatiSirala/{urunName}",
              ResponseFormat = WebMessageFormat.Json)]
        List<UrunlerDTO> findbyEcuz(string urunName);
        
        [OperationContract]
        [WebGet(UriTemplate = "urunlerMarkaBul/{markaAdi}",
              ResponseFormat = WebMessageFormat.Json)]
        List<UrunlerDTO> findByMarka(string markaAdi);


        [OperationContract]
        [WebGet(UriTemplate = "urunKategori/{kategoriID}",
              ResponseFormat = WebMessageFormat.Json)]
        List<UrunlerDTO> findUrunByKategori(string kategoriID);

        [OperationContract]
        [WebGet(UriTemplate = "urunKategori/{kategoriID}/{MarketID}",ResponseFormat =WebMessageFormat.Json)]
        List<UrunlerDTO> findUrunByKategoriandMarket(string kategoriID, string marketID);

        [OperationContract]
        [WebGet(UriTemplate = "lstUrun/{marketAdi}/{urunAdi}", ResponseFormat = WebMessageFormat.Json)]
        List<UrunlerDTO> findUrunByUrunAdiandMarket(string marketAdi, string urunAdi);

    }
}
