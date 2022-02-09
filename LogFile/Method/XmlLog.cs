using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogFile
{
    internal class XmlLog : LogAbstract
    {
        public XmlDocument logObject { get; set; }

        public XmlLog()
        {
        }

        public override bool check()
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

        public override void create()
        {
            string fullFilePath = path + fileName + ".xml";
            
            try
            {
                this.logObject.Save(fullFilePath);
            }
            catch (XmlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void delete()
        {
            string fullFilePath = path + fileName + ".xml";

            bool result = File.Exists(fullFilePath);

            if (!result)
            {
                throw new Exception(fullFilePath + " Not Found");
            }

            File.Delete(fullFilePath);
        }

        public override void read(string fullFilePath)
        {
         
        }

        public override string get()
        {
            return this.logObject.OuterXml;
        }
    }
}
