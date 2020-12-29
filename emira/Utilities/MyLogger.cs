using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emira.Utilities
{
    public class MyLogger : ILogger
    {


        private static MyLogger instance;
        private static Logger logger;

        private MyLogger()
        {

        }

        public static MyLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new MyLogger();
            }
            return instance;
        }

        private Logger GetLogger(string theLogger)
        {
            if (MyLogger.logger == null)
            {
                MyLogger.logger = LogManager.GetLogger(theLogger);
            }

            return MyLogger.logger;
        }

        public void Debug(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myLogger").Debug(message);
            }
            else
            {
                GetLogger("myLogger").Debug(message, arg);
            }
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myLogger").Info(message);
            }
            else
            {
                GetLogger("myLogger").Info(message, arg);
            }
        }

        public void Warn(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myLogger").Warn(message);
            }
            else
            {
                GetLogger("myLogger").Warn(message, arg);
            }
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myLogger").Error(message);
            }
            else
            {
                GetLogger("myLogger").Error(message, arg);
            }
        }
    }
}
