using System;
using System.Collections.Generic;
using System.Text;

namespace FlexibleLoggingLibrary
{
    public class ConsoleLogger : Logger
    {
        public override void WriteLog(ErrorLevel errorLevel, string errorMessage, string additionalInfo = "")
        {
            Console.WriteLine($"{ errorLevel }: { errorMessage }", Console.ForegroundColor = ConsoleColor.Red);

            if (!string.IsNullOrWhiteSpace(additionalInfo))
            {
                Console.WriteLine(additionalInfo, Console.ForegroundColor = ConsoleColor.DarkRed);
            }

            Console.ResetColor();
        }
    }
}
