using FlexibleLoggingLibrary;
using System;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace FlexibleLoggingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RequireAdministrator();
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

        private static void RequireAdministrator()
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
                    {
                        WindowsPrincipal principal = new WindowsPrincipal(identity);

                        if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                        {
                            throw new InvalidOperationException($"Application must be run as Administrator." +
                                $"Right click the '{ AppDomain.CurrentDomain.FriendlyName }.exe' file and select 'Run as administrator'.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteLog(ErrorLevel.Critical, ex.Message, ex.StackTrace);
            }
        }
    }
}
