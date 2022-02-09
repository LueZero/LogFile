using LogFile.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogFile
{
    internal class XmlLog : LogInterface
    {
        public XmlDocument logObject;

        public XmlLog()
        {

        }

        public bool check(string content)
        {
            try
            {
                this.logObject = new XmlDocument();

                this.logObject.LoadXml(content);

                return true;
            }
            catch (XmlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void save(string path, string fileName, string content)
        {
            string fullFilePath = path + fileName + ".xml";

            if (this.check(content))
            {
                try
                {
                    this.logObject.Save(fullFilePath);
                }
                catch (XmlException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void delete(string path, string fileName)
        {
            string fullFilePath = path + fileName + ".xml";

            bool result = File.Exists(fullFilePath);

            if (!result)
            {
                throw new Exception(fullFilePath + " Not Found");
            }

            File.Delete(fullFilePath);
        }

        public void read(string fullFilePath)
        {
         
        }

        public string get()
        {
            return this.logObject.OuterXml;
        }
    }
}
