using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using test.ProjectDTO;
using test.RestWs.ProjectDTO;

namespace test.SoapWs
{
    public partial class MakroMarket : System.Web.UI.Page
    {
        CourfursaWebServices.WebServiceKategoriSoapClient courfoursaWs;
        MakroWebServices.MakroServicesSoapClient makroWs;
        List<KategoriDTO> lstKategori;
        List<MarketDTO> lstMarket;
        KategoriDTO kategoriDTO;
        MarketDTO marketDTO;
        private void init()
        {
            lstKategori = new List<KategoriDTO>();
            lstMarket = new List<MarketDTO>();
            kategoriDTO = new KategoriDTO();
            courfoursaWs = new CourfursaWebServices.WebServiceKategoriSoapClient();
            makroWs = new MakroWebServices.MakroServicesSoapClient();
            using (var webClient = new System.Net.WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                var json = webClient.DownloadString("http://elifdamla.com/RestWs/WcfWs/Kategori/KategoriServices.svc/allKategori");
                var objects = JArray.Parse(json); // parse as array  
                var first = objects[0]["kategoriID"].ToString();
                foreach (JObject root in objects)
                {
                    kategoriDTO = new KategoriDTO();
                    var kategoriAdi = root["kategoriAdi"].ToString();
                    var kategoriID = Convert.ToInt32(root["kategoriID"].ToString());
                    kategoriDTO.kategoriAdi = kategoriAdi;
                    kategoriDTO.kategoriID = kategoriID;
                    lstKategori.Add(kategoriDTO);
                }
            }
            marketDTO = new MarketDTO();

            using (var webClient = new System.Net.WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                var json = webClient.DownloadString("http://elifdamla.com/RestWs/WcfWs/Market/MarketServisi.svc/allMarkets");
                var objects = JArray.Parse(json); // parse as array  
                foreach (JObject root in objects)
                {
                    MarketDTO marketDTO = new MarketDTO();
                    var MarketAdi = root["MarketAdi"].ToString();
                    var MarketID = root["MarketID"].ToString();
                    marketDTO.MarketAdi = MarketAdi;
                    marketDTO.MarketID = Convert.ToInt32(MarketID);
                    lstMarket.Add(marketDTO);
                }
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            init();
            drpKategori.DataSource = lstKategori;
            drpKategori.DataTextField = "kategoriAdi";
            drpKategori.DataValueField = "kategoriID";
            drpKategori.DataBind();


            drpMarketler.DataSource = lstMarket;
            drpMarketler.DataTextField = "MarketAdi";
            drpMarketler.DataValueField = "MarketID";
            drpMarketler.DataBind();
        }

        protected void btnMakro_Click(object sender, EventArgs e)
        {
            makroWs.MakroInsertAll(Convert.ToInt32( drpMarketler.SelectedItem.Value)
                ,Convert.ToInt32(drpMarketler.SelectedItem.Value));
            Response.Write("<script>alert('işlem başarılı');</script>");
        }

        protected void btnCourfoursa_Click(object sender, EventArgs e)
        {
            courfoursaWs.CourfursaInsertAll(Convert.ToInt32(drpMarketler.SelectedItem.Value)
                , Convert.ToInt32(drpMarketler.SelectedItem.Value));
            Response.Write("<script>alert('işlem başarılı');</script>");
        }

        protected void btnMarketEkle_Click(object sender, EventArgs e)
        {
            makroWs.InsertMarket(txtMarketAdi.Text, txtMarketAdres.Text);
            Response.Write("<script>alert('işlem başarılı');</script>");
        }
    }
}