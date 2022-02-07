using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile.Interfaces
{
    public interface LogInterface
    {
        public void set(string path, string fileName, string content = null);

        public bool check();

        public void save();

        public string get();

        public void delete();

        public void read(string fullFilePath);
    }
}
