using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using WCF.Helpers.Tools;

namespace WCF.Helpers
{
    public class Tool
    {
        private const string _PATH = @"C:\Users\resid\source\repos\WCF\WCF.DTO\Data";
        private const string _CLASSPATH = @"C:\Users\resid\source\repos\WCF\WCF.DTO\Data\";
        private const string _INTERFACE = @"C:\Users\resid\source\repos\WCF\WCF.Repstory\Abstract\";
        private const string _REPOSTRCLASS = @"C:\Users\resid\source\repos\WCF\WCF.Repstory\Concreate\";
        public static bool Forcontinue(PropertyInfo item)
        {
            if (!item.PropertyType.FullName.Contains("System"))
                return true;
            else if (item.PropertyType.Name.Contains("IColl"))
            {
                return true;
            }
            else return false;
        }
        public static bool ForNullable(PropertyInfo item)
        {
            StringBuilder builders = new StringBuilder();
            if (item.PropertyType.Name.Contains("Nullable`1"))
            {
                return true;
            }
            return false;
        }
        public static string PropertyName(string Name)
        {

            if (Name.Contains("Int32"))
                return "int";
            else if (Name.Contains("String"))
                return "string";
            else if (Name.Contains("Boolean"))
                return "bool";
            else if (Name.Contains("Byte"))
                return "byte";
            else if (Name.Contains("Int16"))
                return "short";
            else if (Name.Contains("Single"))
                return "float";
            else if (Name.Contains("int?"))
                return "int?";
            else
                return Name;

        }
        public static void ClassCenerateDTO()
        {


            Folders.FolderExists(_CLASSPATH);
            Folders.FolderExists(_INTERFACE);
            Folders.FolderExists(_REPOSTRCLASS);
          
               string name= Folders.DllAssably(_PATH, "Entity");
                Assembly assembly = Assembly.LoadFile(name);
            
              
                foreach (var ite in assembly.ExportedTypes)
                {
                   var g= assembly.GetType(ite.FullName);
                   var o=  Activator.CreateInstance(g);
                   var tt=  Classes.CreateClasses(o);
                   var ii = Classes.CreateRepstoryInterface(o);
                   var rr = Classes.CreateRepstoryClass(o);
                if (tt.Count == 0)
                        continue;
              
               
              Save("DTO","",_CLASSPATH,tt["name"],tt["context"]);
            
            
              
              
                    Save("I", "Repostory", _INTERFACE, ii["name"], ii["context"]);
               
               
                    Save("", "Repostory", _REPOSTRCLASS, rr["name"], rr["context"]);

               
    


            }
             
               
           
          
          
        
        }
        public static void Save(string icon,string endIcon,string path, string name, string values)
        {

            FileStream outputFileStream = new FileStream(path + $"/{icon+name}{endIcon}.cs", FileMode.Append, FileAccess.Write);
            StreamWriter write = new StreamWriter(outputFileStream);
            write.Write(values);
            write.Close();
            outputFileStream.Close();
        }
       
        


    }
}
