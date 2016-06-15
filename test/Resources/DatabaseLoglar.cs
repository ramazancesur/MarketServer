using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using test.Entity;
using test.Paterns;

namespace test.Resources
{
    public class DatabaseLoglar
    {

        MarketlerEntities3 db = SingletonDatabaseConteks.getDbConteks();
        public void InserLoglar(Loglar Loglar)
        {

            db.Loglar.Add(Loglar);
            db.SaveChanges();
        }

        public List<Loglar> allLoglarList()
        {
            List<Loglar> LoglarList = db.Loglar
             .OrderByDescending(x => x.Log_Id)
                .ToList();
            return LoglarList;
        }

        public Loglar getLoglarbyID(int ID)
        {
            Loglar Loglar = db.Loglar.
                Where(x => x.Log_Id == ID).FirstOrDefault();
            return Loglar;
        }

        public Loglar updateLoglar(Loglar Loglar)
        {

            db.Loglar.Attach(Loglar);
            var entry = db.Entry(Loglar);
            entry.State = EntityState.Modified;
           // entry.Property(e => e.Birim_Adi).IsModified = false;
            db.SaveChanges();
            return Loglar;
        }

        public Loglar delete(Loglar Loglar)
        {
            db.Loglar.Remove(Loglar);
            db.SaveChanges();
            return Loglar;
        }
        public Loglar deleteByID(int id)
        {
            Loglar Loglar = db.Loglar.Where(x => x.Log_Id == id).FirstOrDefault();
            db.Loglar.Remove(Loglar);
            db.SaveChanges();
            return Loglar;
        }
    }
}