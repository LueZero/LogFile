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
        public virtual LogAbstract logAbstract { get; set; }

        public Log(LogTypeEnume logType)
        {
            initialization(logType);
        }

        public void initialization(LogTypeEnume logType)
        {
            switch (logType)
            {
                case LogTypeEnume.json:
                    logAbstract = new JsonLog();
                    break;
                case LogTypeEnume.xml:
                    logAbstract = new XmlLog();
                    break;
                case LogTypeEnume.txt:
                    logAbstract = new TxtLog();
                    break;
                default:
                    logAbstract = null;
                    break;
            }
        }

        public virtual void createLogFile(string path, string fileName, string content)
        {
            logAbstract.path = path;
            logAbstract.fileName = fileName;
            logAbstract.content = content;
            
            if (logAbstract.check())
            {
                this.logAbstract.create();
            }
        }

        public virtual void deleteLogFile(string path, string fileName)
        {
            logAbstract.path = path;
            logAbstract.fileName = fileName;

            this.logAbstract.delete();
        }

        public virtual string getLogFile()
        {
            return this.logAbstract.get();
        }

        public virtual FileStream readLogFile(string fullFilePath)
        {
            return this.logAbstract.read(fullFilePath);
        }

        public void resetParameter()
        {
            logAbstract.path = "";
            logAbstract.fileName = "";
            logAbstract.content = "";
        }
    }
}
