using DatVeMayBay.Data.Infrastructure;
using DatVeMayBay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Data.Repository
{
    public interface INhanVienRepo
    {
        IEnumerable<NhanVienModel> GetAll();
    }

    public class NhanVienRepo : RepositoryBase<NhanVienModel>, INhanVienRepo
    {
        public NhanVienRepo(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<NhanVienModel> GetAll()
        {
            return m_objDbSet.ToList();
        }
    }
}
