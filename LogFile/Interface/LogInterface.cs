using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile
{
    public interface LogInterface
    {
        public LogAbstract LogAbstract { get; set; }

        public void CreateLogFile(string path, string fileName, string content);

        public void DeleteLogFile(string path, string fileName);

        public string GetLogFile();

        public void ResetParameter();

        public FileStream ReadLogFile(string fullFilePath);
    }
}
