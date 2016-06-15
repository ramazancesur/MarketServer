using System;
using System.Collections.Generic;
using test.ProjectDTO;
using test.Resources;
using test.RestWs.Dao.Kullanici;
using test.Entity;
namespace test.RestWs.Dao
{
    public class KullaniciDao : IKullaniciDao
    {
        
        public KullaniciDao()
        {
            init();
        }
        DatabaseKullanicilar databaseKullanicilar;
        KullaniciDTO kullaniciDTO;
        Kullanicilar kullanici;
        private void init()
        {
            databaseKullanicilar = new DatabaseKullanicilar();
        }

        public List<KullaniciDTO> lstKullanici()
        {
            List<KullaniciDTO> lstKullaniciDTO = new List<KullaniciDTO>();
            List<Kullanicilar>kullaniciList = databaseKullanicilar.allKullanicilarList();
           
            foreach (var kullanici in kullaniciList)
            {
                kullaniciDTO = new KullaniciDTO();
                kullaniciDTO.EMail = kullanici.E_mail;
                kullaniciDTO.Sifre = kullanici.Sifre;
                kullaniciDTO.KullaniciID = kullanici.User_Id;
                kullaniciDTO.AdiSoyadi = kullanici.User_Adi;
                lstKullaniciDTO.Add(kullaniciDTO);
            }
            return lstKullaniciDTO;
        }

        public KullaniciDTO getKullaniciByLogin(string EMail, string Sifre)
        {
            // En son bu
            kullanici = databaseKullanicilar.getKullanicilarbyEmail(EMail, Sifre);
            kullaniciDTO = new KullaniciDTO();
            kullaniciDTO.EMail = kullanici.E_mail;
            kullaniciDTO.Sifre = kullanici.Sifre;
            kullaniciDTO.AdiSoyadi = kullanici.User_Adi;
            return kullaniciDTO;
        }

        public KullaniciDTO getKullaniciByID(int id)
        {
            kullanici = databaseKullanicilar.getKullanicilarbyID(id);
            kullaniciDTO = new KullaniciDTO();
            kullaniciDTO.EMail = kullanici.E_mail;
            kullaniciDTO.Sifre = kullanici.Sifre;
            kullaniciDTO.AdiSoyadi = kullanici.User_Adi;
            return kullaniciDTO;
        }
    }
}