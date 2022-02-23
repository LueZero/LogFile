using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogFile
{
    public class XmlLog : LogAbstract
    {
        public XmlDocument Log { get; set; }

        public XmlLog()
        {
        }

        public override bool Check()
        {
            try
            {
                this.Log = new XmlDocument();

                this.Log.LoadXml(Content);

                return true;
            }
            catch (XmlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Create()
        {
            string fullFilePath = Path + FileName + ".xml";
            
            try
            {
                this.Log.Save(fullFilePath);
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
            return this.Log.OuterXml;
        }
    }
}
