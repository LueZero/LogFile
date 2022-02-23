using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile
{
    public class Log : LogInterface
    {
        public virtual LogAbstract LogAbstract { get; set; }

        public Log(LogTypeEnume logType)
        {
            initialization(logType);
        }

        public void initialization(LogTypeEnume logType)
        {
            switch (logType)
            {
                case LogTypeEnume.Json:
                    LogAbstract = new JsonLog();
                    break;
                case LogTypeEnume.Xml:
                    LogAbstract = new XmlLog();
                    break;
                case LogTypeEnume.Txt:
                    LogAbstract = new TxtLog();
                    break;
                default:
                    LogAbstract = null;
                    break;
            }
        }

        public virtual void CreateLogFile(string path, string fileName, string content)
        {
            LogAbstract.Path = path;
            LogAbstract.FileName = fileName;
            LogAbstract.Content = content;
            
            if (LogAbstract.Check())
            {
                this.LogAbstract.Create();
            }
        }

        public virtual void DeleteLogFile(string path, string fileName)
        {
            LogAbstract.Path = path;
            LogAbstract.FileName = fileName;

            this.LogAbstract.Delete();
        }

        public virtual string GetLogFile()
        {
            return this.LogAbstract.Get();
        }

        public virtual FileStream ReadLogFile(string fullFilePath)
        {
            return this.LogAbstract.Read(fullFilePath);
        }

        public void ResetParameter()
        {
            LogAbstract.Path = "";
            LogAbstract.FileName = "";
            LogAbstract.Content = "";
        }
    }
}
