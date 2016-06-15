using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using test.RestWs.Dao.Kategori;
using test.RestWs.ProjectDTO;

namespace test.RestWs.WcfWs.Kategori
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "KategoriServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select KategoriServices.svc or KategoriServices.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class KategoriServices : IKategoriServices
    {
        IKategoriDao kategoriDao = new KategoriDao();

        public List<KategoriDTO> allKategorilist()
        {
            return kategoriDao.lstKategori();
        }

    }
}
