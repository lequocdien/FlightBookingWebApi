using DatVeMayBay.Data.Infrastructure;
using DatVeMayBay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Data.Repository
{
    public interface IMayBayRepo
    {
        IEnumerable<MayBayModel> GetAll();

        MayBayModel Insert(MayBayModel x_objMayBay);

        MayBayModel Update(MayBayModel x_objMayBay);

        MayBayModel Delete(MayBayModel x_objMayBay);
    }

    public class MayBayRepo : RepositoryBase<MayBayModel>, IMayBayRepo
    {
        public MayBayRepo(IDbFactory dbFactory) : base(dbFactory)
        {

        }       

        public IEnumerable<MayBayModel> GetAll()
        {
            return m_objDbSet.ToList();
        }

        public MayBayModel Insert(MayBayModel x_objMayBay)
        {
            MayBayModel objMayBay = m_objDbSet.Add(x_objMayBay);
            m_objDbContext.SaveChanges();
            return objMayBay;
        }

        public MayBayModel Update(MayBayModel x_objMayBay)
        {
            MayBayModel objMayBay = m_objDbSet.FirstOrDefault(mb => mb.MaMayBay.Equals(x_objMayBay.MaMayBay));
            objMayBay.TenMayBay = x_objMayBay.TenMayBay;
            objMayBay.TongSoGhe = x_objMayBay.TongSoGhe;
            objMayBay.SoGheHang1 = x_objMayBay.SoGheHang1;
            objMayBay.SoGheHang2 = x_objMayBay.SoGheHang2;
            m_objDbContext.SaveChanges();
            return objMayBay;
        }

        public MayBayModel Delete(MayBayModel x_objMayBay)
        {
            MayBayModel objMayBay = m_objDbSet.FirstOrDefault(mb => mb.MaMayBay.Equals(x_objMayBay.MaMayBay));
            m_objDbSet.Remove(objMayBay);
            m_objDbContext.SaveChanges();
            return objMayBay;
        }
    }
}
