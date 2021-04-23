using DatVeMayBay.Data.Repository;
using DatVeMayBay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Service
{
    public interface IMayBayService
    {
        IEnumerable<MayBayModel> GetAll();

        MayBayModel Insert(MayBayModel x_objMayBay);

        MayBayModel Update(MayBayModel x_objMayBay);

        MayBayModel Delete(MayBayModel x_objMayBay);
    }

    public class MayBayService : IMayBayService
    {
        private IMayBayRepo m_objMBRepo;
        public MayBayService(IMayBayRepo x_objMBRepo)
        {
            this.m_objMBRepo = x_objMBRepo;
        }

        public IEnumerable<MayBayModel> GetAll()
        {
            return m_objMBRepo.GetAll();
        }

        public MayBayModel Insert(MayBayModel x_objMayBay)
        {
            return m_objMBRepo.Insert(x_objMayBay);
        }

        public MayBayModel Update(MayBayModel x_objMayBay)
        {
            return m_objMBRepo.Update(x_objMayBay);
        }

        public MayBayModel Delete(MayBayModel x_objMayBay)
        {
            return m_objMBRepo.Delete(x_objMayBay);
        }
    }
}
