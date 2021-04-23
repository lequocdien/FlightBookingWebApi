using DatVeMayBay.Common.ExtenstionMethod;
using DatVeMayBay.Data.Context;
using DatVeMayBay.Data.Infrastructure;
using DatVeMayBay.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DatVeMayBay.Data.Repository
{
    public interface IChuyenBayRepo
    {
        IEnumerable<ChuyenBayModel> GetAll(bool x_bDangHoatDong);

        IEnumerable<ChuyenBayModel> GetAll(string x_strDiemDi, string x_strDiemDen, DateTime x_dtThoiGianDi, bool x_bDangHoatDong);

        ChuyenBayModel GetVe(string x_strMaCB, bool x_bDaDat);

        ChuyenBayModel Insert(ChuyenBayModel x_objChuyenBay);

        ChuyenBayModel Update(ChuyenBayModel x_objChuyenBay);
    }

    public class ChuyenBayRepo : RepositoryBase<ChuyenBayModel>, IChuyenBayRepo
    {
        public ChuyenBayRepo(IDbFactory dbFactory) : base(dbFactory)
        {

        }       

        public IEnumerable<ChuyenBayModel> GetAll(bool x_bDangHoatDong)
        {
            IEnumerable<ChuyenBayModel> lstCb = m_objDbSet
                    .Include(cb => cb.SanBayDi)
                    .Include(cb => cb.SanBayDen)
                    .Include(cb => cb.Ves)
                    .Include(cb => cb.MayBay)
                    .Where(cb => cb.ThoiGianDiDuKien >= DateTime.Now && cb.DangHoatDong == x_bDangHoatDong)
                    .ToList();

            foreach (var cb in lstCb)
            {
                foreach (var ve in cb.Ves.ToArray())
                {
                    if (ve.DaDat == true)
                    {
                        cb.Ves.Remove(ve);
                    }
                }
            }

            return lstCb;
        }

        public IEnumerable<ChuyenBayModel> GetAll(string x_strDiemDi, string x_strDiemDen, DateTime x_dtThoiGianDi, bool x_bDangHoatDong)
        {
            IEnumerable<ChuyenBayModel> lstCb = null;
            if (string.IsNullOrWhiteSpace(x_strDiemDi) == true && string.IsNullOrWhiteSpace(x_strDiemDen) == true)
            {
                lstCb = m_objDbSet.Where(cb =>
                    (cb.ThoiGianDiDuKien.Year == x_dtThoiGianDi.Year)
                    && (cb.ThoiGianDiDuKien.Month == x_dtThoiGianDi.Month)
                    && (cb.ThoiGianDiDuKien.Day == x_dtThoiGianDi.Day)
                    && cb.DangHoatDong == x_bDangHoatDong)
                    .Include(cb => cb.SanBayDi)
                    .Include(cb => cb.SanBayDen)
                    .Include(cb => cb.Ves)
                    .Include(cb => cb.MayBay)
                    .ToList();
            }
            else if (string.IsNullOrWhiteSpace(x_strDiemDi))
            {
                lstCb = m_objDbSet.Where(cb =>
                    (cb.ThoiGianDiDuKien.Year == x_dtThoiGianDi.Year)
                    && (cb.ThoiGianDiDuKien.Month == x_dtThoiGianDi.Month)
                    && (cb.ThoiGianDiDuKien.Day == x_dtThoiGianDi.Day)
                    && (cb.DangHoatDong == x_bDangHoatDong)
                    && (cb.MaSanBayDen.Equals(x_strDiemDen)))
                    .Include(cb => cb.SanBayDi)
                    .Include(cb => cb.SanBayDen)
                    .Include(cb => cb.Ves)
                    .Include(cb => cb.MayBay)
                    .ToList();
            }
            else if (string.IsNullOrWhiteSpace(x_strDiemDen))
            {
                lstCb = m_objDbSet.Where(cb =>
                    (cb.ThoiGianDiDuKien.Year == x_dtThoiGianDi.Year)
                    && (cb.ThoiGianDiDuKien.Month == x_dtThoiGianDi.Month)
                    && (cb.ThoiGianDiDuKien.Day == x_dtThoiGianDi.Day)
                    && (cb.DangHoatDong == x_bDangHoatDong)
                    && (cb.MaSanBayDi.Equals(x_strDiemDi)))
                    .Include(cb => cb.SanBayDi)
                    .Include(cb => cb.SanBayDen)
                    .Include(cb => cb.Ves)
                    .Include(cb => cb.MayBay)
                    .ToList();
            }
            else
            {
                lstCb = m_objDbSet.Where(cb =>
                    (cb.ThoiGianDiDuKien.Year == x_dtThoiGianDi.Year)
                    && (cb.ThoiGianDiDuKien.Month == x_dtThoiGianDi.Month)
                    && (cb.ThoiGianDiDuKien.Day == x_dtThoiGianDi.Day)
                    && (cb.DangHoatDong == x_bDangHoatDong)
                    && (cb.MaSanBayDi.Equals(x_strDiemDi))
                    && (cb.MaSanBayDen.Equals(x_strDiemDen)))
                    .Include(cb => cb.SanBayDi)
                    .Include(cb => cb.SanBayDen)
                    .Include(cb => cb.MayBay)
                    .Include(cb => cb.Ves)
                    .ToList();
            }


            foreach (var cb in lstCb)
            {
                foreach (var ve in cb.Ves.ToArray())
                {
                    if (ve.DaDat == true)
                    {
                        cb.Ves.Remove(ve);
                    }
                }
            }
            return lstCb;
        }

        public ChuyenBayModel GetVe(string x_strMaCB, bool x_bDaDat)
        {
            using (var db = new DatVeMayBayDbContext())
            {
                var query = db.ChuyenBays.Include(cb => cb.SanBayDi).Include(cb => cb.SanBayDen).Include(cb => cb.MayBay).Include(cb => cb.Ves).Where(cb => cb.MaChuyenBay.ToLower().Equals(x_strMaCB.ToLower().Trim()) && cb.DangHoatDong == true).FirstOrDefault();
                if(query == null)
                {
                    return null;
                }
                foreach (var v in query.Ves.ToArray())
                {
                    if (v.DaDat != x_bDaDat)
                    {
                        query.Ves.Remove(v);
                    }
                }
                return query;
            }
        }

        public ChuyenBayModel Insert(ChuyenBayModel x_objChuyenBay)
        {
            ChuyenBayModel objCb = m_objDbSet.Add(x_objChuyenBay);
            m_objDbContext.SaveChanges();
            objCb = m_objDbSet.Include(cb => cb.SanBayDi).Include(cb => cb.SanBayDen).Include(cb => cb.MayBay).SingleOrDefault(cb => cb.MaChuyenBay.Equals(x_objChuyenBay.MaChuyenBay));
            return objCb;
        }

        public ChuyenBayModel Update(ChuyenBayModel x_objChuyenBay)
        {
            ChuyenBayModel objCb = m_objDbSet.SingleOrDefault(cb => cb.MaChuyenBay.Equals(x_objChuyenBay.MaChuyenBay));
            objCb.MaSanBayDi = x_objChuyenBay.MaSanBayDi;
            objCb.MaSanBayDen = x_objChuyenBay.MaSanBayDen;
            objCb.ThoiGianDiDuKien = x_objChuyenBay.ThoiGianDiDuKien;
            objCb.ThoiGianDenDuKien = x_objChuyenBay.ThoiGianDenDuKien;
            objCb.MaMayBay = x_objChuyenBay.MaMayBay;
            objCb.GhiChu = x_objChuyenBay.GhiChu;
            objCb.DangHoatDong = x_objChuyenBay.DangHoatDong;
            m_objDbContext.SaveChanges();
            objCb = m_objDbSet.Include(cb => cb.SanBayDi).Include(cb => cb.SanBayDen).Include(cb => cb.MayBay).SingleOrDefault(cb => cb.MaChuyenBay.Equals(x_objChuyenBay.MaChuyenBay));
            return objCb;
        }
    }
}
