using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using test.Entity;

namespace test.Parse
{
    /// <summary>
    /// Summary description for WebServiceKategori
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceKategori : System.Web.Services.WebService
    {
        MarketParse marketParse;
        [WebMethod]
        public String getKategoriListAndAdd()
        {
            // burada yaptık ve parse ettiğimiz classda yer alan getKategpri methodunu çağırdık
            marketParse = new MarketParse();
            marketParse.getKategori();
            return "işlem başarılı";
        }
        CoutfursaParse courfursaParse = new CoutfursaParse();
        [WebMethod]
        public String AddEtveEtUrunu()
        {
            // burada yaptık ve parse ettiğimiz classda yer alan getKategpri methodunu çağırdık

            courfursaParse.getEtTurevi();
            return "işlem başarılı";
        }

        [WebMethod]
        public String TavukveHindiUrunu()
        {
            // burada yaptık ve parse ettiğimiz classda yer alan getKategpri methodunu çağırdık

            courfursaParse.TavukveHindi();
            return "işlem başarılı";
        }


        [WebMethod]
        public String MeyveUrunu()
        {
            // burada yaptık ve parse ettiğimiz classda yer alan getKategpri methodunu çağırdık

            courfursaParse.Meyve();
            return "işlem başarılı";
        }

        [WebMethod]
        public String insertKategori()
        {
            // burada yaptık ve parse ettiğimiz classda yer alan getKategpri methodunu çağırdık

            courfursaParse.getKategori();
            return "işlem başarılı";
        }
        [WebMethod]
        public String BalikveDenizMahsülleriUrunu()
        {
            // burada yaptık ve parse ettiğimiz classda yer alan getKategpri methodunu çağırdık

            courfursaParse.BalikveDenizMahsülleri();
            return "işlem başarılı";
        }

        [WebMethod]
        public String SütParseUrunu()
        {
            // burada yaptık ve parse ettiğimiz classda yer alan getKategpri methodunu çağırdık

            courfursaParse.SütParse(); 
            return "işlem başarılı";
        }

        [WebMethod]
        public String PeynirParseUrunu()
        {
            courfursaParse.PeynirParse();
            return "işlem başarılı";
        }

        [WebMethod]
        public String YumurtaVeTerayagParseUrunu()
        {
            courfursaParse.YumurtaVeTerayagParse();
            return "işlem başarılı";
        }

    }
}
