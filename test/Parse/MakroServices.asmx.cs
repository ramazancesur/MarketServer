using System.Web.Services;

namespace test.Parse
{
    /// <summary>
    /// Summary description for MakroServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MakroServices : System.Web.Services.WebService
    {
        MakroParser makroparser = new MakroParser();
        [WebMethod]
        public string InsertKirmiziEt()
        {
            makroparser.insertKirmiziEtUrunu();
            return "İşlem başarılı";
        }
    }
}
