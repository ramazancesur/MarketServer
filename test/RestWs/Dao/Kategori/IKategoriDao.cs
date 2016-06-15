using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using test.RestWs.ProjectDTO;

namespace test.RestWs.Dao.Kategori
{
    interface IKategoriDao
    {
        List<KategoriDTO> lstKategori();
    }
}
