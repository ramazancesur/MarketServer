using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using test.Entity;
using test.Resources;

namespace test.Helper
{
    public class HtmlParser
    {
        public HtmlParser()
        {
            init();   
        }
        /// <summary>
        /// init fonksiyonunu içermektedir
        /// </summary>
        #region constand
        private DatabaseAciklamalar databaseAciklama;
        private DatabaseKategori databaseKategori;
        private DatabaseUrunler databaseUrunler;
        private DatabaseKonumlar databaseKonum;
        private DatabaseMarketler databaseMarketler;
        private HtmlDocument document;
        private Urunler urun;
        private void init()
        {
            databaseUrunler = new DatabaseUrunler();
            databaseMarketler = new DatabaseMarketler();
            databaseAciklama = new DatabaseAciklamalar();
            databaseKategori = new DatabaseKategori();
            databaseKonum = new DatabaseKonumlar();
        }
        #endregion

        #region webSiteDownloadHtml

        private string GetContent(string AdressUrl)
        {
            Uri url = new Uri(AdressUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            // utf 8 olduğu için türkçe karakter sorunu yapmayacak

            string html = client.DownloadString(url);
            return html;
        }
        #endregion

        /// <summary>
        /// Urun Ekleyen Method
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="patern1"> urun ismi paternı</param>
        /// <param name="patern2"> urunun fiyatı paternı</param>
        /// <param name="aciklamaId">acıklama id'si</param>
        /// <param name="birimId">Birim id</param>
        /// <param name="kategoriId">kategori id</param>
        /// <param name="marketID">market id</param>
        /// <returns></returns>
        #region insertUrun
        public List<Urunler> InsertNewProduct(string url, string patern1, string patern2,
          int aciklamaId , int birimId, int kategoriId, int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent(url);
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);

            HtmlNodeCollection element = document.DocumentNode.SelectNodes(patern1);

            List<Urunler> lstProduct = new List<Urunler>();

            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id =aciklamaId;
                urun.Birim_Id = birimId;
                urun.Kategori_Id = kategoriId;

                var et = item.InnerText;
                urun.Marka = et.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = et;
                lstProduct.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes(patern2);
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                lstProduct[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("TL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(lstProduct[i]);
            }

            return lstProduct;
        }
        #endregion
    }
}