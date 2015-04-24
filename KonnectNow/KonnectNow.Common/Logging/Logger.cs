using KonnectNow.Common;
using System;
using System.Configuration;
namespace KonnectNow.Common.Logging
{
    /// <summary>
    /// Gives Logging operations
    /// </summary>
    public class Logger : SingletonBase<Logger>
    {
        private readonly log4net.ILog _log;

        #region Private constructor

        /// <summary>
        /// Private constructor to make the class Singleton.
        /// </summary>
        private Logger()
        {          
            _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log4net.Config.XmlConfigurator.Configure();
            log4net.Repository.Hierarchy.Hierarchy hier =
             log4net.LogManager.GetRepository() as log4net.Repository.Hierarchy.Hierarchy;

            if (hier != null)
            {
                //get ADONetAppender
                log4net.Appender.AdoNetAppender adoAppender =
                  (log4net.Appender.AdoNetAppender)hier.GetLogger("log4net.Appender.AdoNetAppenders",
                    hier.LoggerFactory).GetAppender("AdoNetAppender");
                if (adoAppender != null)
                {
                    adoAppender.ConnectionString = ConfigurationManager.ConnectionStrings["KonnectNow"].ToString();
                    adoAppender.ActivateOptions();
                }
            }
        }

        #endregion

        #region Public members

        /// <summary>
        /// Gets whether the debugging is enabled or not.
        /// </summary>
        public bool IsDebugEnabled { get { return _log.IsDebugEnabled; } }

        /// <summary>
        /// Logs Exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="ex">Exception object</param>
        public void Log(string message, Exception ex)
        {
            _log.Error(message, ex);
        }

        /// <summary>
        /// Logs the message
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="level">LogLevel</param>
        public void Log(string message, LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    {
                        if (_log.IsDebugEnabled)
                        {
                            _log.Debug(message);
                        }
                        break;
                    }
                case LogLevel.Information:
                    {
                        if (_log.IsInfoEnabled)
                        {
                            _log.Info(message);
                        }
                        break;
                    }
                case LogLevel.Warning:
                    {
                        if (_log.IsWarnEnabled)
                        {
                            _log.Warn(message);
                        }
                        break;
                    }
                case LogLevel.Error:
                    {
                        if (_log.IsErrorEnabled)
                        {
                            _log.Error(message);
                        }
                        break;
                    }
                case LogLevel.Fatal:
                    {
                        if (_log.IsFatalEnabled)
                        {
                            _log.Fatal(message);
                        }
                        break;
                    }
            }
        }

        #endregion

    }
}
