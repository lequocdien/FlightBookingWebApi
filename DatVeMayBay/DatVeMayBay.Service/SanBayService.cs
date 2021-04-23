using DatVeMayBay.Data.Repository;
using DatVeMayBay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Service
{
    public interface ISanBayService
    {
        IEnumerable<SanBayModel> GetAll();

        SanBayModel Insert(SanBayModel x_objSanBay);

        SanBayModel Update(SanBayModel x_objSanBay);

        SanBayModel Delete(SanBayModel x_objSanBay);
    }

    public class SanBayService : ISanBayService
    {
        private ISanBayRepo m_objSanBayRepo;

        public SanBayService(ISanBayRepo x_objSanBayRepo)
        {
            this.m_objSanBayRepo = x_objSanBayRepo;
        }

        public IEnumerable<SanBayModel> GetAll()
        {
            return m_objSanBayRepo.GetAll();
        }

        public SanBayModel Insert(SanBayModel x_objSanBay)
        {
            return m_objSanBayRepo.Insert(x_objSanBay);
        }

        public SanBayModel Update(SanBayModel x_objSanBay)
        {
            return m_objSanBayRepo.Update(x_objSanBay);
        }

        public SanBayModel Delete(SanBayModel x_objSanBay)
        {
            return m_objSanBayRepo.Delete(x_objSanBay);
        }
    }
}
