using DatVeMayBay.Data.Repository;
using DatVeMayBay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Service
{
    public interface IHoaDonService
    {
        IEnumerable<HoaDonModel> GetAll();

        HoaDonModel Insert(HoaDonModel x_objHoaDonModel);
    }
    public class HoaDonService : IHoaDonService
    {
        private IHoaDonRepo m_objHDRepo;
        public HoaDonService(IHoaDonRepo x_objHDRepo)
        {
            this.m_objHDRepo = x_objHDRepo;
        }
        public IEnumerable<HoaDonModel> GetAll()
        {
            return m_objHDRepo.GetAll();
        }

        public HoaDonModel Insert(HoaDonModel x_objHoaDonModel)
        {
            return m_objHDRepo.Insert(x_objHoaDonModel);
        }
    }
}
