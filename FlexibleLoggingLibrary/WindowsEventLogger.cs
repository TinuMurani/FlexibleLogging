using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FlexibleLoggingLibrary
{
    public class WindowsEventLogger : Logger
    {
        public override void WriteLog(ErrorLevel errorLevel, string errorMessage, string additionalInfo = "")
        {
            EventLog.WriteEntry("FlexibleLoggingApp", errorMessage + (additionalInfo ?? ""));
        }
    }
}
