using DatVeMayBay.Data.Infrastructure;
using DatVeMayBay.Model;
using System.Collections.Generic;
using System.Linq;

namespace DatVeMayBay.Data.Repository
{
    public interface ITaiKhoanRepo
    {
        IEnumerable<TaiKhoanModel> GetAll();
    }

    public class TaiKhoanRepo : RepositoryBase<TaiKhoanModel>, ITaiKhoanRepo
    {
        public TaiKhoanRepo(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<TaiKhoanModel> GetAll()
        {
            return m_objDbSet.ToList();
        }
    }
}
