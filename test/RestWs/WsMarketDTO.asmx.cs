using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace test.RestWs
{
   [WebService]
    public class MarketDTOws : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string HelloWorld()
        {
            return "Hello World";
            //return new JavaScriptSerializer().Serialize(urunler.allUrunlerList());
        }
    }
}
