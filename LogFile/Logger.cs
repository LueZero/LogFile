using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogFile
{
    public class Logger : LogInterface
    {
        public virtual Log Log { get; set; }

        public Logger(LogTypeEnum logType)
        {
            Initialization(logType);
        }

        public void Initialization(LogTypeEnum logType)
        {
            switch (logType)
            {
                case LogTypeEnum.Json:
                    Log = new JsonLog();
                    break;
                case LogTypeEnum.Xml:
                    Log = new XmlLog();
                    break;
                case LogTypeEnum.Txt:
                    Log = new TxtLog();
                    break;
                default:
                    Log = null;
                    break;
            }
        }

        public virtual void SetLogFileContent(string content)
        {
            Log.Content = content;
        }

        public virtual void CreateLogFile(string path, string fileName)
        {
            Log.Path = path;
            Log.FileName = fileName;
            
            if (Log.Check())
            {
                this.Log.Create();
            }
        }

        public virtual void DeleteLogFile(string path, string fileName)
        {
            Log.Path = path;
            Log.FileName = fileName;

            this.Log.Delete();
        }

        public virtual string GetLogFileCotent()
        {
            return this.Log.Get();
        }

        public virtual FileStream ReadLogFile(string fullFilePath)
        {
            return this.Log.Read(fullFilePath);
        }

        public void ResetParameter()
        {
            Log.Path = "";
            Log.FileName = "";
            Log.Content = "";
        }
    }
}
