using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using test.Entity;
using test.Resources;

namespace test.Parse
{
    public class MarketParse
    {
        private string GetContent(string AdressUrl)
        {
            Uri url = new Uri(AdressUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string html = client.DownloadString(url);
            return html;
        }
        private DatabaseKategori databaseKategori;
        private DatabaseAciklamalar databaseAciklama;
        private DatabaseUrunler databaseUrunler;
        private DatabaseBirimler databaseBirimler;
        public List<Urunler> urunInsert()
        {
            databaseUrunler = new DatabaseUrunler();
            databaseAciklama = new DatabaseAciklamalar();
            databaseBirimler = new DatabaseBirimler();

            List<Urunler> lstUrun = new List<Urunler>();

            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();

            //parse etmek istediğimiz siteyi yazıyoruz
            string htmlContext = GetContent("https://www.carrefoursa.com/");
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//div[contains(@class,'product')]");
            Urunler urunler;
            Birimler birim = new Birimler();
            birim.Birim_Adi = "kilo";
            birim.Birim_Tutarı = "1 kg";
            databaseBirimler.InserBirimler(birim);

            Aciklamalar aciklama = new Aciklamalar();
            databaseAciklama.InserAciklamalar(aciklama);
            foreach (HtmlNode item in element)
            {

                // Aciklama ve Birim eklenecek
                urunler = new Urunler();
                String urunAdi = item.InnerText;
                urunler.Birim_Id = birim.Birim_Id;
                urunler.Aciklama_Id = aciklama.Aciklama_Id;
                urunler.Urun_Adi = item.InnerText;
                databaseUrunler.InsertUrunler(urunler);
                lstUrun.Add(urunler);
            }
            return lstUrun ;
        }
        // Çoğu şey sabit ezbere bilmiyrum 
        public List<Kategori> getKategori()
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();

            //parse etmek istediğimiz siteyi yazıyoruz
            string htmlContext = GetContent("https://www.carrefoursa.com/");
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlContext);
            List<Kategori> lstKategori = new List<Kategori>();
        

            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//ul[contains(@class,'menu')]//li");
            Kategori kategori;
            databaseAciklama = new DatabaseAciklamalar();
            Aciklamalar aciklama = new Aciklamalar();
            aciklama.Aciklama = "Ana kategori";
            databaseAciklama.InserAciklamalar(aciklama);
            databaseKategori= new DatabaseKategori();
            foreach (HtmlNode item in element)
            {
                kategori = new Kategori();
                var kategoriName = item.InnerText;
                kategori.Aciklama_Id=aciklama.Aciklama_Id;
                kategori.Kategori_Adi = kategoriName;
                lstKategori.Add(kategori);
            }
            foreach (Kategori item in lstKategori)
            {
                databaseKategori.InserKategori(item);
            }
            return lstKategori;
        }

        public List<Urunler> urunInsert2()
        {
            databaseUrunler = new DatabaseUrunler();
            databaseAciklama = new DatabaseAciklamalar();
            databaseBirimler = new DatabaseBirimler();

            List<Urunler> lstUrun = new List<Urunler>();

            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();

            string htmlContext = GetContent("https://www.carrefoursa.com/");
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//div[contains(@class,'product')]");
            Urunler urunler;
            Birimler birim = new Birimler();
            birim.Birim_Adi = "kilo";
            birim.Birim_Tutarı = "1 kg";
            databaseBirimler.InserBirimler(birim);

            Aciklamalar aciklama = new Aciklamalar();
            databaseAciklama.InserAciklamalar(aciklama);
            foreach (HtmlNode item in element)
            {
                urunler = new Urunler();
                String urunAdi = item.InnerText;
                urunler.Birim_Id = birim.Birim_Id;
                urunler.Aciklama_Id = aciklama.Aciklama_Id;
                urunler.Urun_Adi = item.InnerText;
                databaseUrunler.InsertUrunler(urunler);
                lstUrun.Add(urunler);
            }
            return lstUrun;
        }


        DatabaseSub_Kategori databaseSubKategori = new DatabaseSub_Kategori();
        public List<Urunler> EtBalıkInsert()
        {
            databaseAciklama = new DatabaseAciklamalar();
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();

            //parse etmek istediğimiz siteyi yazıyoruz
            string htmlContext = GetContent("http://www.sanalmarket.com.tr/kweb/scview/30002-et-balik");
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//td[contains(@class,'uKLAdiAltLeft pad3')]");

            Aciklamalar aciklama = new Aciklamalar();
            aciklama.Aciklama = "Size ulaşana kadar 242 kontrolden geçen kaynağı belli, sağlıklı et Migros'ta!" +
                "Migros'ta etin kalitesi iyi hammadde seçmekle başlar." +
"Kontrollü kesim her zamanki gibi Migros'ta." +
"Etlerimiz güvenli bir şekilde depolanır ve soğutulur." +
"Gıda güvenliğiyle üretim ilkemiz; sağlıklı lezzetli ürünler hedefimiz." +
"Soğuk zinciri sağlayarak depolarız, günlük taze sevkiyatıyla mağazalarımıza ulaştırırız.";
            Sub_Kategori sub2;
            databaseAciklama.InserAciklamalar(aciklama);
            foreach (HtmlNode item in element)
            {
                sub2 = new Sub_Kategori();
                sub2.Kategori_Id = 2;
                sub2.Sub_Kategori_Adi = item.SelectSingleNode("a").InnerText;
                databaseSubKategori.InserSub_Kategori(sub2);
                
            }
            return null;
        }


        public List<Urunler> SutKAhgvaltiInsert()
        {
            databaseAciklama = new DatabaseAciklamalar();
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();

            //parse etmek istediğimiz siteyi yazıyoruz
            string htmlContext = GetContent("http://www.sanalmarket.com.tr/kweb/scview/30003-sut-kahvaltilik");
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//td[contains(@class,'uKLAdiAltLeft pad3')]");

            Aciklamalar aciklama = new Aciklamalar();
            aciklama.Aciklama = "Vücudun besin ihtiyacı sabah kahvaltısıyla başlar. Kahvaltıda süt içmek, yumurta yemek, portakal, salatalık ya da domates gibi sebze ya da meyve tüketmek güne dinamik ve sağlıklı başlamak açısından önemlidir.";
            Sub_Kategori sub2;
            databaseAciklama.InserAciklamalar(aciklama);
            foreach (HtmlNode item in element)
            {
                sub2 = new Sub_Kategori();
                sub2.Kategori_Id = 3;
                sub2.Sub_Kategori_Adi = item.SelectSingleNode("a").InnerText;
                databaseSubKategori.InserSub_Kategori(sub2);

            }
            return null;
        }

        
        public List<Urunler> GidaSekerInsert()
        {
            databaseAciklama = new DatabaseAciklamalar();
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();

            //parse etmek istediğimiz siteyi yazıyoruz
            string htmlContext = GetContent("http://www.sanalmarket.com.tr/kweb/scview/30004-gida-sekerleme");
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//td[contains(@class,'uKLAdiAltLeft pad3')]");

            Aciklamalar aciklama = new Aciklamalar();
            aciklama.Aciklama = "Kuru Baklagiller"+
"Türk mutfağının geleneksel yiyeceği kuru baklagiller, hem çok besleyicidir, hem de içerisinde bulunan lifler sayesinde uzun süreli tokluk sağlar.Kuru baklagiller aynı zamanda kalsiyum, demir, çinko, bakır gibi önemli mineralleri de içermektedir.";
            Sub_Kategori sub2;
            databaseAciklama.InserAciklamalar(aciklama);
            foreach (HtmlNode item in element)
            {
                sub2 = new Sub_Kategori();
                sub2.Kategori_Id = 3;
                sub2.Sub_Kategori_Adi = item.SelectSingleNode("a").InnerText;
                databaseSubKategori.InserSub_Kategori(sub2);

            }
            return null;
        }

        public List<Urunler> IcecekInsert()
        {
            databaseAciklama = new DatabaseAciklamalar();
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();

            //parse etmek istediğimiz siteyi yazıyoruz
            string htmlContext = GetContent("http://www.sanalmarket.com.tr/kweb/scview/30004-gida-sekerleme");
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//td[contains(@class,'uKLAdiAltLeft pad3')]");

            Aciklamalar aciklama = new Aciklamalar();
            aciklama.Aciklama =
"Sıvı Tüketimi"+
"Yaşamımız için gerekli olan su vücutta birçok önemli rol oynar. Vücudumuz metabolizmamız için gerekli olan sıvıyı depolayamaz.Dolayısıyla sağlığımız ve vücut verimliliği için kaybolan su miktarı devamlı yenilenmelidir.Günlük olarak ne kadar sıvıya ihtiyacımız olduğunu gün içinde yaptığımız fiziksel hareketler belirler.Fiziksel olarak daha aktif olan kişiler daha fazla sıvıya ihtiyaç duyar.Günlük sıvı ihtiyacımızın % 80'ini su ve içeceklerden, %20'sini ise çeşitli gıdalardan karşılarız.Genel olarak susuzluğumuzu su içerek karşılasak da, aynı zamanda meyve suları, süt, kahve, çay, alkolsüz içecekler, meyve, sebze ve birçok gıda ve içeceklerden de sıvı ihtiyacı karşılanmaktadır.";

            Sub_Kategori sub2;
            databaseAciklama.InserAciklamalar(aciklama);
            foreach (HtmlNode item in element)
            {
                sub2 = new Sub_Kategori();
                sub2.Kategori_Id = 3;
                sub2.Sub_Kategori_Adi = item.SelectSingleNode("a").InnerText;
                databaseSubKategori.InserSub_Kategori(sub2);

            }
            return null;
        }
        public List<Urunler> DeterjanInsert()
        {
            databaseAciklama = new DatabaseAciklamalar();
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            string htmlContext = GetContent("http://www.sanalmarket.com.tr/kweb/scview/30006-deterjan-temizlik");
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlContext);
            HtmlNodeCollection element = document.DocumentNode.SelectNodes("//td[contains(@class,'uKLAdiAltLeft pad3')]");

            Aciklamalar aciklama = new Aciklamalar();
            aciklama.Aciklama = "Kullanılacak çamaşır deterjan miktarı," +
                 "çamaşır miktarına, kirlilik derecesine ve suyun sertliğine bağlıdır. " +
                "Deterjan paketinin üzerindeki üretici talimatlarını dikkatle okuyun ve dozaj" +
                "değerlerine uyun.Aşırı köpük ve iyi durulamama sorunlarını engellemek," +
                "maddi tasarruf sağlamak ve çevreyi korumak amacıyla, deterjan paketinin üzerindeki tavsiye edilen " +
                "dozaj değerlerini aşmayın. Az miktarda ya da az kirli çamaşırlar için daha az deterjan kullanın." +
                "Konsantre deterjanları tavsiye edilen dozajda kullanın. Kullanılacak deterjan türü," +
                "kumaş cinsine ve rengine bağlıdır.Renkli ve beyaz çamaşırlar için ayrı deterjanlar kullanın. " +
                "Hassas çamaşırlarınızı, yalnızca hassas çamaşırlar için kullanılan özel " +
                "deterjanlarla (sıvı deterjan, yün şampuanı vb.) yıkayın.Koyu renkli çamaşır ve yorganları " +
                "yıkarken sıvı deterjan kullanmanız önerilir.Yünlüleri, yalnızca yünlüler için kullanılan özel " +
                "bir deterjanla yıkayın.Sadece otomatik çamaşır makineleri için, özel olarak üretilmiş deterjanları" +
                "kullanın.Sabun tozu kullanmayın.";
            Sub_Kategori sub2;
            databaseAciklama.InserAciklamalar(aciklama);
            foreach (HtmlNode item in element)
            {
                sub2 = new Sub_Kategori();
                sub2.Kategori_Id = 3;
                sub2.Sub_Kategori_Adi = item.SelectSingleNode("a").InnerText;
                databaseSubKategori.InserSub_Kategori(sub2);

            }
            return null;
        }

    }
}