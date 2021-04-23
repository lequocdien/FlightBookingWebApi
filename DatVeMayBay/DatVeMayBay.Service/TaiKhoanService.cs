using DatVeMayBay.Data.Repository;
using DatVeMayBay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Service
{
    public interface ITaiKhoanService
    {
        IEnumerable<TaiKhoanModel> GetAll();
    }

    public class TaiKhoanService : ITaiKhoanService
    {
        private ITaiKhoanRepo m_objTKRepo;

        public TaiKhoanService(ITaiKhoanRepo x_objTKRepo)
        {
            this.m_objTKRepo = x_objTKRepo;
        }
        public IEnumerable<TaiKhoanModel> GetAll()
        {
            return m_objTKRepo.GetAll();
        }
    }
}
