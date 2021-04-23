using DatVeMayBay.Data.Repository;
using DatVeMayBay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Service
{
    public interface IChuyenBayService
    {
        IEnumerable<ChuyenBayModel> GetAll(bool x_bDangHoatDong);

        IEnumerable<ChuyenBayModel> GetAll(string x_strDiemDi, string x_strDiemDen, DateTime x_dtThoiGianDi, bool x_bDangHoatDong);

        ChuyenBayModel GetVe(string x_strMaCB, bool x_bDatDat);

        ChuyenBayModel Insert(ChuyenBayModel x_objChuyenBay);

        ChuyenBayModel Update(ChuyenBayModel x_objChuyenBay);
    }
    public class ChuyenBayService : IChuyenBayService
    {
        private IChuyenBayRepo m_objChuyenBayRepo;
        public ChuyenBayService(IChuyenBayRepo x_objCBRepo)
        {
            this.m_objChuyenBayRepo = x_objCBRepo;
        }

        public IEnumerable<ChuyenBayModel> GetAll(bool x_bDangHoatDong)
        {
            return m_objChuyenBayRepo.GetAll(x_bDangHoatDong);
        }

        public IEnumerable<ChuyenBayModel> GetAll(string x_strDiemDi, string x_strDiemDen, DateTime x_dtThoiGianDi, bool x_bDangHoatDong)
        {
            return m_objChuyenBayRepo.GetAll(x_strDiemDi, x_strDiemDen, x_dtThoiGianDi, x_bDangHoatDong);
        }

        public ChuyenBayModel GetVe(string x_strMaCB, bool x_bDatDat)
        {
            var objCb = m_objChuyenBayRepo.GetVe(x_strMaCB, x_bDatDat);
            return objCb;
        }

        public ChuyenBayModel Insert(ChuyenBayModel x_objChuyenBay)
        {
            return m_objChuyenBayRepo.Insert(x_objChuyenBay);
        }

        public ChuyenBayModel Update(ChuyenBayModel x_objChuyenBay)
        {
            return m_objChuyenBayRepo.Update(x_objChuyenBay);
        }
    }
}
