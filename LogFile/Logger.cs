using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile
{
    public class Logger
    {
        private LogAbstract log;

        public Logger(LogTypeEnume logType)
        {
            initialization(logType);
        }

        public void initialization(LogTypeEnume logType)
        {
            switch (logType)
            {
                case LogTypeEnume.json:
                    log = new JsonLog();
                    break;
                case LogTypeEnume.xml:
                    log = new XmlLog();
                    break;
                case LogTypeEnume.txt:
                    log = new TxtLog();
                    break;
                default:
                    log = null;
                    break;
            }
        }

        public void createLog(string path, string fileName, string content)
        {
            log.path = path;
            log.fileName = fileName;
            log.content = content;
            
            if (log.check())
            {
                this.log.create();
            }
          
            this.restParameter();
        }

        public void deleteLog(string path, string fileName)
        {
            log.path = path;
            log.fileName = fileName;
            this.log.delete();
            this.restParameter();
        }

        public string getLog()
        {
            return this.log.get();
        }

        public void restParameter()
        {
            log.path = "";
            log.fileName = "";
            log.content = "";
        }
    }
}
