using LogFile.Interfaces;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace LogFile
{
    internal class JsonLog : LogInterface
    {
        public JObject logObject;

        public JsonLog()
        {

        }

        public bool check(string content)
        {
            try
            {
                this.logObject = JObject.Parse(content);

                return true;
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void save(string path, string fileName, string content)
        {
            string fullFilePath = path + fileName + ".json";

            if (this.check(content))
            {
                try
                {
                    using (FileStream fs = File.Create(fullFilePath))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(this.logObject.ToString());
                       
                        fs.Write(info, 0, info.Length);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void delete(string path, string fileName)
        {
            string fullFilePath = path + fileName + ".json";

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
            return this.logObject.ToString();
        }
    }
}
