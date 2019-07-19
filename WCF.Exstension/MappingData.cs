using System;
using System.Linq;
using System.Reflection;

namespace WCF.Exstension
{
    public static class MappingData
    {
        public static T Maipping<T>(this object soruce)
        {
            T target = Activator.CreateInstance<T>();
            var targetProp= typeof(T).GetProperties();
            var SourceProp = soruce.GetType().GetProperties();

            foreach (var item in SourceProp)
            {
                object value = item.GetValue(soruce);
                PropertyInfo hp = targetProp.FirstOrDefault(x => x.Name.ToUpper() == item.Name.ToUpper());
                if (hp!=null)
                {
                    object result = item.GetValue(soruce);
                    hp.SetValue(target, result);
                }
               
            }

            return target;

        }
       
        public static string ClassName(this object obj)
        {

          return  obj.GetType().Name;
        }

       

    }
}

