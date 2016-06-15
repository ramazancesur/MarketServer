using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using test.Entity;
using test.Paterns;

namespace test.Resources
{
    public class DatabaseBirimler
    {

        MarketlerEntities3 db = SingletonDatabaseConteks.getDbConteks();
        public void InserBirimler(Birimler birimler)
        {
           
            db.Birimler.Add(birimler);
            db.SaveChanges();
        }

        public List<Birimler> allBirimlerList()
        {
            List<Birimler> birimlerList = db.Birimler
             .OrderByDescending(x => x.Birim_Id)
                .ToList();
            return birimlerList;
        }

        public Birimler getBirimlerbyID(int ID)
        {
            Birimler Birimler = db.Birimler.
                Where(x => x.Birim_Id == ID).FirstOrDefault();
            return Birimler;
        }

        public Birimler updateBirimler(Birimler Birimler)
        {

            db.Birimler.Attach(Birimler);
            var entry = db.Entry(Birimler);
            entry.State = EntityState.Modified;
            entry.Property(e => e.Birim_Adi).IsModified = false;
            db.SaveChanges();
            return Birimler;
        }

        public Birimler delete(Birimler Birimler)
        {
            db.Birimler.Remove(Birimler);
            db.SaveChanges();
            return Birimler;
        }
        public Birimler deleteByID(int id)
        {
            Birimler Birimler = db.Birimler.Where(x => x.Birim_Id == id).FirstOrDefault();
            db.Birimler.Remove(Birimler);
            db.SaveChanges();
            return Birimler;
        }
    }
}