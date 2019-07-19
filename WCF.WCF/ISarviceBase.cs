
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.Concreate.Concreates;
using WCF.Exstension;

namespace WCF.WCF
{
    public class SarviceBase<Rep, Entity, DTO> : IService<DTO>
         where DTO : class
         where Entity:class
         where Rep: BaseRepostory<Entity>

    {
        private Rep reposotry;

        public Rep Reposotry
        {
            get {

                reposotry = reposotry ?? Activator.CreateInstance<Rep>();
              

                return reposotry; }
            set { reposotry = value; }
        }

        public bool Add(DTO entity)
        {
           
           return Reposotry.Add(entity.Maipping<Entity>());
        }

        public bool Remove(DTO entity)
        {
            throw new NotImplementedException();
        }

        public List<DTO> Select()
        {
            return Reposotry.Select().Select(x => x.Maipping<DTO>()).ToList();
        }

        public bool Update(DTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
