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
            this.content = content;
        }

        public bool check()
        {
            try
            {
                this.log = new XmlDocument();

                this.log.LoadXml(this.content);

                return true;
            }
            catch (XmlException ex)
            {
                this.error = ex.Message;
          
                return false;
            }
        }

        public string get()
        {
            return this.log.OuterXml;
        }

        public void save()
        {
            try
            {
                this.log.Save(this.path);
            }
            catch (XmlException ex)
            {
                this.error = ex.Message;
                logException();
            }
        }

        public void delete()
        {

        }
    }
}
