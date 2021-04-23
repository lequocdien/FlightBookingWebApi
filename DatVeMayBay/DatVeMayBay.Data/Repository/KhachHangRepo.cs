using DatVeMayBay.Data.Infrastructure;
using DatVeMayBay.Model;
using System.Collections.Generic;
using System.Linq;

namespace DatVeMayBay.Data.Repository
{
    public interface IKhachHangRepo
    {
        IEnumerable<KhachHangModel> GetAll();
    }
    public class KhachHangRepo : RepositoryBase<KhachHangModel>, IKhachHangRepo
    {
        public KhachHangRepo(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<KhachHangModel> GetAll()
        {
            return m_objDbSet.ToList();
        }
    }
}
