using DatVeMayBay.Data.Context;
using DatVeMayBay.Data.Infrastructure;
using DatVeMayBay.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Data.Repository
{
    public interface IVeRepo
    {
        IEnumerable<VeModel> GetAll();

        VeModel GetById(string x_strMaVe);

        VeModel Insert(VeModel x_objVe);

        VeModel Update(VeModel x_objVe);

        VeModel UpdateStatus(VeModel x_objVe);
    }

    public class VeRepo : RepositoryBase<VeModel>, IVeRepo
    {
        public VeRepo(IDbFactory dbFactory) : base(dbFactory)
        {

        }
        public IEnumerable<VeModel> GetAll()
        {
            return m_objDbSet.Include(i => i.ChuyenBay.MayBay).Where(v => v.DaDat == false).ToList();
        }

        public VeModel GetById(string x_strMaVe)
        {
            return m_objDbSet.Where(v => v.MaVe.Equals(x_strMaVe)).Include(v => v.ChuyenBay.MayBay).Include(v => v.HoaDon.KhachHang).Include(v => v.HoaDon.NhanVien).Include(v => v.ChuyenBay.SanBayDi).Include(v => v.ChuyenBay.SanBayDen).SingleOrDefault();
        }

        public VeModel Insert(VeModel x_objVe)
        {
            VeModel objVe = m_objDbSet.Add(x_objVe);
            m_objDbContext.SaveChanges();
            return m_objDbSet.Include(v => v.ChuyenBay.SanBayDen).Include(v => v.ChuyenBay.SanBayDi).Include(v => v.ChuyenBay.MayBay).SingleOrDefault(v => v.MaVe.Equals(x_objVe.MaVe));
        }

        public VeModel Update(VeModel x_objVe)
        {
            VeModel objVe = m_objDbSet.SingleOrDefault(v => v.MaVe.Equals(x_objVe.MaVe));
            if(objVe == null)
            {
                return null;
            }
            objVe.SoGhe = x_objVe.SoGhe;
            objVe.GiaVe = x_objVe.GiaVe;
            objVe.MaChuyenBay = x_objVe.MaChuyenBay;
            m_objDbContext.SaveChanges();
            return m_objDbSet.Include(v => v.ChuyenBay.SanBayDen).Include(v => v.ChuyenBay.SanBayDi).Include(v => v.ChuyenBay.MayBay).SingleOrDefault(v => v.MaVe.Equals(x_objVe.MaVe));
        }

        public VeModel UpdateStatus(VeModel x_objVe)
        {
            using(var db = new DatVeMayBayDbContext())
            {
                VeModel objVe = db.Ves.SingleOrDefault(v => v.MaVe.Equals(x_objVe.MaVe));
                if (objVe == null)
                {
                    return null;
                }
                objVe.ThoiGianDat = x_objVe.ThoiGianDat;
                objVe.DaDat = x_objVe.DaDat;
                objVe.MaHoaDon = x_objVe.MaHoaDon;
                db.SaveChanges();
                return db.Ves.Include(v => v.ChuyenBay).Include(v => v.HoaDon).Include(v => v.ChuyenBay.SanBayDi).Include(v => v.ChuyenBay.SanBayDen).Include(v => v.HoaDon.KhachHang).Include(v => v.ChuyenBay.MayBay).SingleOrDefault(v => v.MaVe.Equals(x_objVe.MaVe)); ;
            }
        }
    }
}
