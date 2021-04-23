using DatVeMayBay.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Data.Infrastructure
{
    public class SQLFactoryImpl : IDbFactory
    {
        public DbContext DbContext { get; set; }

        public DbContext Initialize()
        {
            if (DbContext == null)
            {
                DbContext = new DatVeMayBayDbContext();
                return DbContext;
            }
            else
            {
                return DbContext;
            }
        }
    }
}
