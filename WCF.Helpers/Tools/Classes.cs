using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Helpers.Tools
{
  public  class Classes
    {
        private const string _SYSTEM= "using System;";
        private const string _NAMESPACE = "namespace";
        private const string _FBREAKET = " { ";
        private const string _EBREAKET = " } ";
        private const string _NL = "\n";

        public static Dictionary<string, string> CreateClasses(object type)
        {

            Dictionary<string, string> str = new Dictionary<string, string>();
            StringBuilder builders = new StringBuilder();

       builders.Append($"{_SYSTEM} {_NL} {_NL} {_NAMESPACE} WCF.DTO.Data {_NL} {_FBREAKET} {_NL}");
            builders.Append(" public class ");
            if (!type.GetType().Name.Contains("Context"))
            {

                builders.Append("DTO" + type.GetType().Name.ToString());




                builders.Append($"{_NL}{_FBREAKET}{_NL}");
                var data = type.GetType().GetProperties();
                foreach (var item in data)
                {
                    if (Tool.Forcontinue(item))
                    {
                        continue;
                    }

                    builders.Append("        public ");



                    if (Tool.ForNullable(item))
                    {
                        var t = Nullable.GetUnderlyingType((item.PropertyType));
                        builders.Append(Tool.PropertyName(t.Name) + "? ");
                    }
                    else
                    {
                        builders.Append(Tool.PropertyName(item.PropertyType.Name) + " ");
                    }


                    builders.Append(item.Name + $"{_FBREAKET} get; set; {_EBREAKET}{_NL}");
                }

                builders.Append($"{_NL}{_EBREAKET}");
                builders.Append($"{_NL}{_NL}{_EBREAKET}");
                str.Add("context", builders.ToString());
                str.Add("name", type.GetType().Name.ToString());
                return str;
            }
            else
            {

                var data = new Dictionary<string, string>();
                return data;
            }



        }
        public static Dictionary<string, string> CreateRepstoryInterface(object data)
        {
            Dictionary<string, string> keys = new Dictionary<string, string>();
          
            string Classname = data.GetType().Name;
            StringBuilder builders = new StringBuilder();
            builders.Append("using WCF.Abstracts.Abstrac;");
            builders.Append("\n");
            builders.Append("using WCF.Entity.Models;");
            builders.Append("\n\n");
            builders.Append("namespace WCF.Repstory.Abstract{\n\n");
            builders.Append($" public interface I{Classname}Repostory:");
            builders.Append("IBaseRepostory");
            builders.Append("<" + Classname + ">");
            builders.Append("{");
            builders.Append("}\n}");
            keys.Add("name", Classname.ToString());
            keys.Add("context", builders.ToString());




            return keys;
        }
        public static Dictionary<string, string> CreateRepstoryClass(object data)
        {
            Dictionary<string, string> keys = new Dictionary<string, string>();

            string Classname = data.GetType().Name;
            StringBuilder builders = new StringBuilder();
            builders.Append("using WCF.Concreate.Concreates;\n");
            builders.Append("using WCF.Entity.Models;\n");
            builders.Append("using WCF.Repstory.Abstract;\n");
            builders.Append("namespace WCF.Repstory.Concreate{\n");
            builders.Append($"public class {Classname}Repsotory:");
            builders.Append("BaseRepostory<" + Classname + ">,");
            builders.Append($"I{Classname}Repostory " + "{}}");
            keys.Add("name", Classname.ToString());
            keys.Add("context", builders.ToString());




            return keys;
        }

    }
}
