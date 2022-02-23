using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile
{
    public abstract class LogAbstract
    {
        public string Path { get; set; }

        public string FileName { get; set; }

        public string Content { get; set; }

        public string Error { get; set; }

        abstract public bool check();

        abstract public void create();

        abstract public void delete();

        public virtual FileStream read(string fullFilePath)
        {
            bool result = File.Exists(fullFilePath);

            if (!result)
            {
                throw new Exception(fullFilePath + " Not Found");
            }

            return File.OpenRead(fullFilePath);
        }

        abstract public string get();
    }
}
