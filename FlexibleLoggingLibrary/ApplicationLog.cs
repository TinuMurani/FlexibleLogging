using System;
using System.Collections.Generic;
using System.Text;

namespace FlexibleLoggingLibrary
{
    public class ApplicationLog
    {
        private static Logger configuredLogger;

        private static Logger Logger 
        {
            get 
            {
                if (configuredLogger is null)
                {
                    return new ConsoleLogger();
                }

                return configuredLogger;
            }
        }

        public static void ConfigureLogger(Logger logger)
        {
            configuredLogger = logger;
        }

        public static void WriteLog(ErrorLevel level, string errorMessage, string additionalInfo)
        {
            Logger.WriteLog(level, errorMessage, additionalInfo);
        }
    }
}
