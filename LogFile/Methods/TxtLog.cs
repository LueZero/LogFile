using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile
{
    public class TxtLog : Log
    {
        private string _txt;

        public override bool Check()
        {
            try
            {
                _txt = Content;

                if (String.IsNullOrEmpty(_txt))
                    throw new Exception("content is empty");

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Create()
        {
            string fullFilePath = FullFilePath + ".txt";
          
            try
            {
                using (FileStream fs = File.Create(fullFilePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(_txt);

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
            return _txt;
        }
    }
}
