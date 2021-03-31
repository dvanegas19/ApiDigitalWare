using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DigitalWare.Billing.Common.Logger
{
    /// Project: Falabella.Certificates.Common.Logger.dll
    /// Class:  FileWriter.
    /// <summary>
    ///   class that writes to a file
    /// </sumary>
    /// <history>
    ///    Version      Autor              Date         Description
    ///    1.0.0.0      David Vanegas    29/03/2021   Creation
    /// </history>
    public class FileWriter : LogConfigurator, IDisposable
    {
        protected StreamWriter Writer { get; set; }

        /// <summary>
        ///  determines whether or not to write the log
        /// </summary>
        protected bool WriteLog
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings[Resources.Setting.WriteLogKeyName].Equals("1");
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Constructor implement the StreamWriter
        /// </summary>
        public FileWriter()
        {
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string fileLogName = $"{DateTime.UtcNow.Year}{DateTime.UtcNow.Month}{DateTime.UtcNow.Day}";

                string logRoute = string.Format(ConfigurationManager.AppSettings[Resources.Setting.LogFilePathKeyName], fileLogName);
                Writer = new StreamWriter(logRoute, true);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Implements and registers an exception in a file text
        /// </summary>
        /// <param name="ex">Exception to register</param>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas    29/03/2021   Creation
        /// </history>
        public override void Exception(Exception ex, string location)
        {
            try
            {

                 Writer.Write
                 (
                    string.Format
                                (
                                    Builder.ToString(),
                                    "Exception",
                                    DateTime.Now,
                                    Regex.Replace(ex.Message, @"\t|\n|\r", ""),
                                    location
                                )
                  );
                    Writer.Flush();
                    Writer.Close();
                    Writer.Dispose();
                }
            
            catch (Exception) { }
        }

        /// <summary>
        /// Implements and registers an info in a file text
        /// </summary>
        /// <param name="ex">Info to register</param>
        /// <history>
        ///    Version      Author              Date         Description
        ///    1.0.0.0      David Vanegas    29/03/2021   Creation
        /// </history>
        public override void Info(string Message)
        {
            try
            {
                if (WriteLog)
                {
                    Writer.Write
                     (
                       string.Format(Builder.ToString(),
                                         "Info",
                                          DateTime.Now,
                                          Regex.Replace(Message, @"\t|\n|\r", ""),
                                          "N/A",
                                          "N/A",
                                          "N/A"
                                     )
                      );
                    Writer.Flush();
                    Writer.Close();
                    Writer.Dispose();
                }

            }
            catch (Exception) { }
        }

        public void Dispose()
        {
            Writer.Dispose();
            Writer.Close();
        }

    }
}
