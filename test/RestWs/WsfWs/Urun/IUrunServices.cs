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
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<UrunlerDTO> allUrunler();

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<UrunlerDTO> findUrunbyName(string urunName);

        [OperationContract]
        [WebGet(UriTemplate = "urun/{id}",
              ResponseFormat = WebMessageFormat.Json)]
        UrunlerDTO findbyUrunID(string id);

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<UrunlerDTO> findbyEcuz(string urunName);

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<UrunlerDTO> findByMarka(string markaAdi);
    }
}
