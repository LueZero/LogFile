using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile
{
    public class TxtLog : LogAbstract<String>
    {
        public override bool Check()
        {
            try
            {
                this.DataFormat = Content;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Create()
        {
            string fullFilePath = Path + FileName + ".txt";
          
            try
            {
                using (FileStream fs = File.Create(fullFilePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(this.DataFormat.ToString());

                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public override void Delete()
        {
            string fullFilePath = Path + FileName + ".txt";

            bool result = File.Exists(fullFilePath);

            if (!result)
            {
                throw new Exception(fullFilePath + " Not Found");
            }

            File.Delete(fullFilePath);
        }

        public override string Get()
        {
            return this.DataFormat.ToString();
        }
    }
}
