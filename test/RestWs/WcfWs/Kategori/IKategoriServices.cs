using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using test.RestWs.ProjectDTO;

namespace test.RestWs.WcfWs.Kategori
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IKategoriServices" in both code and config file together.
    
    [ServiceContract]
    public interface IKategoriServices
    {
        [OperationContract]
        [WebGet(UriTemplate = "allKategori",
              ResponseFormat = WebMessageFormat.Json)]
        List<KategoriDTO> allKategorilist();
        
    }
}
