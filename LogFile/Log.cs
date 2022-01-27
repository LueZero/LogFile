using System;
using System.Collections.Generic;
using System.ComponentModel;
using LogFile.Interfaces;
using LogFile.LogType;

namespace LogFile
{
    public class Log
    {
        private LogInterface Logger;

        private LogTypeEnume LogType;

        public Log(string logType)
        {
            initLogType(logType);
            initLog(logType);
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

        public void initLog(string logType)
        {
            if (LogType == LogTypeEnume.json)
            {
                Logger = new JsonLog();
            } 
            else if(LogType == LogTypeEnume.xml) 
            {
                Logger = new XmlLog();
            } 
            else if (LogType == LogTypeEnume.txt) 
            {
                Logger = new TxtLog();
            }
            else
            {
                Logger = null;
            }
        }

        public void create(string path, string content)
        {
            Logger.set(path, content);
            Logger.check();
            Logger.save();
        }

        public string get()
        {
            return this.Logger.get();
        }

        public void show()
        {

        }

        public void delete()
        {
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
