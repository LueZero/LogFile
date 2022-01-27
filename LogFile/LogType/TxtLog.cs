using LogFile.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile.LogType
{
    internal class TxtLog :  LogType<String>, LogInterface
    {
        public void set(string path, string content)
        {
            this.path = path;
            this.content = content;
        }

        public bool check()
        {
            String content = this.content;
            this.log = content;
            return true;
        }

        public void save()
        {

        }

        public string get()
        {
            return this.log.ToString();
        }

        public void delete()
        {

        }
    }
}
