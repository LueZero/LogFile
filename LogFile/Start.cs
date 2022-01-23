using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile
{
    class Start
    {
        static void Main(string[] args)
        {
            // Display the number of command line arguments.
            var log = new Log("json");
            log.create("awdD:\\test.json", "{}");
            log.show();
        }
    }
}
