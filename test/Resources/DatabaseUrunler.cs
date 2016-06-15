using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using test.Entity;
using test.Paterns;

namespace test.Resources
{
    public class DatabaseUrunler
    {

        MarketlerEntities3 db = SingletonDatabaseConteks.getDbConteks();
        public void InsertUrunler(Urunler Urunler)
        {
            var tempUrunler = db.Urunler.Where(x => x.Urun_Adi.Equals(Urunler.Urun_Adi)).ToList();
            if (tempUrunler.Count == 0)
            {
                db.Urunler.Add(Urunler);
                if (Urunler.Urun_Id != 0)
                    db.SaveChanges();
            }
            else
            {
                updateUrunler(tempUrunler);
            }
        }
        public List<Urunler> getUrunbyName(string name)
        {
            var urun = db.Urunler.Where(
                x => x.Urun_Adi.Trim().ToUpper().Contains(name.ToUpper())
                ).ToList();
            return urun;
        }
        public List<Urunler> getUrunbyMarka(string markaAdi)
        {
            var urunlerList = db.Urunler.Where(x => x.Marka.ToUpper().Trim()
                    .Contains( markaAdi.Trim().ToUpper())).ToList();
            return urunlerList;
        }
        public List<Urunler> getEnUcuz(string name)
        {
            var urunList = db.Urunler.Where(
                x => x.Urun_Adi.ToUpper().Contains(name.ToUpper().Trim())
              ).
              OrderByDescending(x=>x.Fiyat)
              .ToList();
            return urunList;
        }
        public List<Urunler> allUrunlerList()
        {
            List<Urunler> UrunlerList = db.Urunler
                .ToList();
            return UrunlerList;
        }
        public List<Urunler> findUrunbyKategoriID(string KategoriID)
        {
            int kategoriID = Convert.ToInt32(KategoriID);
            List<Urunler> UrunlerList = db.Urunler.
                Where(x=>x.Kategori_Id==kategoriID)
                .ToList();
            return UrunlerList;
        }
        DatabaseMarketler dbMarketler;
        public List<Urunler> findUrunByMarketAndUrunAdi(string MarketAdi,string urunAdi)
        {
            List<Urunler> lstResult = new List<Urunler>();
            List<Urunler> lstUruns;
            dbMarketler = new DatabaseMarketler();
            List<Marketler> lstMarket = dbMarketler.getMarketbyName(MarketAdi);
            lstUruns = db.Urunler.Where(x=>x.Urun_Adi.Trim().ToUpper().Contains(urunAdi.Trim().ToUpper() ) ).ToList();
            foreach (var markets in lstMarket)
            {
                foreach (var urun in lstUruns)
                {
                    int marketID = 0;
                    if (urun.Market_Id.HasValue)
                    {
                        marketID = urun.Market_Id.Value;
                    }
                    if (marketID == markets.Market_Id)
                    {
                        lstResult.Add(urun);
                    }
                }
            }

           return lstResult;
        }
        public List<Urunler> findUrunbyKategoriIDandMarketID(string KategoriID,string MarketID)
        {
            List<Urunler> urunList = new List<Urunler>();
            int kategoriID = Convert.ToInt32(KategoriID);
            int marketID = Convert.ToInt32(MarketID);
            List<Urunler> lstUrunler = findUrunbyKategoriID(KategoriID);
            foreach (var urun in lstUrunler)
            {
                int mID = 0;
                if (urun.Market_Id.HasValue)
                {
                    mID = urun.Market_Id.Value;
                }
                if (mID == marketID)
                {
                    urunList.Add(urun);
                }
            }
            return urunList;
        }
        public Urunler getUrunlerbyID(int ID)
        {
            
            Urunler urun = db.Urunler.
                Where(y => y.Urun_Id == ID).FirstOrDefault();
            return urun;
        }

        public Urunler updateUrunler(Urunler Urunler)
        {

            db.Urunler.Attach(Urunler);
            var entry = db.Entry(Urunler);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Urun_Adi).IsModified = true;
            db.SaveChanges();
            return Urunler;
        }

        public List<Urunler> updateUrunler(List<Urunler> Urunler)
        {
            foreach (var urun in Urunler)
            {
                db.Urunler.Attach(urun);
                var entry = db.Entry(urun);
                entry.State = EntityState.Modified;
                entry.Property(e => e.Urun_Adi).IsModified = true;
                entry.Property(e => e.Marka).IsModified = true;
                entry.Property(e => e.Market_Id).IsModified = true;
                entry.Property(e => e.Urun_Id).IsModified = true;
                db.SaveChanges();
            }
            
            return Urunler;
        }

        public Urunler delete(Urunler Urunler)
        {
            db.Urunler.Remove(Urunler);
            db.SaveChanges();
            return Urunler;
        }
        public Urunler deleteByID(int id)
        {
            Urunler Urunler = db.Urunler.Where(x => x.Urun_Id == id).FirstOrDefault();
            db.Urunler.Remove(Urunler);
            db.SaveChanges();
            return Urunler;
        }
    }
}