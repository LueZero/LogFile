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
        public void set(string path, string fileName, string content)
        {
            this.path = path;
            this.fileName = fileName;
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
            if (this.check())
            {
                try
                {
                    this.log.Save(path+fileName+".xml");
                }
                catch (XmlException ex)
                {
                    this.error = ex.Message;
                    logException();
                }
            }
            else
            {
                logException();
            }
        }

        public void delete()
        {

        }
    }
}
