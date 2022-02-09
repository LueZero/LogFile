﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace LogFile
{
    internal class JsonLog : LogAbstract
    {
        public JObject logObject { get; set; }

        public JsonLog()
        {
        }

        public override bool check()
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


        public override void create()
        {
            string fullFilePath = path + fileName + ".json";

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

        public override void delete()
        {
            string fullFilePath = path + fileName + ".json";

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
            return this.logObject.ToString();
        }
    }
}