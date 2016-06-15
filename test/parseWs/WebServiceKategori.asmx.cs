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
      public WebServiceKategori()
        {
            courfursaParse = new CoutfursaParse();
        }
        MarketParse marketParse;
        [WebMethod]
        public String getKategoriListAndAdd()
        {
            // burada yaptık ve parse ettiğimiz classda yer alan getKategpri methodunu çağırdık
            marketParse = new MarketParse();
            marketParse.getKategori();
            return "işlem başarılı";
        }
        CoutfursaParse courfursaParse;
        [WebMethod]
        public String AddEtveEtUrunu(int kategoriID,int marketID)
        {
            // burada yaptık ve parse ettiğimiz classda yer alan getKategpri methodunu çağırdık

            courfursaParse.getEtTurevi(kategoriID,marketID);
            return "işlem başarılı";
        } 

        [WebMethod]
        public String TavukveHindiUrunu(int kategoriID, int marketID)
        {
            // burada yaptık ve parse ettiğimiz classda yer alan getKategpri methodunu çağırdık

            courfursaParse.TavukveHindi(kategoriID,marketID);
            return "işlem başarılı";
        }


        [WebMethod]
        public String MeyveUrunu(int kategoriID, int marketID)
        {
            // burada yaptık ve parse ettiğimiz classda yer alan getKategpri methodunu çağırdık

            courfursaParse.Meyve(kategoriID,marketID);
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
        public String BalikveDenizMahsülleriUrunu(int kategoriID, int marketID)
        {
            // burada yaptık ve parse ettiğimiz classda yer alan getKategpri methodunu çağırdık

            courfursaParse.BalikveDenizMahsülleri(kategoriID,marketID);
            return "işlem başarılı";
        }

        [WebMethod]
        public String SütParseUrunu(int kategoriID, int marketID)
        {
            // burada yaptık ve parse ettiğimiz classda yer alan getKategpri methodunu çağırdık

            courfursaParse.SütParse(kategoriID,marketID); 
            return "işlem başarılı";
        }

        [WebMethod]
        public String PeynirParseUrunu(int kategoriID, int marketID)
        {
            courfursaParse.PeynirParse(kategoriID,marketID);
            return "işlem başarılı";
        }

        [WebMethod]
        public String YumurtaVeTerayagParseUrunu(int kategoriID, int marketID)
        {
            courfursaParse.YumurtaVeTerayagParse(kategoriID,marketID);
            return "işlem başarılı";
        }

        [WebMethod]
        public String CourfursaInsertAll(int kategoriID, int marketID)
        {
            try
            {

                courfursaParse.AgizBakimUrunleriParse(kategoriID,marketID);
                courfursaParse.BakliyatParse(kategoriID,marketID);
                courfursaParse.BalikveDenizMahsülleri(kategoriID,marketID);
             
                courfursaParse.EvTemizlikMalzemeleriParse(kategoriID,marketID);
                courfursaParse.GazlıIcecekParse(kategoriID,marketID);
                courfursaParse.getEtTurevi(kategoriID,marketID);
                courfursaParse.hazirGidaParse(kategoriID,marketID);
                courfursaParse.KagitUrunleriParse(kategoriID,marketID);

                courfursaParse.KuruyemisParse(kategoriID,marketID);
                courfursaParse.Meyve(kategoriID,marketID);
                courfursaParse.MeyveSulariParse(kategoriID,marketID);
         
                courfursaParse.PeynirParse(kategoriID,marketID);
                courfursaParse.YumurtaVeTerayagParse(kategoriID,marketID);
            }
            catch (Exception ex)
            {
                return "bir hata meydana geldi"+ex.Message;
            }
           return "işlem başarılı";
        }

    }
}
