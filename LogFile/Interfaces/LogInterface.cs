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

        public void CreateLogFile();

        public void DeleteLogFile();

        public string GetLogFileCotent();

        public void ResetParameter();

        public FileStream ReadLogFile(string fullFilePath);
    }
}
