using LogFile.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile
{
    public class Logger<T> : LoggerMethodInterface
    {
        public string fullFilePath { get; set; }

        public string path { get; set; }

        public string fileName { get; set; }

        public string content { get; set; }

        public string error { get; set; }

        protected void logException()
        {
            throw new Exception(this.error);
        }

        public void set(string path, string fileName, string content = null)
        {
            this.path = path;
            this.fileName = fileName;
            this.content = content;
            this.fullFilePath = path + fileName + ".json";
        }

        public string get()
        {
            return this.log.ToString();
        }

        protected T log;
    }
}
