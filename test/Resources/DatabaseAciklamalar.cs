using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using test.Entity;
using test.Paterns;

namespace test.Resources
{
    public class DatabaseAciklamalar
    {
        MarketlerEntities3 db = SingletonDatabaseConteks.getDbConteks();
        public void InserAciklamalar(Aciklamalar Aciklamalar)
        {

            db.Aciklamalar.Add(Aciklamalar);
            db.SaveChanges();
        }

        public List<Aciklamalar> allAciklamalarList()
        {
            List<Aciklamalar> AciklamalarList = db.Aciklamalar
             .OrderByDescending(x => x.Aciklama_Id)
                .ToList();
            return AciklamalarList;
        }

        public Aciklamalar getAciklamalarbyID(int ID)
        {
            Aciklamalar Aciklamalar = db.Aciklamalar.
                Where(x => x.Aciklama_Id == ID).FirstOrDefault();
            return Aciklamalar;
        }

        public Aciklamalar updateAciklamalar(Aciklamalar Aciklamalar)
        {

            db.Aciklamalar.Attach(Aciklamalar);
            var entry = db.Entry(Aciklamalar);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Aciklama).IsModified = false;
            db.SaveChanges();
            return Aciklamalar;
        }

        public Aciklamalar delete(Aciklamalar Aciklamalar)
        {
            db.Aciklamalar.Remove(Aciklamalar);
            db.SaveChanges();
            return Aciklamalar;
        }
        public Aciklamalar deleteByID(int id)
        {
            Aciklamalar Aciklamalar = db.Aciklamalar.Where(x => x.Aciklama_Id == id).FirstOrDefault();
            db.Aciklamalar.Remove(Aciklamalar);
            db.SaveChanges();
            return Aciklamalar;
        }
    }
}