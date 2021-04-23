using DatVeMayBay.Data.Repository;
using DatVeMayBay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Service
{
    public interface INhanVienService
    {
        IEnumerable<NhanVienModel> GetAll();
    }

    public class NhanVienService : INhanVienService
    {
        private INhanVienRepo m_objNVRepo;

        public NhanVienService(INhanVienRepo x_objNVRepo)
        {
            this.m_objNVRepo = x_objNVRepo;
        }

        public IEnumerable<NhanVienModel> GetAll()
        {
            return m_objNVRepo.GetAll();
        }
    }
}
