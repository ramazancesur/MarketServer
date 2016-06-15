using System;
using System.Web.Services;
using test.Entity;
using test.Helper;
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
        public string InsertKirmiziEt(int marketID,int kategoriID)
        {
            MakroHtmlParser makro = new MakroHtmlParser();
            makroparser.insertKirmiziEtUrunu( marketID, kategoriID);
            return "İşlem başarılı";
        }

        [WebMethod]
        public string InsertSebze(int marketID,int kategoriID)
        {
            makroparser.insertSebzeUrunu(marketID,kategoriID);
            return "İşlem başarılı";
        }

        [WebMethod]
        public string InsertMeyve(int marketID,int kategoriID)
        {
            makroparser.insertMeyveUrunu(marketID,kategoriID);
            return "İşlem başarılı";
        }


        [WebMethod]
        public string InsertMarket(string marketAdi,string marketAdresi)
        {
            Marketler market = new Marketler();
            market.Adress = marketAdresi;
            market.Market_Adi = marketAdi;
            makroparser.insertMarket(market);
            return "İşlem başarılı";
        }

        [WebMethod]
        public string InsertSüt(int marketID,int kategoriID)
        {
            makroparser.insertSütUrunu(marketID,kategoriID);
            return "İşlem başarılı";
        }

        [WebMethod]
        public string InsertYogurt(int marketID,int kategoriID)
        {
            makroparser.insertYogurtUrunu(marketID,kategoriID);
            return "İşlem başarılı";
        }
        [WebMethod]
        public string InsertPeynir(int marketID,int kategoriID)
        {
            makroparser.insertPeynirUrunu(marketID,kategoriID);
            return "İşlem başarılı";
        }

        [WebMethod]
        public string MakroInsertAll(int marketID,int kategoriID)
        {
            try
            {

                makroparser.insertKirmiziEtUrunu( marketID, kategoriID) ;
                // Market Ekleme Web Servisi Yazılacak
                makroparser.insertMeyveUrunu( marketID, kategoriID);
                makroparser.insertPeynirUrunu( marketID, kategoriID);
                makroparser.insertSebzeUrunu( marketID, kategoriID);
                makroparser.insertSütUrunu( marketID, kategoriID);
                makroparser.insertYogurtUrunu( marketID, kategoriID);
            }
            catch (Exception ex)
            {
                return "bir hata meydana geldi"+ex.Message;
            }
            return "işlem başarılı";
        }
    }
}
