using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FlexibleLoggingLibrary
{
    public class TextFileLogger : Logger
    {
        public TextFileLogger(string dirPath)
        {
            if (string.IsNullOrWhiteSpace(dirPath) || !Directory.Exists(dirPath))
            {
                dirPath = Path.GetTempPath();
            }

            DirPath = dirPath;
        }
        
        private string DirPath { get; }

        public override void WriteLog(ErrorLevel errorLevel, string errorMessage, string additionalInfo = "")
        {
            DateTime currentDate = DateTime.Now;
            string fileName = $"err-{currentDate.Year}{currentDate.Month.ToString().PadLeft(2,'0')}{currentDate.Day.ToString().PadLeft(2,'0')}.txt";
            string fullPath = Path.Combine(DirPath, fileName);

            using (StreamWriter sw = File.AppendText(fullPath))
            {
                StringBuilder error = new StringBuilder();
                error.AppendLine($"{errorLevel}: {errorMessage}");

                if (!string.IsNullOrWhiteSpace(additionalInfo))
                {
                    error.AppendLine(additionalInfo);
                }

                sw.WriteLine(error.ToString());
            }
        }
    }
}
