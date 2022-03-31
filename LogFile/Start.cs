using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogFile
{
    class Start
    {
        static void Main(string[] args)
        {
            var json = new Logger(LogTypeEnum.Json);

            json.SetLogFileContent("{}");
            json.CreateLogFile("D:\\", "test");

            Console.WriteLine(json.GetLogFileCotent());
           
            json.DeleteLogFile("D:\\", "test");

            ///分隔線///

            var doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);
            XmlElement element1 = doc.CreateElement(string.Empty, "body", string.Empty);
            doc.AppendChild(element1);
            XmlElement element2 = doc.CreateElement(string.Empty, "level1", string.Empty);
            element1.AppendChild(element2);
            XmlElement element3 = doc.CreateElement(string.Empty, "level2", string.Empty);
            XmlText text1 = doc.CreateTextNode("text");
            element3.AppendChild(text1);
            element2.AppendChild(element3);
            XmlElement element4 = doc.CreateElement(string.Empty, "level2", string.Empty);
            XmlText text2 = doc.CreateTextNode("other text");
            element4.AppendChild(text2);
            element2.AppendChild(element4);

            var xml = new Logger(LogTypeEnum.Xml);

            xml.SetLogFileContent(doc.OuterXml);
            xml.CreateLogFile("D:\\", "test");

            Console.WriteLine(xml.GetLogFileCotent());

            xml.DeleteLogFile("D:\\", "test");
        }
    }
}
