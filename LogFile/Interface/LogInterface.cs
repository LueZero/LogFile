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
        public LogAbstract logAbstract { get; set; }

        public void createLogFile(string path, string fileName, string content);

        public void deleteLogFile(string path, string fileName);

        public string getLogFile();

        public void resetParameter();

        public FileStream readLogFile();
    }
}
