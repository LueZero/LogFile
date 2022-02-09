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
            var json = new Logger(LogTypeEnume.json);
            json.path = "D:\\";
            json.fileName = "test";
            json.content = "{}";
            json.createLog();
            Console.WriteLine(json.getLogString());
            json.deleteLog();

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

            var xml = new Logger(LogTypeEnume.xml);
            xml.path = "D:\\";
            xml.fileName = "test";
            xml.content = doc.OuterXml;
            xml.createLog();
            Console.WriteLine(xml.getLogString());
            xml.deleteLog();

            var txt = new Logger(LogTypeEnume.txt);
            txt.path = "D:\\";
            txt.fileName = "test";
            txt.content = "123";
            txt.createLog();
            Console.WriteLine(txt.getLogString());
            txt.deleteLog();
        }
    }
}
