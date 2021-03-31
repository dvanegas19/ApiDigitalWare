using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Billing.Common.Logger
{
    /// Project: DigitalWare.Billing.Common.Logger
    /// Class:  LogConfigurator.
    /// <summary>
    ///   class that configures a log
    /// </sumary>
    /// <history>
    ///    Version      Author              Date        Description
    ///    1.0.0.0      David Vanegas     30/10/2019   Creation
    /// </history>
    public abstract class LogConfigurator : Exception
    {
        protected StringBuilder Builder = new StringBuilder();
        protected DateTime Date { get; set; }
        protected string User { get; set; }

        /// <summary>
        /// The constructor implements the log message that will be written in the selected repository
        /// </summary>
        protected LogConfigurator()
        {
            Builder.AppendLine("Type: {0} | DateTime: {1} | Message: {2} | TargetSite: {3}");
        }

        public abstract void Exception(Exception ex, string location);

        public abstract void Info(string Message);
    }
}
