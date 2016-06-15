using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using test.ProjectDTO;

namespace test.RestWs.WcfWs.Kullanici
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IKullaniciServices" in both code and config file together.
    [ServiceContract]
    public interface IKullaniciServices
    {
        [OperationContract]
        [WebGet(UriTemplate = "allUser",
              ResponseFormat = WebMessageFormat.Json)]
        List<KullaniciDTO> lstKullanici();
    
        [OperationContract]
        [WebGet(UriTemplate = "Kullanici/{email}/{sifre}")]
        KullaniciDTO getKullaniciByLogin(string EMail, string Sifre);

        [OperationContract]
        [WebGet(UriTemplate = "Kullanici/{id}",
              ResponseFormat = WebMessageFormat.Json)]
        KullaniciDTO getKullaniciByID(string id);
    }
}
