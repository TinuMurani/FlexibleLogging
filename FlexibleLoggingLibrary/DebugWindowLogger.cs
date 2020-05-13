using System;
using System.Collections.Generic;
using System.Text;

namespace FlexibleLoggingLibrary
{
    public class DebugWindowLogger : Logger
    {
        public override void WriteLog(ErrorLevel errorLevel, string errorMessage, string additionalInfo = "")
        {
            System.Diagnostics.Debug.WriteLine($"{ errorLevel }: { errorMessage }");

            if (!string.IsNullOrWhiteSpace(additionalInfo))
            {
                System.Diagnostics.Debug.WriteLine(additionalInfo);
            }
        }
    }
}
