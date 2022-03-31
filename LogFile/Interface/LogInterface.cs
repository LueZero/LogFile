using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogFile
{
    public interface LogInterface
    {
        public Log Log { get; set; }

        public void SetLogFileContent(string content);

        public void CreateLogFile(string path, string fileName);

        public void DeleteLogFile(string path, string fileName);

        public string GetLogFileCotent();

        public void ResetParameter();

        public FileStream ReadLogFile(string fullFilePath);
    }
}
