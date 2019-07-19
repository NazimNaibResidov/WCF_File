using System.ServiceModel;
using WCF.DTO.Data;

namespace WCF.WCF
{

    [ServiceContract]
    public interface IUrunler:IService<DTOProduct>
    {
       
    }
}
