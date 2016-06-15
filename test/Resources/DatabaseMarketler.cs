using Geocoding;
using Geocoding.Google;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using test.Entity;
using test.Paterns;
using test.ProjectDTO;

namespace test.Resources
{
    public class DatabaseMarketler
    {
        string coordinates;
        MarketlerEntities3 db = SingletonDatabaseConteks.getDbConteks();
        public Konumlar addMarketKonumu(string Address,string MarketAdi)
        {
            try
            {
                IGeocoder geocoder = new GoogleGeocoder() { };
                Address[] addresses = geocoder.Geocode(Address).ToArray();
                foreach (Address adrs in addresses)
                {
                    coordinates += adrs.Coordinates;
                }
                string Enlem = "";
                Konumlar konum = new Konumlar();
                string tempEnlem = coordinates.Split(' ')[0].Trim().TrimEnd(',');
                int sayac = 0;
                foreach (var item in tempEnlem.Split(','))
                {
                    if (sayac == 0)
                    {
                        Enlem = item + ".";
                    }
                    else if (sayac == 1)
                    {
                        Enlem += item;
                    }
                    sayac = sayac + 1;
                }
                konum.Enlem = tempEnlem;
                sayac = 0;
                string Boylam = "";
                string tempBoylam = coordinates.Split(' ')[1].Trim().TrimEnd(',');

                foreach (var item in tempBoylam.Split(','))
                {
                    if (sayac == 0)
                    {
                        Boylam = item + ".";
                    }
                    else if (sayac == 1)
                    {
                        Boylam += item;
                    }
                    sayac = sayac + 1;
                }

                konum.Boylam = Boylam;
                db.Konumlar.Add(konum);
                db.SaveChanges();
                return konum;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Konumlar();
            }
            
        }

        public void InserMarketler(Marketler market)
        {
            try
            {
                Konumlar konum = addMarketKonumu(market.Adress, market.Market_Adi);
                market.Konum_Id = konum.Konum_Id;

                db.Marketlers.Add(market);
                db.SaveChanges();
            }
            catch
            {

            }
         
        }
        public string getMarketKonumu(int konumid)
        {
            var marketKonum = db.Konumlar.
                Where(x => x.Konum_Id == konumid)
                .Select(x =>
                    new
                    {
                        x.Enlem,
                        x.Boylam
                    }
                ).FirstOrDefault();
            return marketKonum.Enlem+";"+marketKonum.Boylam;
        }

        public List<Marketler> getMarketbyName(string name)
        {
            var selectedMarket = db.Marketlers.Where(x => x.Market_Adi.ToUpper().Replace(" ","").Trim().Contains(name.ToUpper())).ToList();
            return selectedMarket;
        }

        public string getBirimbyUrun(int UrunID)
        {
          Nullable<int> birimID= db.Urunler
                .Where(x => x.Urun_Id == UrunID)
                .Select(x=>x.Birim_Id)
                .FirstOrDefault();
            var BirimAdiAciklamasi=db.Birimler.Where(x => x.Birim_Id == birimID).Select (x=>
                new 
                {
                       x.Birim_Adi,
                       x.Birim_Tutarı
                }
            ).FirstOrDefault();
            return BirimAdiAciklamasi.Birim_Tutarı + " " + BirimAdiAciklamasi.Birim_Adi;
        }
       
        public List<Urunler> getAllUrunlerByMarketID(int MarketID)
        {
            List<Urunler> lstUrunler = db.Urunler.
                Where(x => x.Market_Id == MarketID).OrderBy(x => x.Urun_Id)
                .ToList();
            return lstUrunler ;
        }
        public List<Marketler> allMarketlerList()
        {
            List<Marketler> MarketlerList = db.Marketlers
             .OrderByDescending(x => x.Market_Id)
                .ToList();
            return MarketlerList;
        }
        DatabaseKonumlar dbKonumlar;
       
        public Marketler getMarketlerbyID(int ID)
        {

            Marketler Marketler = db.Marketlers.
                Where(y => y.Market_Id == ID).FirstOrDefault();
            return Marketler;
        }

        public Marketler updateMarketler(Marketler Marketler)
        {

            db.Marketlers.Attach(Marketler);
            var entry = db.Entry(Marketler);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Market_Adi).IsModified = false;
            db.SaveChanges();
            return Marketler;
        }

        public Marketler delete(Marketler Marketler)
        {
            db.Marketlers.Remove(Marketler);
            db.SaveChanges();
            return Marketler;
        }
        public Marketler deleteByID(int id)
        {
            Marketler Marketler = db.Marketlers.Where(x => x.Market_Id == id).FirstOrDefault();
            db.Marketlers.Remove(Marketler);
            db.SaveChanges();
            return Marketler;
        }
    }
}