using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile
{
    public class TxtLog : LogAbstract
    {
        public string logType { get; set; }

        public TxtLog()
        {
        }

        public override bool check()
        {
            try
            {
                this.logType = content;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void create()
        {
            string fullFilePath = path + fileName + ".txt";
          
            try
            {
                using (FileStream fs = File.Create(fullFilePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(this.logType.ToString());

                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public override void delete()
        {
            string fullFilePath = path + fileName + ".txt";

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
            return this.logType.ToString();
        }
    }
}
