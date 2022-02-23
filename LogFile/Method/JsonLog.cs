using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace LogFile
{
    public class JsonLog : LogAbstract
    {
        public JObject Log { get; set; }

        public JsonLog()
        {
        }

        public override bool Check()
        {
            try
            {
                this.Log = JObject.Parse(Content);

                return true;
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public override void Create()
        {
            string fullFilePath = Path + FileName + ".json";

            try
            {
                using (FileStream fs = File.Create(fullFilePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(this.Log.ToString());
                       
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
            string fullFilePath = Path + FileName + ".json";

            bool result = File.Exists(fullFilePath);

            if (!result)
            {
                throw new Exception(fullFilePath + " Not Found");
            }

            File.Delete(fullFilePath);
        }

        public override string Get()
        {
            return this.Log.ToString();
        }
    }
}
