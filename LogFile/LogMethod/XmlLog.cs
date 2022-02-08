﻿using LogFile.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogFile
{
    internal class XmlLog : Logger<XmlDocument>, LogInterface
    {
        public bool check()
        {
            try
            {
                this.log = new XmlDocument();

                this.log.LoadXml(this.content);

                return true;
            }
            catch (XmlException ex)
            {
                this.error = ex.Message;
          
                return false;
            }
        }

        public void save()
        {
            if (this.check())
            {
                try
                {
                    this.log.Save(this.fullFilePath);
                }
                catch (XmlException ex)
                {
                    this.error = ex.Message;
                    logException();
                }
            }
            else
            {
                logException();
            }
        }

        public void delete()
        {
            bool result = File.Exists(this.fullFilePath);

            if (!result)
            {
                this.error = this.fullFilePath + " Not Found";
                logException();
            }

            File.Delete(this.fullFilePath);
        }

        public void read(string fullFilePath)
        {
         
        }
    }
}