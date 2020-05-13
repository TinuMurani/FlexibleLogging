using System;
using System.Collections.Generic;
using System.Text;

namespace FlexibleLoggingLibrary
{
    public abstract class Logger
    {
        public abstract void WriteLog(ErrorLevel errorLevel, string errorMessage, string additionalInfo = "");
    }
}
