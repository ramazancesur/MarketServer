using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace test.Parse
{
    public class KıymaParse
    {
        private HtmlDocument document;

        public string GetContent(string AdressUrl)
        {
            Uri url = new Uri(AdressUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            // utf 8 olduğu için türkçe karakter sorunu yapmayacak

            string html = client.DownloadString(url);
            return html;
        }

        public List<string> kiymaParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("http://etbalikkadikoy.com/fiyat_listesi.htm");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);

            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//table[contains(@class,’tablo01′)]//tr");

            List<String> kiymaFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var kiyma = item.InnerText;
                kiymaFiyatlari.Add(kiyma);
            }

            return kiymaFiyatlari;
        }


        public List<string> meyveParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("http://tarim.com.tr/Hal-Fiyatlari.aspx?Ara=%7Cil%7CAnkara-Hali%7Cilid%7C2");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);

            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//div[contains(@class,’no-more-table′)]//tr");

            List<String> meyveFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var meyve = item.InnerText;
                meyveFiyatlari.Add(meyve);
            }

            return meyveFiyatlari;
        }

        public List<string> SütParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/sut-kahvaltilik/sutler");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> sutFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var sut = item.InnerText;
                sutFiyatlari.Add(sut);
            }
            return sutFiyatlari;
        }

        public List<string> hazirGidaParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/gida-yemek-malzemeleri/hazir-corbalar-yemekler");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> hazirGidaFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var hazirGida = item.InnerText;
                hazirGidaFiyatlari.Add(hazirGida);
            }
            return hazirGidaFiyatlari;
        }
       
        public List<string> SiviYagParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/gida-yemek-malzemeleri/sivi-yaglar");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> siviYagFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var siviYag = item.InnerText;
                siviYagFiyatlari.Add(siviYag);
            }
            return siviYagFiyatlari;
        }

        
             
        public List<string> BakliyatParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/gida-yemek-malzemeleri/makarna-pirinc-ve-bakliyat");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> bakliyatFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var bakliyat = item.InnerText;
                bakliyatFiyatlari.Add(bakliyat);
            }
            return bakliyatFiyatlari;
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



        public List<string> KuruyemisParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/sekerleme-kuruyemis/kuruyemis");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> KuruyemisFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var Kuruyemis = item.InnerText;
                KuruyemisFiyatlari.Add(Kuruyemis);
            }
            return KuruyemisFiyatlari;
        }



        public List<string> IcecekParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/icecek/kahve");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> IcecekFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var Icecek = item.InnerText;
                IcecekFiyatlari.Add(Icecek);
            }
            return IcecekFiyatlari;
        }

        public List<string> GazlıIcecekParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent(https://www.carrefoursa.com/r/icecek/gazli-icecekler");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> GazliIcecekFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var gazliIcecek = item.InnerText;
               GazliIcecekFiyatlari.Add(gazliIcecek);
            }
            return GazliIcecekFiyatlari;
        }


        public List<string> SuParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/icecek/sular");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> SuFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var Su = item.InnerText;
                SuFiyatlari.Add(Su);
            }
            return SuFiyatlari;
        }

        public List<string> MeyveSulariParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/icecek/meyve-sulari");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> MeyveSulariFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var MeyveSulari = item.InnerText;
                MeyveSulariFiyatlari.Add(MeyveSulari);
            }
            return MeyveSulariFiyatlari;
        }


        public List<string> EvTemizlikMalzemeleriParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/temizlik/ev-temizlik-urunleri");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> EvTemizlikMalzemeleriFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var EvTemizlikMalzemeleri = item.InnerText;
                EvTemizlikMalzemeleriFiyatlari.Add(EvTemizlikMalzemeleri);
            }
            return EvTemizlikMalzemeleriFiyatlari;
        }

        public List<string> KagitUrunleriParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/temizlik/kagit-urunleri");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> KagitUrunleriFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var KagitUrunleri = item.InnerText;
                KagitUrunleriFiyatlari.Add(KagitUrunleri);
            }
            return KagitUrunleriFiyatlari;
        }

        public List<string> KokuGidericileriParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/temizlik/oda-kokulari-ve-koku-gidericiler");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> KokuGidericileriFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var KokuGidericileri = item.InnerText;
                KokuGidericileriFiyatlari.Add(KokuGidericileri);
            }
            return KokuGidericileriFiyatlari;
        }

        public List<string> TirasUrunleriParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/kisisel-bakim/tiras-urunleri");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> TirasUrunleriFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var TirasUrunleri = item.InnerText;
                TirasUrunleriFiyatlari.Add(TirasUrunleri);
            }
            return TirasUrunleriFiyatlari;
        }

        public List<string> BebekUrunleriParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/kisisel-bakim/bebek-urunleri");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> BebekUrunleriFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var BebekUrunleri = item.InnerText;
                BebekUrunleriFiyatlari.Add(BebekUrunleri);
            }
            return BebekUrunleriFiyatlari;
        }

        public List<string> AgizBakimUrunleriParse()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("https://www.carrefoursa.com/r/kisisel-bakim/agiz-bakim-urunleri");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//a[contains(@class,’title′)]");
            List<String> AgizBakimUrunleriFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var AgizBakimUrunleri = item.InnerText;
                AgizBakimUrunleriFiyatlari.Add(AgizBakimUrunleri);
            }
            return AgizBakimUrunleriFiyatlari;
        }

        public List<string> ParfarmParser()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("http://www.hepsiburada.com/kadin-parfumler-c-32010684");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//div[contains(@class,’product-detail′)]//p");
            List<String> AgizBakimUrunleriFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var AgizBakimUrunleri = item.InnerText;
                AgizBakimUrunleriFiyatlari.Add(AgizBakimUrunleri);
            }
            return AgizBakimUrunleriFiyatlari;
        }



        public List<string> RujParser()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("http://www.hepsiburada.com/kozmetik-dudak-urunleri-c-32010967");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//div[contains(@class,’product-detail′)]//p");
            List<String> AgizBakimUrunleriFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var AgizBakimUrunleri = item.InnerText;
                AgizBakimUrunleriFiyatlari.Add(AgizBakimUrunleri);
            }
            return AgizBakimUrunleriFiyatlari;
        }


        public List<string> TraşParser()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("http://www.hepsiburada.com/tiras-sabunkremkopuk-jelleri-c-26012158");
            document = new HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//div[contains(@class,’product-detail′)]//p");
            List<String> AgizBakimUrunleriFiyatlari = new List<string>();
            foreach (HtmlNode item in element)
            {
                var AgizBakimUrunleri = item.InnerText;
                AgizBakimUrunleriFiyatlari.Add(AgizBakimUrunleri);
            }
            return AgizBakimUrunleriFiyatlari;
        }


        //... bu da böyle gidecek 

        

    }
}