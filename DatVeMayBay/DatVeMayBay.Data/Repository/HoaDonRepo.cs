using DatVeMayBay.Data.Infrastructure;
using DatVeMayBay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Data.Repository
{
    public interface IHoaDonRepo
    {
        IEnumerable<HoaDonModel> GetAll();

        HoaDonModel Insert(HoaDonModel x_objHoaDonModel);
    }
    public class HoaDonRepo : RepositoryBase<HoaDonModel>, IHoaDonRepo
    {
        public HoaDonRepo(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<HoaDonModel> GetAll()
        {
            return m_objDbSet.ToList();
        }

        public HoaDonModel Insert(HoaDonModel x_objHoaDonModel)
        {
            HoaDonModel hoaDonModel = m_objDbSet.Add(x_objHoaDonModel);
            m_objDbContext.SaveChanges();
            return hoaDonModel;
        }
    }
}
