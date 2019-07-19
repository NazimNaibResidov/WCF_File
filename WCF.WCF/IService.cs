using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF.WCF
{
    [ServiceContract]
   public interface IService<DTO> where DTO:class
    {
        [OperationContract]
        bool Add(DTO entity);
        [OperationContract]
        bool Remove(DTO entity);
        [OperationContract]
        bool Update(DTO entity);
        [OperationContract]
        List<DTO> Select();
    }
}
