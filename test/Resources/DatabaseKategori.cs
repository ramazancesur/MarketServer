using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using test.Entity;

namespace test
{
    public class DatabaseKategori
    {
        MarketlerEntities3 db = new MarketlerEntities3();        
        public void InserKategori(Kategori kategori)
        {
            var tempKategori = db.Kategori.Where(x => x.Kategori_Adi == kategori.Kategori_Adi).ToList();
            if (tempKategori.Count == 0) {
                db.Kategori.Add(kategori);
                db.SaveChanges();
            }
            else
            {
                updateKategori(tempKategori);
            }
        }
        public List<Kategori> updateKategori(List<Kategori> lstKategori)
        {
            foreach(Kategori kategori in lstKategori)
            {
                db.Kategori.Attach(kategori);
                var entry = db.Entry(kategori);
                entry.State = EntityState.Modified;
                entry.Property(e => e.Aciklamalar).IsModified = false;
                db.SaveChanges();
            }
           
            return lstKategori;
        }
        public List<Kategori> allKategoriList()
        {
            List<Kategori> kategoriList = db.Kategori
             .OrderByDescending(x => x.Kategori_Id)
                .ToList();
            return kategoriList;
        }

        public Kategori findKategoriByUrunID(int urunID)
        {
            Urunler urunler = db.Urunler.
                Where(x=>x.Urun_Id==urunID)
                   .FirstOrDefault();
            if (urunler.Kategori_Id != null)
            {
                int kategoriID =(int) urunler.Kategori_Id;
               return getKategoribyID(kategoriID);
            }
            return null;
        }

        public Kategori getKategoribyID(int ID)
        {
            Kategori kategori = db.Kategori.
                Where(x => x.Kategori_Id == ID).FirstOrDefault();
            return kategori;
        }
        public Kategori updateKategori(Kategori kategori)
        {
           
            db.Kategori.Attach(kategori);
            var entry = db.Entry(kategori);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Aciklamalar).IsModified = false;
            db.SaveChanges();
            return kategori;
        }
        public Kategori delete(Kategori kategori)
        {
            db.Kategori.Remove(kategori);
            db.SaveChanges();
            return kategori;
        }
        public Kategori deleteByID(int id)
        {
            Kategori kategori = db.Kategori.Where(x => x.Kategori_Id == id).FirstOrDefault();
            db.Kategori.Remove(kategori);
            db.SaveChanges();
            return kategori;
        }
    }
}
