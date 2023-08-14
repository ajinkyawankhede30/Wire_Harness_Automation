using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MP_to_Ground_v2
{
    public sealed class Logger
    {
        private Logger() { } //disable constructor

        static Logger logger1 = null;
        string sLogPath = @"D:\nxopen Projects\MP_to_Ground_v2\log.txt";
        static readonly object _synLock = new object();
        public static Logger getInstance()
        {
            lock (_synLock)
            {
                if (logger1 == null)
                    logger1 = new Logger();
            }

            return logger1;
        }

        public void writeLog(string info)
        {
            File.AppendAllText(sLogPath, info);
        }

        public void flushLog()
        {
            File.AppendAllText(sLogPath, "\n");
        }
    }
}
