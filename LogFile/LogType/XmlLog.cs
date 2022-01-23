using LogFile.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogFile.LogType
{
    internal class XmlLog : LogType<XmlDocument>, LogInterface
    {
        public void set(string path, string content)
        {
            this.path = path;
            this.text = content;
        }

        public bool check()
        {
            return true;
        }

        public void save()
        {

        }

        public void delete()
        {

        }
    }
}
