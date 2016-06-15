using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace test.RestWs
{
    /// <summary>
    /// Summary description for KullaniciDTOWss
    /// </summary>
  
    [WebService]
    public class KullaniciDTOWss : System.Web.Services.WebService
    {
        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string HelloWorld()
        {
            // normalde bu adamı sevmem ancak bu vaazını seviyorum beni gaza getiriyor 
            return "Hello World";
            //return new JavaScriptSerializer().Serialize(urunler.allUrunlerList());
        }
    }
}
