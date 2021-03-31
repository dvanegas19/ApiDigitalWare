using System;
using System.Net;
using System.Threading.Tasks;

namespace DigitalWare.Billing.Common.Logger
{
    /// Project: DigitalWare.Billing.Common.Logger
    /// Class:  LogManager.
    /// <summary>
    ///  class that manages the "logs" register by means of dependency injection
    /// </sumary>
    public class LogManager : LogConfigurator
    {
        /// <summary>
        /// Log Configurator <see cref="LogConfigurator"/>
        /// </summary>
        protected LogConfigurator LogService;

        /// <summary>
        /// dependency injection by constructor
        /// </summary>
        /// <param name="log"><example><see cref="FileWriter"/></example></param>
        public LogManager(LogConfigurator log)
        {
            LogService = log;
        }

        /// <summary>
        /// Implements and registers an exception
        /// </summary>
        /// <param name="ex">Exception to register</param>
        /// <history>
        ///    Version      Autor              Date         Description
        ///    1.0.0.0      David Vanegas    10/07/2018   Creation
        /// </history>
        public override void Exception(Exception ex, string location)
        {
            LogService.Exception(ex, location);
        }

        /// <summary>
        /// Implements and registers an info
        /// </summary>
        /// <param name="Message">Info to register</param>
        /// <history>
        ///    Version      Autor              Date         Description
        ///    1.0.0.0      David Vanegas    10/07/2018   Creation
        /// </history>
        public override void Info(string Message)
        {
            LogService.Info(Message);
        }
    }
}
