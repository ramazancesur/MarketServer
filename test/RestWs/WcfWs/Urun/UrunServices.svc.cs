using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using test.ProjectDTO;
using test.RestWs.Dao.Urun;

namespace test.RestWs.WsfWs.Urun
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Urun" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Urun.svc or Urun.svc.cs at the Solution Explorer and start debugging.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Urun : IUrunServices
    {
        IUrunDao urunDao = new UrunDao();
        public List<UrunlerDTO> allUrunler()
        {
          return urunDao.allUrunler();
        }

        public List<UrunlerDTO> findbyEcuz(string urunName)
        {
            return urunDao.findbyEcuz(urunName);
        }
        //Tools -> Options -> Projects and Solutions -> Web Projects 
        //-> Use the 64 bit version of IIS Express for web sites and projects
        public List<UrunlerDTO> findByMarka(string markaAdi)
        {
            return urunDao.findByMarka(markaAdi);
        }

        public UrunlerDTO findbyUrunID(string id)
        {
            UrunlerDTO urunlerDTO = urunDao.findbyUrunID(Convert.ToInt32(id));
            return urunlerDTO;
        }

        public List<UrunlerDTO> findUrunByKategori(string kategoriID)
        {
            return urunDao.findUrunByKategori(kategoriID);
        }

        public List<UrunlerDTO> findUrunByKategoriandMarket(string kategoriID, string marketID)
        {
            return urunDao.findUrunByKategoriandMarket(kategoriID, marketID);
        }

        public List<UrunlerDTO> findUrunbyName(string urunName)
        {
            return urunDao.findUrunbyName(urunName);
        }

        public List<UrunlerDTO> findUrunByUrunAdiandMarket(string marketAdi, string urunAdi)
        {
            return urunDao.findUrunByMarketAndUrunAdi(marketAdi,urunAdi);
        }
    }
}
