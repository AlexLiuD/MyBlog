using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Common
{
    public class LogHelper
    {
        public static void WriteLog(string txt)
        {
            ILog log = LogManager.GetLogger("log4netlogger");
            log.Error(txt);
        }
    }
}
