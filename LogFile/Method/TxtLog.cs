using LogFile.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile
{
    internal class TxtLog : LogInterface
    {
        public string logObject;

        public TxtLog()
        {

        }

        public bool check(string content)
        {
            try
            {
                this.logObject = content;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void save(string path, string fileName, string content)
        {
            string fullFilePath = path + fileName + ".txt";

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
            string fullFilePath = path + fileName + ".txt";

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
