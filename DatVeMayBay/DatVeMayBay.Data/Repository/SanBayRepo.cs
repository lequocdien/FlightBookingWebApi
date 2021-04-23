using DatVeMayBay.Data.Infrastructure;
using DatVeMayBay.Model;
using System.Collections.Generic;
using System.Linq;

namespace DatVeMayBay.Data.Repository
{
    public interface ISanBayRepo
    {
        List<SanBayModel> GetAll();

        SanBayModel Insert(SanBayModel x_objSanBay);

        SanBayModel Update(SanBayModel x_objSanBay);

        SanBayModel Delete(SanBayModel x_objSanBay);
    }

    public class SanBayRepo : RepositoryBase<SanBayModel>,  ISanBayRepo
    {
        public SanBayRepo(IDbFactory x_objDbFac) : base(x_objDbFac)
        {

        }       

        public List<SanBayModel> GetAll()
        {
            return m_objDbSet.ToList();
        }

        public SanBayModel Insert(SanBayModel x_objSanBay)
        {
            SanBayModel objSb = m_objDbSet.Add(x_objSanBay);
            m_objDbContext.SaveChanges();
            return objSb;
        }

        public SanBayModel Update(SanBayModel x_objSanBay)
        {
            SanBayModel objSb = m_objDbSet.FirstOrDefault(sb => sb.MaSanBay.Equals(x_objSanBay.MaSanBay));
            objSb.TenSanBay = x_objSanBay.TenSanBay;
            objSb.ThanhPho = x_objSanBay.ThanhPho;
            objSb.QuocGia = x_objSanBay.QuocGia;
            objSb.GhiChu = x_objSanBay.GhiChu;
            m_objDbContext.SaveChanges();
            return objSb;
        }

        public SanBayModel Delete(SanBayModel x_objSanBay)
        {
            SanBayModel objSb = m_objDbSet.FirstOrDefault(sb => sb.MaSanBay.Equals(x_objSanBay.MaSanBay));
            m_objDbSet.Remove(objSb);
            m_objDbContext.SaveChanges();
            return objSb;
        }
    }
}
