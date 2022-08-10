using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile
{
    public abstract class Log
    {
        public string Path { get; set; }

        public string FileName { get; set; }

        public string Content { get; set; }

        public string Error { get; set; }

        abstract public bool Check();

        abstract public void Create();

        abstract public void Delete();

        public virtual FileStream Read(string fullFilePath)
        {
            bool result = File.Exists(fullFilePath);

            if (!result)
                throw new Exception(fullFilePath + " Not Found");

            return File.OpenRead(fullFilePath);
        }

        abstract public string Get();
    }
}
