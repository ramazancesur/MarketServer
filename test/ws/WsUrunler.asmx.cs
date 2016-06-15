using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using test.Resources;
namespace test.ws
{
    [WebService]
    public class WsUrunler : System.Web.Services.WebService
    {

        //Sıkıntı yok :)yarım saat sonra daha hızlı atak bir şekilde devam :) Damla uyuma :) hepsini anlataxağım ne yaptığımı
        //Web Servisimiz 
        DatabaseUrunler urunler = new DatabaseUrunler();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetEmployessJSON()
        {
            return new JavaScriptSerializer().Serialize(urunler.allUrunlerList());
        }
       
    }
}
