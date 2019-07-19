using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Helpers.Tools
{
  public  class Folders
    {
        private const string _rootPath = @"C:\Users\resid\source\repos\WCF";
        private const string _SOLITION = "WCF.";
        private const string _DLL = ".dll";
        public static void FolderExists(string path)
        {
           if (Directory.Exists(path))
            {

                Directory.Delete(path,true);
                Directory.CreateDirectory(path);
            }
            else
            {
                Directory.CreateDirectory(path);
              
            }
           
        }
        public static string   DllAssably(string Createpath,string dllName)
        {
            FolderExists(Createpath);
            DirectoryInfo info = new DirectoryInfo(_rootPath);
            return info.GetFiles($"{_SOLITION}{dllName}{_DLL}", SearchOption.AllDirectories)[0].FullName;
        }
        public static bool FileExist(string path)
        {
            bool data = false;
            data= File.Exists(path);
            return data;
           
        }
        public static string  [] GetAllFile(string path)
        {
           return Directory.GetFiles(path);
           
           
        }
        public static string FileName(string path)
        {
           
            string name = string.Empty;
            var data = Directory.GetFiles(path);
            foreach (var item in data)
            {
              name=  Path.GetFileName(item);
            }
            return name;
        }
    }
}
