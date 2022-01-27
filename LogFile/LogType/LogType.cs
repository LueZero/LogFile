using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile.LogType
{
    class LogType<T>
    {
        protected string path;

        protected string content;

        protected string error;

        protected T log;

        public void logException()
        {
            throw new Exception(this.error);
        }
    }
}
