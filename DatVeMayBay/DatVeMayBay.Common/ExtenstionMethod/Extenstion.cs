using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatVeMayBay.Common.ExtenstionMethod
{
    public static class Extenstion
    {
        public static TDes Map<TSource, TDes>(this TSource src, Func<IMapper> func) where TSource : class
        {
            IMapper objMapper = func.Invoke();
            return objMapper.Map<TSource, TDes>(src);
        }
    }
}
