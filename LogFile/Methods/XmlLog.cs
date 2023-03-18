using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LogFile
{
    public class XmlLog : Log
    {
        private XmlDocument _xml;

        public override bool Check()
        {
            try
            { 
                _xml = new XmlDocument();

                _xml.LoadXml(this.Content);

                return true;
            }
            catch (XmlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Create()
        {
            string fullFilePath = FullFilePath + ".xml";
            
            try
            {
                _xml.Save(fullFilePath);
            }
            catch (XmlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Delete()
        {
            string fullFilePath = Path + FileName + ".xml";

            bool result = File.Exists(fullFilePath);

            if (!result)
            {
                throw new Exception(fullFilePath + " Not Found");
            }

            File.Delete(fullFilePath);
        }
             
        public override string Get()
        {
            return _xml.OuterXml;
        }
    }
}
