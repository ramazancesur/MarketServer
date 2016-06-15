using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.RestWs.ProjectDTO;
using test.Entity;
namespace test.RestWs.Dao.Kategori
{
    public class KategoriDao : IKategoriDao
    {
        public KategoriDao()
        {
            init();

        }
        DatabaseKategori databaseKategori;
        KategoriDTO kategoriDTO;
       Entity.Kategori kategori = new Entity.Kategori();
        private void init()
        {
            databaseKategori = new DatabaseKategori();
        }
        public List<KategoriDTO> lstKategori()
        {
            List<KategoriDTO> lstKategoriDTO = new List<KategoriDTO>();
            List<Entity.Kategori> kategoriList = databaseKategori.allKategoriList();
            foreach (var item in kategoriList)
            {
                kategoriDTO = new KategoriDTO();
                kategoriDTO.kategoriAdi = item.Kategori_Adi;
                kategoriDTO.kategoriID = item.Kategori_Id;
                lstKategoriDTO.Add(kategoriDTO);
            }
            return lstKategoriDTO;           
        }

        
    }
}