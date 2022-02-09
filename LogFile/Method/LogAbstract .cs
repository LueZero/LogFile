using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile
{
    abstract class LogAbstract
    {
        public string path { get; set; }

        public string fileName { get; set; }

        public string content { get; set; }

        public string error { get; set; }

        abstract public bool check();

        abstract public void create();

        abstract public void delete();

        abstract public void read(string fullFilePath);

        abstract public string get();
    }
}
