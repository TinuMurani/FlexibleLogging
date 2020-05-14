using FlexibleLoggingLibrary;
using System;

namespace FlexibleLoggingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // daca apare mesaj de la User Account Controls ca e nevoie de alte privilegii
            // trebuie repornit Visual Studio cu drepturi de administrator (optiunea din fereastra)
            // sau click dreapta pe executabilul din Debug si 'Run as administrator'

            // daca se modifica din app.manifest linia <requestedExecutionLevel level="asInvoker" uiAccess="false" />

            ApplicationLog.ConfigureLogger(new WindowsEventLogger());

            int i = 10;
            int j = 0;

            try
            {
                int result = i / j;
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteLog(ErrorLevel.Critical, ex.Message, ex.StackTrace);
            }

            Console.ReadLine();
        }
    }
}
