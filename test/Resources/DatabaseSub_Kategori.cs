using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using test.Entity;
using test.Paterns;

namespace test.Resources
{
    public class DatabaseSub_Kategori
    {

        MarketlerEntities3 db = SingletonDatabaseConteks.getDbConteks();
        public void InserSub_Kategori(Sub_Kategori Sub_Kategori)
        {

            db.Sub_Kategori.Add(Sub_Kategori);
            db.SaveChanges();
        }

        public List<Sub_Kategori> allSub_KategoriList()
        {
            List<Sub_Kategori> Sub_KategoriList = db.Sub_Kategori
             .OrderByDescending(x => x.Sub_Kategori_Id)
                .ToList();
            return Sub_KategoriList;
        }

        public Sub_Kategori getSub_KategoribyID(int ID)
        {

            Sub_Kategori Sub_Kategori = db.Sub_Kategori.
                Where(y => y.Sub_Kategori_Id == ID).FirstOrDefault();
            return Sub_Kategori;
        }

        public Sub_Kategori updateSub_Kategori(Sub_Kategori Sub_Kategori)
        {

            db.Sub_Kategori.Attach(Sub_Kategori);
            var entry = db.Entry(Sub_Kategori);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Sub_Kategori_Adi).IsModified = false;
            db.SaveChanges();
            return Sub_Kategori;
        }

        public Sub_Kategori delete(Sub_Kategori Sub_Kategori)
        {
            db.Sub_Kategori.Remove(Sub_Kategori);
            db.SaveChanges();
            return Sub_Kategori;
        }
        public Sub_Kategori deleteByID(int id)
        {
            Sub_Kategori Sub_Kategori = db.Sub_Kategori.Where(x => x.Sub_Kategori_Id == id).FirstOrDefault();
            db.Sub_Kategori.Remove(Sub_Kategori);
            db.SaveChanges();
            return Sub_Kategori;
        }
    }
}