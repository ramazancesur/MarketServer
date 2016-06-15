using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using test.ProjectDTO;
using test.RestWs.Dao;
using test.RestWs.Dao.Kullanici;

namespace test.RestWs.WcfWs.Kullanici
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "KullaniciServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select KullaniciServices.svc or KullaniciServices.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class KullaniciServices : IKullaniciServices
    {
        IKullaniciDao kullaniciDao = new KullaniciDao();
        KullaniciDTO kullanici;
        public KullaniciDTO getKullaniciByID(string id)
        {
            kullanici = new KullaniciDTO();
            kullanici = kullaniciDao.getKullaniciByID(Convert.ToInt32(id));
            return kullanici;
        }

        public KullaniciDTO getKullaniciByLogin(string EMail, string Sifre)
        {
            kullanici = new KullaniciDTO();
            kullanici = kullaniciDao.getKullaniciByLogin(EMail, Sifre);
            return kullanici;
        }

        public List<KullaniciDTO> lstKullanici()
        {
            List<KullaniciDTO> lstKullanici = kullaniciDao.lstKullanici();
            return lstKullanici;
        }
    }
}
