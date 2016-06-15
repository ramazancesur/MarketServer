using System.Collections.Generic;
using test.ProjectDTO;

namespace test.RestWs.Dao.Kullanici
{
    public interface IKullaniciDao
    {
        List<KullaniciDTO> lstKullanici();

        KullaniciDTO getKullaniciByLogin(string EMail,string Sifre);

        KullaniciDTO getKullaniciByID(int id);
            
    }
}
