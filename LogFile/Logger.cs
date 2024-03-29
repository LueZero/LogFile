﻿using Newtonsoft.Json.Linq;
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

        public Logger(LogType logType, string path, string fileName)
        {
            InitializeLog(logType);
            InitializePath(path, fileName);
            CheckLog();
        }

        public void RestLogger(LogType logType, string path, string fileName)
        {
            InitializeLog(logType);
            InitializePath(path, fileName);
            CheckLog();
        }

        public void InitializeLog(LogType logType)
        {
            switch (logType)
            {
                case LogType.Json:
                    Log = new JsonLog();
                    break;
                case LogType.Xml:
                    Log = new XmlLog();
                    break;
                case LogType.Txt:
                    Log = new TxtLog();
                    break;
                default:
                    Log = null;
                    break;
            }
        }

        public void InitializePath(string path, string fileName)
        {          
            Log.Path = path;
            Log.FileName = fileName;
        }

        private void CheckLog()
        {
            if (Log == null)
                throw new Exception("Log is null");
        }

        public virtual void SetLogFileContent(string content)
        {
            Log.Content = content;
        }

        public virtual void CreateLogFile()
        {                     
            if (Log.Check())
                this.Log.Create();
        }

        public virtual void DeleteLogFile()
        {          
            this.Log.Delete();
        }

        public virtual string GetLogFileContent()
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
