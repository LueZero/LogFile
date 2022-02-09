using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFile
{
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
