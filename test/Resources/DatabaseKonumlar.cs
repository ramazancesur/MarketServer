using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using test.Entity;
using test.Paterns;

namespace test.Resources
{
    public class DatabaseKonumlar
    {

        MarketlerEntities3 db = SingletonDatabaseConteks.getDbConteks();
        public void InsertKonumlar(Konumlar Konumlar)
        {

            db.Konumlar.Add(Konumlar);
            db.SaveChanges();
        }

        public List<Konumlar> allKonumlarList()
        {
            List<Konumlar> KonumlarList = db.Konumlar
             .OrderByDescending(x => x.Konum_Id)
                .ToList();
            return KonumlarList;
        }

        public Konumlar getKonumlarbyID(int ID)
        {
            Konumlar Konumlar = db.Konumlar.
                Where(x => x.Konum_Id == ID).FirstOrDefault();
            return Konumlar;
        }

        public Konumlar updateKonumlar(Konumlar Konumlar)
        {

            db.Konumlar.Attach(Konumlar);
            var entry = db.Entry(Konumlar);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Enlem).IsModified = false;
            db.SaveChanges();
            return Konumlar;
        }

        public Konumlar delete(Konumlar Konumlar)
        {
            db.Konumlar.Remove(Konumlar);
            db.SaveChanges();
            return Konumlar;
        }
        public Konumlar deleteByID(int id)
        {
            Konumlar Konumlar = db.Konumlar.Where(x => x.Konum_Id == id).FirstOrDefault();
            db.Konumlar.Remove(Konumlar);
            db.SaveChanges();
            return Konumlar;
        }
    }
}