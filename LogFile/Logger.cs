using LogFile.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile
{
    public class Logger
    {
        public Logger(LogTypeEnume logType)
        {
            initialization(logType);
        }

        public string path { get; set; }

        public string fileName { get; set; }

        public string content { get; set; }

        public string error { get; set; }

        private LogInterface log;

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

        public void createLog()
        {
            this.log.save(this.path, this.fileName, this.content);
        }

        public void deleteLog()
        {
            this.log.delete(this.path, this.fileName);
        }

        public string getLogString()
        {
            return this.log.get();
        }
    }
}
