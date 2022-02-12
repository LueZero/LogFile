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
        public string path { get; set; }

        public string fileName { get; set; }

        public string content { get; set; }

        public string error { get; set; }

        abstract public bool check();

        abstract public void create();

        abstract public void delete();

        public FileStream read(string fullFilePath)
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
