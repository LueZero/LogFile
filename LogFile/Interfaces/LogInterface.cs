using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile.Interfaces
{
    public interface LogInterface : LoggerMethodInterface
    {
        public bool check();

        public void save();

        public void delete();

        public void read(string fullFilePath);
    }
}
