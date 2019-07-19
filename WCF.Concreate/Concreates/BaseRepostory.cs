using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WCF.Abstracts.Abstrac;
using WCF.Entity.Models;

namespace WCF.Concreate.Concreates
{
    public class BaseRepostory<T> : IBaseRepostory<T> where T : class
    {


        private NORTHWNDContext context;

        public NORTHWNDContext Context
        {
            get
            {

                context = context ?? new NORTHWNDContext();
                return context;
            }
            set { context = value; }
        }


        public bool Add(T entity)
        {
            Context.Set<T>().Add(entity);
            try
            {
                return Context.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }

       

        public bool Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            try
            {
                return Context.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }

        public List<T> Select()
        {
            return Context.Set<T>().ToList();
           
        }

        public bool Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            try
            {
                return Context.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }
    }
}
