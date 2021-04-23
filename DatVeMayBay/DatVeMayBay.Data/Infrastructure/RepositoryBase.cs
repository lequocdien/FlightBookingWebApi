using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Data.Infrastructure
{
    public class RepositoryBase<T> where T : class
    {
        protected DbContext m_objDbContext;
        protected readonly IDbSet<T> m_objDbSet;
        private IDbFactory m_objDbFac;

        public RepositoryBase(IDbFactory x_objDbFac)
        {
            this.m_objDbFac = x_objDbFac;
            m_objDbContext = x_objDbFac.Initialize();
            m_objDbSet = m_objDbContext.Set<T>();
        }
    }
}
