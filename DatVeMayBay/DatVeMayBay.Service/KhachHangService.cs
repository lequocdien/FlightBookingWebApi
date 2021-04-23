using DatVeMayBay.Data.Repository;
using DatVeMayBay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Service
{
    public interface IKhachHangService
    {
        IEnumerable<KhachHangModel> GetAll();
    }

    public class KhachHangService : IKhachHangService
    {
        private IKhachHangRepo m_objKHRepo;

        public KhachHangService(IKhachHangRepo x_objKHRepo)
        {
            this.m_objKHRepo = x_objKHRepo;
        }

        public IEnumerable<KhachHangModel> GetAll()
        {
            return m_objKHRepo.GetAll();
        }
    }
}
