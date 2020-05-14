using System;
using System.Runtime.InteropServices;
using System.Security.Principal;

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
            if (logger is WindowsEventLogger)
            {
                RequireAdministratorPrivileges();
            }

            configuredLogger = logger;
        }

        public static void WriteLog(ErrorLevel level, string errorMessage, string additionalInfo)
        {
            Logger.WriteLog(level, errorMessage, additionalInfo);
        }

        private static void RequireAdministratorPrivileges()
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
