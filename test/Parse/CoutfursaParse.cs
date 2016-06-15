using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using test.Entity;
using test.Resources;
using test.Helper;
namespace test.Parse
{
    public class CoutfursaParse
    {
        private HtmlDocument document;
        Aciklamalar aciklama = new Aciklamalar();
        DatabaseAciklamalar databaseAciklama;
        DatabaseBirimler databaseBirimler;
        DatabaseKategori databaseKategori;
        DatabaseUrunler databaseUrunler;
        Birimler birim = new Birimler();
        DatabaseKonumlar databaseKonum;
        DatabaseMarketler databaseMarketler;
        public CoutfursaParse()
        {
            init();
        }
        public string GetContent(string AdressUrl)
        {
            Uri url = new Uri(AdressUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            // utf 8 olduğu için türkçe karakter sorunu yapmayacak

            string html = client.DownloadString(url);
            return html;
        }
       
        private void init()
        {
            databaseUrunler = new DatabaseUrunler();
            databaseMarketler = new DatabaseMarketler();
            databaseAciklama = new DatabaseAciklamalar();
            databaseKategori = new DatabaseKategori();
            databaseKonum = new DatabaseKonumlar();
        }
        Urunler urun;
        List<Kategori> lstKategori;
        public List<Kategori> getKategori()
        {
            lstKategori = new List<Kategori>();
            Kategori kategori = new Kategori();
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/sut-kahvaltilik/peynirler");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);

            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//ul[@class='menu']//li");
            foreach (HtmlNode item in element)
            {
                kategori.Aciklama_Id = 1025;
                kategori.Kategori_Adi = item.InnerText.Replace("&amp;", "");
                databaseKategori.InserKategori(kategori);
                lstKategori.Add(kategori);
            }
            return lstKategori;
        }
        public List<Urunler> getEtTurevi(int kategoriID,int marketID)        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/et-balik-sarkuteri/dana");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);

            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> lstEtTurFiyatBilgisi = new List<Urunler>();
            

            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1027;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;

                var et = item.InnerText;
                urun.Marka = et.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = et;
                lstEtTurFiyatBilgisi.Add(urun);
            }//

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                lstEtTurFiyatBilgisi[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(lstEtTurFiyatBilgisi[i]);
            }


            return lstEtTurFiyatBilgisi;
        }



        public List<Urunler> TavukveHindi(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/et-balik-sarkuteri/tavuk-ve-hindi");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);

            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> lstTavukveHindiFiyatBilgisi = new List<Urunler>();

            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = aciklama.Aciklama_Id;
                urun.Birim_Id = birim.Birim_Id;
                urun.Kategori_Id = kategoriID;
                var TavukveHindi = item.InnerText;
                urun.Marka = TavukveHindi.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = TavukveHindi;
                lstTavukveHindiFiyatBilgisi.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                lstTavukveHindiFiyatBilgisi[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(lstTavukveHindiFiyatBilgisi[i]);
            }


            return lstTavukveHindiFiyatBilgisi;
        }


        public List<Urunler> BalikveDenizMahsülleri(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/et-balik-sarkuteri/balik-ve-deniz-mahsulleri");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);

            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> lstBalikveDenizMahsülleriFiyatBilgisi = new List<Urunler>();

            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1027;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;

                var BalikveDenizMahsülleri = item.InnerText;
                urun.Marka = BalikveDenizMahsülleri.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = BalikveDenizMahsülleri;
                lstBalikveDenizMahsülleriFiyatBilgisi.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                lstBalikveDenizMahsülleriFiyatBilgisi[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(lstBalikveDenizMahsülleriFiyatBilgisi[i]);
            }


            return lstBalikveDenizMahsülleriFiyatBilgisi;
        }





        public List<Urunler> Meyve(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/meyve-sebze/sebze");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            //span[@class='price']
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> meyveFiyatlari = new List<Urunler>();
            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1025;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;
                var meyve = item.InnerText;
                urun.Marka = meyve.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = meyve;
                meyveFiyatlari.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                meyveFiyatlari[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(meyveFiyatlari[i]);
            }


            return meyveFiyatlari;
        }

        public List<Urunler> SütParse(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/sut-kahvaltilik/sutler");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            //span[@class='price']
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");
            List<Urunler> meyveFiyatlari = new List<Urunler>();
            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1025;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;
                var meyve = item.InnerText;
                urun.Marka = meyve.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = meyve;
                meyveFiyatlari.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                meyveFiyatlari[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(meyveFiyatlari[i]);
            }

            return meyveFiyatlari;
        }

        public List<Urunler> PeynirParse(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/sut-kahvaltilik/peynirler");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            //span[@class='price']
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> peynirFiyatlari = new List<Urunler>();
            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1025;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;

                var peynir = item.InnerText;
                urun.Marka = peynir.Split(' ')[0];
                urun.Market_Id=marketID;
                urun.Image = "";
                urun.Urun_Adi = peynir;
                peynirFiyatlari.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                peynirFiyatlari[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(peynirFiyatlari[i]);
            }

            return peynirFiyatlari;
        }
        public List<Urunler> YumurtaVeTerayagParse(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/sut-kahvaltilik/yumurta-tereyag-ve-margarin");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            //span[@class='price']
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> yumurtavetereyagFiyatlari = new List<Urunler>();
            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1025;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;

                var yumurtavetereyag = item.InnerText;
                urun.Marka = yumurtavetereyag.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = yumurtavetereyag;
                yumurtavetereyagFiyatlari.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                yumurtavetereyagFiyatlari[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(yumurtavetereyagFiyatlari[i]);
            }

            return yumurtavetereyagFiyatlari;
        }
        public List<Urunler> hazirGidaParse(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/gida-yemek-malzemeleri/hazir-corbalar-yemekler");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            //span[@class='price']
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> meyveFiyatlari = new List<Urunler>();
            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1025;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;
                var meyve = item.InnerText;
                urun.Marka = meyve.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = meyve;
                meyveFiyatlari.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                meyveFiyatlari[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(meyveFiyatlari[i]);
            }

            return meyveFiyatlari;
        }

        public List<Urunler> SiviYagParse(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/gida-yemek-malzemeleri/sivi-yaglar");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            //span[@class='price']
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> meyveFiyatlari = new List<Urunler>();
            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1025;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;
                var meyve = item.InnerText;
                urun.Marka = meyve.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = meyve;
                meyveFiyatlari.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                meyveFiyatlari[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(meyveFiyatlari[i]);
            }

            return meyveFiyatlari;
        }



        public List<Urunler> BakliyatParse(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/gida-yemek-malzemeleri/makarna-pirinc-ve-bakliyat");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            //span[@class='price']
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> meyveFiyatlari = new List<Urunler>();
            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1025;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;

                var meyve = item.InnerText;
                urun.Marka = meyve.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = meyve;
                meyveFiyatlari.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                meyveFiyatlari[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(meyveFiyatlari[i]);
            }

            return meyveFiyatlari;
        }



        public List<string> hazirYemekParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/gida-yemek-malzemeleri/hazir-corbalar-yemekler/hazir-yemekler");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> hazirYemekFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var hazirYemek = item.InnerText;
                hazirYemekFiyatlari.Add(hazirYemek);
            }
            return hazirYemekFiyatlari;
        }



        public List<Urunler> KuruyemisParse(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/sekerleme-kuruyemis/kuruyemis");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            //span[@class='price']
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> meyveFiyatlari = new List<Urunler>();
            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1025;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;
                var meyve = item.InnerText;
                urun.Marka = meyve.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = meyve;
                meyveFiyatlari.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                meyveFiyatlari[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(meyveFiyatlari[i]);
            }

            return meyveFiyatlari;
        }



        public List<Urunler> IcecekParse(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/icecek/kahve");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            //span[@class='price']
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> meyveFiyatlari = new List<Urunler>();
            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1025;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;
                var meyve = item.InnerText;
                urun.Marka = meyve.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = meyve;
                meyveFiyatlari.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                meyveFiyatlari[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(meyveFiyatlari[i]);
            }

            return meyveFiyatlari;
        }

        public List<Urunler> GazlıIcecekParse(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/icecek/gazli-icecekler");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            //span[@class='price']
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> meyveFiyatlari = new List<Urunler>();
            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1025;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;

                var meyve = item.InnerText;
                urun.Marka = meyve.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = meyve;
                meyveFiyatlari.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                meyveFiyatlari[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(meyveFiyatlari[i]);
            }

            return meyveFiyatlari;
        }


        public List<Urunler> SuParse(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/icecek/sular");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            //span[@class='price']
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> meyveFiyatlari = new List<Urunler>();
            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1025;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;

                var meyve = item.InnerText;
                urun.Marka = meyve.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = meyve;
                meyveFiyatlari.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                meyveFiyatlari[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(meyveFiyatlari[i]);
            }

            return meyveFiyatlari;
        }

        public List<Urunler> MeyveSulariParse(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/icecek/meyve-sulari");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            //span[@class='price']
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> meyveFiyatlari = new List<Urunler>();
            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1025;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;

                var meyve = item.InnerText;
                urun.Marka = meyve.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = meyve;
                meyveFiyatlari.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                meyveFiyatlari[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(meyveFiyatlari[i]);
            }

            return meyveFiyatlari;
        }


        public List<Urunler> EvTemizlikMalzemeleriParse(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/temizlik/ev-temizlik-urunleri");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            //span[@class='price']
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> meyveFiyatlari = new List<Urunler>();
            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1025;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;

                var meyve = item.InnerText;
                urun.Marka = meyve.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = meyve;
                meyveFiyatlari.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                meyveFiyatlari[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(meyveFiyatlari[i]);
            }

            return meyveFiyatlari;
        }

        public List<Urunler> KagitUrunleriParse(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/temizlik/kagit-urunleri");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            //span[@class='price']
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> meyveFiyatlari = new List<Urunler>();
            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1025;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;

                var meyve = item.InnerText;
                urun.Marka = meyve.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = meyve;
                meyveFiyatlari.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                meyveFiyatlari[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(meyveFiyatlari[i]);
            }

            return meyveFiyatlari;
        }


        public List<Urunler> AgizBakimUrunleriParse(int kategoriID,int marketID)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/kisisel-bakim/agiz-bakim-urunleri");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            //span[@class='price']
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[@class='title']");

            List<Urunler> meyveFiyatlari = new List<Urunler>();
            foreach (HtmlNode item in element)
            {
                urun = new Urunler();
                urun.Aciklama_Id = 1025;
                urun.Birim_Id = 12;
                urun.Kategori_Id = kategoriID;

                var meyve = item.InnerText;
                urun.Marka = meyve.Split(' ')[0];
                urun.Market_Id = marketID;
                urun.Image = "";
                urun.Urun_Adi = meyve;
                meyveFiyatlari.Add(urun);
            }

            HtmlNodeCollection element2 = document.DocumentNode.SelectNodes("//span[@class='price']");
            for (int i = 0; i < element2.Count; i++)
            {
                databaseUrunler = new DatabaseUrunler();
                meyveFiyatlari[i].Fiyat = Convert.ToDouble(element2[i].InnerText.Replace("\n", "").Replace("\t", "").Replace("KDV DAHİL", "").Replace(" ", ""));
                databaseUrunler.InsertUrunler(meyveFiyatlari[i]);
            }

            return meyveFiyatlari;
        }


    }
}