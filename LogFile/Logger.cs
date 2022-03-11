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
    public class Logger<T> : LogInterface<T> where T : class
    {
        public virtual LogAbstract<T> Log { get; set; }

        public Logger(LogTypeEnum logType)
        {
            initialization(logType);
        }

        public void initialization(LogTypeEnum logType)
        {
            switch (logType)
            {
                case LogTypeEnum.Json:
                    Log = (LogAbstract<T>)(object)new JsonLog();
                    break;
                case LogTypeEnum.Xml:
                    Log = (LogAbstract<T>)(object)new XmlLog();
                    break;
                case LogTypeEnum.Txt:
                    Log = (LogAbstract<T>)(object)new TxtLog();
                    break;
                default:
                    Log = null;
                    break;
            }
        }

        public virtual void CreateLogFile(string path, string fileName, string content)
        {
            Log.Path = path;
            Log.FileName = fileName;
            Log.Content = content;
            
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

        public virtual string GetLogFile()
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
