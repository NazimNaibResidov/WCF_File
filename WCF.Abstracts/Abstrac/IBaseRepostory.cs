using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Abstracts.Abstrac
{
   public interface IBaseRepostory<T> where T:class
    {
        bool Add(T entity);
        bool Remove(T entity);
        bool Update(T entity);
        List<T> Select();

    }
}
