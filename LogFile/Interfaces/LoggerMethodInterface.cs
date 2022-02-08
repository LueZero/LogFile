using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile
{
    public interface LoggerMethodInterface
    {
        public string fullFilePath { get; set; }

        public string path { get; set; }

        public string fileName { get; set; }

        public string content { get; set; }

        public string error { get; set; }

        public void set(string path, string fileName, string content = null);

        public string get();
    }
}
