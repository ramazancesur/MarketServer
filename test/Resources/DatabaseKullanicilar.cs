using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using test.Entity;
using test.Paterns;

namespace test.Resources
{
    public class DatabaseKullanicilar
    {
        MarketlerEntities3 db = SingletonDatabaseConteks.getDbConteks();
        public void InserKullanicilar(Kullanicilar Kullanicilar)
        {

            db.Kullanicilar.Add(Kullanicilar);
            db.SaveChanges();
        }

        public List<Kullanicilar> allKullanicilarList()
        {
            List<Kullanicilar> KullanicilarList = db.Kullanicilar
             .OrderByDescending(x => x.User_Id)
                .ToList();
            return KullanicilarList;
        }

        public Kullanicilar getKullanicilarbyID(int ID)
        {
            Kullanicilar Kullanicilar = db.Kullanicilar.
                Where(x => x.User_Id == ID).FirstOrDefault();
            return Kullanicilar;
        }

        public Kullanicilar getKullanicilarbyEmail(string EMail,string Sifre)
        {
            Kullanicilar Kullanicilar = db.Kullanicilar.
                Where(x => x.E_mail.Equals(EMail)||x.Sifre.Equals(Sifre))
                .FirstOrDefault();
            return Kullanicilar;
        }
        public Kullanicilar updateKullanicilar(Kullanicilar Kullanicilar)
        {

            db.Kullanicilar.Attach(Kullanicilar);
            var entry = db.Entry(Kullanicilar);
            entry.State = EntityState.Modified;
            entry.Property(e => e.User_Adi).IsModified = false;
            db.SaveChanges();
            return Kullanicilar;
        }


        public Kullanicilar delete(Kullanicilar Kullanicilar)
        {
            db.Kullanicilar.Remove(Kullanicilar);
            db.SaveChanges();
            return Kullanicilar;
        }
        public Kullanicilar deleteByID(int id)
        {
            Kullanicilar Kullanicilar = db.Kullanicilar.Where(x => x.User_Id == id).FirstOrDefault();
            db.Kullanicilar.Remove(Kullanicilar);
            db.SaveChanges();
            return Kullanicilar;
        }
    }
}