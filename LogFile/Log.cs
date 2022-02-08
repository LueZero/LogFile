using System;
using System.Collections.Generic;
using System.ComponentModel;
using LogFile.Interfaces;

namespace LogFile
{
    public class Log
    {
        internal LogInterface Logger;

        private LogTypeEnume LogType;

        public Log(string logType)
        {
            initLogType(logType);
            initLog();
        }

        private void initLogType(string logType)
        {
            switch(logType)
            {
                case "json":
                    LogType = LogTypeEnume.json;
                    break;
                case "xml":
                    LogType = LogTypeEnume.xml;
                    break;
                case "txt":
                    LogType = LogTypeEnume.txt;
                    break;
            }
        }

        public void initLog()
        {
            switch(LogType)
            {
                case LogTypeEnume.json:
                    Logger = new JsonLog();
                    break;
                case LogTypeEnume.xml:
                    Logger = new XmlLog();
                    break;
                case LogTypeEnume.txt:
                    Logger = new TxtLog();
                    break;
                default:
                    Logger = null;
                    break;
            }
        }

        public LogInterface useLogObject()
        {
            return this.Logger;
        }

        public void saveLog(string path, string fileName, string content)
        {
            Logger.set(path, fileName, content);
            Logger.save();
        }

        public string getLogString()
        {
            return this.Logger.get();
        }

        public void delete(string path, string fileName)
        {
            Logger.set(path, fileName);
            Logger.delete();
        }
    }

    public enum LogTypeEnume
    {
        [Description("json")]
        json,
        [Description("xml")]
        xml,
        [Description("txt")]
        txt
    }
}
