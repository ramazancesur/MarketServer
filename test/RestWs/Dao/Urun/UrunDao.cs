using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Entity;
using test.ProjectDTO;
using test.Resources;
using test.RestWs.ProjectDTO;

namespace test.RestWs.Dao.Urun
{
    public class UrunDao : IUrunDao
    {
        UrunlerDTO urunlerDTO;
        Urunler urunler;
        
        DatabaseKategori databaseKategori;

        DatabaseUrunler databaseUrunler;
        DatabaseMarketler databaseMarketler;
        DatabaseKonumlar databaseKonunlar;
        List<Urunler> lstUrunler;
        Entity.Kategori kategori;
        List<UrunlerDTO> lstUrunlerDTO;
        public UrunDao()
        {
            init();
        }
        private void init()
        {
            databaseKategori = new DatabaseKategori();
            lstUrunlerDTO = new List<UrunlerDTO>();
            lstUrunler = new List<Urunler>();
            databaseMarketler = new DatabaseMarketler();
            databaseKonunlar = new DatabaseKonumlar();
            kategori = new Entity.Kategori();
            urunler = new Urunler();
            urunlerDTO = new UrunlerDTO();
            databaseUrunler = new DatabaseUrunler();
        }


        public List<UrunlerDTO> findUrunByKategoriandMarket(string kategoriID,string marketID)
        {
            lstUrunler = new List<Urunler>();
            lstUrunlerDTO = new List<UrunlerDTO>();
            lstUrunler = databaseUrunler.findUrunbyKategoriIDandMarketID(kategoriID, marketID);

            foreach (Urunler urun in lstUrunler)
            {
                urunlerDTO = new UrunlerDTO();
                urunlerDTO.Marka = urun.Marka;
                urunlerDTO.MarketID = urun.Market_Id;
                urunlerDTO.Fiyat = urun.Fiyat;
                KategoriDTO kategoriDTO = new KategoriDTO();
                Entity.Kategori kategori = databaseKategori.findKategoriByUrunID(urun.Urun_Id);

                if (kategori != null)
                {
                    kategoriDTO.kategoriAdi = kategori.Kategori_Adi;
                    kategoriDTO.kategoriID = kategori.Kategori_Id;
                    urunlerDTO.kategoriDTO = kategoriDTO;
                }

                urunlerDTO.UrunID = urun.Urun_Id;
                urunlerDTO.UrunAdi = urun.Urun_Adi;
                urunlerDTO.UrunBirimAciklama = databaseMarketler.getBirimbyUrun(urun.Urun_Id);
                lstUrunlerDTO.Add(urunlerDTO);
            }
            return lstUrunlerDTO;
        }


        public List<UrunlerDTO>findUrunByKategori(string kategoriID)
        {
            lstUrunlerDTO = new List<UrunlerDTO>();
            lstUrunler = new List<Urunler>();
            lstUrunler = databaseUrunler.findUrunbyKategoriID(kategoriID).ToList();

            foreach (Urunler urun in lstUrunler)
            {
                urunlerDTO = new UrunlerDTO();
                urunlerDTO.Marka = urun.Marka;
                urunlerDTO.MarketID = urun.Market_Id;
                urunlerDTO.Fiyat = urun.Fiyat;
                KategoriDTO kategoriDTO = new KategoriDTO();
                Entity.Kategori kategori = databaseKategori.findKategoriByUrunID(urun.Urun_Id);

                if (kategori != null)
                {
                    kategoriDTO.kategoriAdi = kategori.Kategori_Adi;
                    kategoriDTO.kategoriID = kategori.Kategori_Id;
                    urunlerDTO.kategoriDTO = kategoriDTO;
                }

                urunlerDTO.UrunID = urun.Urun_Id;
                urunlerDTO.UrunAdi = urun.Urun_Adi;
                urunlerDTO.UrunBirimAciklama = databaseMarketler.getBirimbyUrun(urun.Urun_Id);
                lstUrunlerDTO.Add(urunlerDTO);
            }
            return lstUrunlerDTO;
        }

        public List<UrunlerDTO> allUrunler()
        {
            lstUrunler= databaseUrunler.allUrunlerList();
            foreach (Urunler urun in lstUrunler)
            {
                urunlerDTO=new UrunlerDTO();
                urunlerDTO.Marka = urun.Marka;
                urunlerDTO.MarketID = urun.Market_Id;
                urunlerDTO.Fiyat = urun.Fiyat;
                KategoriDTO  kategoriDTO = new KategoriDTO();
                Entity.Kategori kategori = databaseKategori.findKategoriByUrunID(urun.Urun_Id);

                if (kategori != null)
                {
                    kategoriDTO.kategoriAdi = kategori.Kategori_Adi;
                    kategoriDTO.kategoriID= kategori.Kategori_Id;
                    urunlerDTO.kategoriDTO = kategoriDTO;
                }
               
                urunlerDTO.UrunID = urun.Urun_Id;
                urunlerDTO.UrunAdi = urun.Urun_Adi;
                urunlerDTO.UrunBirimAciklama = databaseMarketler.getBirimbyUrun(urun.Urun_Id);
                lstUrunlerDTO.Add(urunlerDTO);
            }
            return lstUrunlerDTO;
        }
        
        public List<UrunlerDTO> findbyEcuz(string urunName)
        {
            kategori = new Entity.Kategori();
            lstUrunler = new List<Urunler>();
            lstUrunlerDTO = new List<UrunlerDTO>();
            lstUrunler = databaseUrunler.getEnUcuz(urunName);
            foreach (Urunler urun in lstUrunler)
            {
                urunlerDTO = new UrunlerDTO();
                    urunlerDTO.Fiyat = urun.Fiyat; 
                    urunlerDTO.Fiyat = urun.Fiyat;
                    urunlerDTO.UrunID = urun.Urun_Id;
                KategoriDTO kategoriDTO = new KategoriDTO();
                Entity.Kategori kategori = databaseKategori.findKategoriByUrunID(urun.Urun_Id);

                if (kategori != null)
                {
                    kategoriDTO.kategoriAdi = kategori.Kategori_Adi;
                    kategoriDTO.kategoriID = kategori.Kategori_Id;
                    urunlerDTO.kategoriDTO = kategoriDTO;
                }
                urunlerDTO.UrunAdi = urun.Urun_Adi;
                    urunlerDTO.UrunBirimAciklama = databaseMarketler.getBirimbyUrun(urun.Urun_Id);
                    lstUrunlerDTO.Add(urunlerDTO);
                urunlerDTO.UrunID = urun.Urun_Id;
                urunlerDTO.UrunAdi = urun.Urun_Adi;
                urunlerDTO.UrunBirimAciklama = databaseMarketler.getBirimbyUrun(urun.Urun_Id);
                lstUrunlerDTO.Add(urunlerDTO);
            }
            return lstUrunlerDTO;
        }

        public List<UrunlerDTO> findByMarka(string markaAdi)
        {
            lstUrunler = new List<Urunler>();
            lstUrunler = databaseUrunler.getUrunbyMarka(markaAdi);
            lstUrunlerDTO = new List<UrunlerDTO>();
            foreach (Urunler urun in lstUrunler)
            {
                urunlerDTO = new UrunlerDTO();
                urunlerDTO.Fiyat = urun.Fiyat;
                urunlerDTO.Fiyat = urun.Fiyat;
                urunlerDTO.UrunID = urun.Urun_Id;
                urunlerDTO.UrunAdi = urun.Urun_Adi;
                urunlerDTO.UrunBirimAciklama = databaseMarketler.getBirimbyUrun(urun.Urun_Id);
                KategoriDTO kategoriDTO = new KategoriDTO();
                Entity.Kategori kategori = databaseKategori.findKategoriByUrunID(urun.Urun_Id);

                if (kategori != null)
                {
                    kategoriDTO.kategoriAdi = kategori.Kategori_Adi;
                    kategoriDTO.kategoriID = kategori.Kategori_Id;
                    urunlerDTO.kategoriDTO = kategoriDTO;
                }
                urunlerDTO.Marka = urun.Marka;
                urunlerDTO.MarketID = urun.Market_Id;
                urunlerDTO.UrunID = urun.Urun_Id;
                urunlerDTO.UrunAdi = urun.Urun_Adi;
                urunlerDTO.UrunBirimAciklama = databaseMarketler.getBirimbyUrun(urun.Urun_Id);
                lstUrunlerDTO.Add(urunlerDTO);
            }
            return lstUrunlerDTO;
        }
        
        public UrunlerDTO findbyUrunID(int id)
        {
            urunlerDTO = new UrunlerDTO();
            Urunler urun = databaseUrunler.getUrunlerbyID(id);
            urunlerDTO.Marka = urun.Marka;
            urunlerDTO.Fiyat = urun.Fiyat;
            urunlerDTO.Fiyat = urun.Fiyat;
            urunlerDTO.UrunID = urun.Urun_Id;
            urunlerDTO.UrunAdi = urun.Urun_Adi;
            urunlerDTO.UrunBirimAciklama = databaseMarketler.getBirimbyUrun(urun.Urun_Id);
            KategoriDTO kategoriDTO = new KategoriDTO();
            Entity.Kategori kategori = databaseKategori.findKategoriByUrunID(urun.Urun_Id);

            if (kategori != null)
            {
                kategoriDTO.kategoriAdi = kategori.Kategori_Adi;
                kategoriDTO.kategoriID = kategori.Kategori_Id;
                urunlerDTO.kategoriDTO = kategoriDTO;
            }

            urunlerDTO.UrunID = urun.Urun_Id;
            urunlerDTO.UrunAdi = urun.Urun_Adi;
            urunlerDTO.UrunBirimAciklama = databaseMarketler.getBirimbyUrun(urun.Urun_Id);
            return urunlerDTO;
        }

        public List<UrunlerDTO> findUrunbyName(string name)
        {
            lstUrunlerDTO = new List<UrunlerDTO>();
            lstUrunler = new List<Urunler>();
            lstUrunler = databaseUrunler.getUrunbyName(name);
            foreach (Urunler urun in lstUrunler)
            {
                KategoriDTO kategoriDTO = new KategoriDTO();
                Entity.Kategori kategori = databaseKategori.findKategoriByUrunID(urun.Urun_Id);
                urunlerDTO = new UrunlerDTO();
                if (kategori != null)
                {
                    kategoriDTO.kategoriAdi = kategori.Kategori_Adi;
                    kategoriDTO.kategoriID = kategori.Kategori_Id;
                    urunlerDTO.kategoriDTO = kategoriDTO;
                }
                urunlerDTO.Fiyat = urun.Fiyat;
                urunlerDTO.UrunID = urun.Urun_Id;
                urunlerDTO.UrunAdi = urun.Urun_Adi;
                urunlerDTO.UrunBirimAciklama = databaseMarketler.getBirimbyUrun(urun.Urun_Id);
                lstUrunlerDTO.Add(urunlerDTO);
            }
            return lstUrunlerDTO;
           
        }


        public List<UrunlerDTO> findUrunByMarketAndUrunAdi(string marketAdi, string urunAdi)
        {
            lstUrunler = new List<Urunler>();
            lstUrunlerDTO = new List<UrunlerDTO>();
            lstUrunler = databaseUrunler.findUrunByMarketAndUrunAdi(marketAdi, urunAdi);

            foreach (Urunler urun in lstUrunler)
            {
                urunlerDTO = new UrunlerDTO();
                urunlerDTO.Marka = urun.Marka;
                urunlerDTO.MarketID = urun.Market_Id;
                urunlerDTO.Fiyat = urun.Fiyat;
                KategoriDTO kategoriDTO = new KategoriDTO();
                Entity.Kategori kategori = databaseKategori.findKategoriByUrunID(urun.Urun_Id);

                if (kategori != null)
                {
                    kategoriDTO.kategoriAdi = kategori.Kategori_Adi;
                    kategoriDTO.kategoriID = kategori.Kategori_Id;
                    urunlerDTO.kategoriDTO = kategoriDTO;
                }

                urunlerDTO.UrunID = urun.Urun_Id;
                urunlerDTO.UrunAdi = urun.Urun_Adi;
                urunlerDTO.UrunBirimAciklama = databaseMarketler.getBirimbyUrun(urun.Urun_Id);
                lstUrunlerDTO.Add(urunlerDTO);
            }
            return lstUrunlerDTO;
        }

    }
}