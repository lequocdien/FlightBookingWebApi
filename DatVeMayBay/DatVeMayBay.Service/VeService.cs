using DatVeMayBay.Data.Repository;
using DatVeMayBay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Service
{
    public interface IVeService
    {
        IEnumerable<VeModel> GetAll();

        VeModel GetById(string x_strMaVe);

        VeModel LookUpTicket(string x_strMaVe, string x_strEmail);

        VeModel Insert(VeModel x_objVe);

        VeModel Update(VeModel x_objVe);

        VeModel UpdateStatus(VeModel x_objVe);
    }

    public class VeService : IVeService
    {
        private IVeRepo m_objVeRepo;

        public VeService(IVeRepo x_objVeRepo)
        {
            this.m_objVeRepo = x_objVeRepo;
        }

        public IEnumerable<VeModel> GetAll()
        {
            return m_objVeRepo.GetAll();
        }

        public VeModel GetById(string x_strMaVe)
        {
            return m_objVeRepo.GetById(x_strMaVe);
        }

        public VeModel LookUpTicket(string x_strMaVe, string x_strEmail)
        {
            var objVe = m_objVeRepo.GetById(x_strMaVe);
            if (objVe != null && objVe.HoaDon.KhachHang.Email.Equals(x_strEmail))
            {
                return objVe;
            }
            return null;
        }

        public VeModel Insert(VeModel x_objVe)
        {
            return m_objVeRepo.Insert(x_objVe);
        }

        public VeModel Update(VeModel x_objVe)
        {
            return m_objVeRepo.Update(x_objVe);
        }

        public VeModel UpdateStatus(VeModel x_objVe)
        {
            return m_objVeRepo.UpdateStatus(x_objVe);
        }
    }
}
