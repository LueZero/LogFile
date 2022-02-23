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
            var json = new Log(LogTypeEnume.Txt);
            
            json.CreateLogFile("D:\\", "test", "{}");

            Console.WriteLine(json.GetLogFile());
           
            json.DeleteLogFile("D:\\", "test");
        }
    }
}
