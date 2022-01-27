using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile.Interfaces
{
    public interface LogInterface
    {
        public void set(string path, string content);

        public bool check();

        public void save();

        public string get();

        public void delete();
    }
}
