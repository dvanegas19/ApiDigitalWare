using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DigitalWare.Billing.Common.Logger
{
    /// Project: DigitalWare.Billing.Common.Logger
    /// Class:  Log.
    /// <summary>
    ///  Log Handler
    /// </sumary>
    /// <history>
    ///    Version      Autor              Date         Description
    ///    1.0.0.0      David Vanegas    29/03/2021   Creation
    /// </history>
    public static class Log
    {
        private static readonly Lazy<LogManager> Instance = new Lazy<LogManager>(() => new LogManager(new FileWriter()));

        public static LogManager GetInstance { get { return Instance.Value; } }

        /// <summary>
        /// Implement and register an exception in different repositories
        /// </summary>
        /// <param name="ex">Exception to register</param>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas     29/03/2021   Creation
        /// </history>
        public static void Exception(Exception ex, string location)
        {
            var fileWriter = new LogManager(new FileWriter { });
            fileWriter.Exception(ex, location);
        }

        /// <summary>
        /// Implement and register an info in different repositories
        /// </summary>
        /// <param name="Message">Info to register</param>
        /// <history>
        ///    Version      Autor              Date         Description
        ///    1.0.0.0      David Vanegas    29/03/2021   Creation
        /// </history>
        public static void Info(string Message)
        {
            var fileWriter = new LogManager(new FileWriter { });
            fileWriter.Info(Message);
        }

    }
}
