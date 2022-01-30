using LogFile.Interfaces;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace LogFile.LogType
{
    internal class JsonLog : LogType<JObject>, LogInterface
    {
        public void set(string path,string fileName, string content = null)
        {
            this.path = path;
            this.fileName = fileName;
            this.content = content;
            this.fullFilePath = path + fileName + ".json";
        }

        public bool check()
        {
            try
            {
                this.log = JObject.Parse(this.content);

                return true;
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                this.error = ex.Message;

                return false;
            }
        }

        public string get()
        {
            return this.log.ToString();
        }

        public void save()
        {
            if(this.check())
            {
                try
                {
                    using (FileStream fs = File.Create(this.fullFilePath))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(this.log.ToString());
                       
                        fs.Write(info, 0, info.Length);
                    }
                }
                catch (Exception ex)
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
            bool result = File.Exists(this.fullFilePath);

            if (!result)
            {
                this.error = this.fullFilePath + " Not Found";
                logException();
            }

            File.Delete(this.fullFilePath);
        }
    }
}
