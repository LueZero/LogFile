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

        private LogTypeEnume LogType {
            get { return LogTypeEnume.json; }
            set { LogType = value; }
        }

        private string path { get; set; }

        private string contnet { get; set; }

        public Log(string logType)
        {
            initLog(logType);
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

        public void create(string filePath, string contnet)
        {
            this.path = filePath;
            this.contnet = contnet;

            Logger.set(this.path, this.contnet);
            Logger.save();
        }

        public string get()
        {
            return this.contnet;
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
