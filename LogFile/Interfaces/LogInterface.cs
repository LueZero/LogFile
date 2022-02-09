using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile.Interfaces
{
    public interface LogInterface
    {
        public bool check(string content);

        public void save(string path, string fileName, string content);

        public void delete(string path, string fileName);

        public void read(string fullFilePath);

        public string get();
    }
}
