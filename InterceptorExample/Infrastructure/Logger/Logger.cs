using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serilog;
using Serilog.Events;

namespace InterceptorExample.IoC
{
    public class Logger
    {
        private static volatile Logger instance;
        private static Serilog.ILogger log;
        private static object syncRoot = new Object();

        private Logger()
        {
            if (log == null)
            {
                // Create a settings instance
               
             
                // Append full stack trace if enriched log event has an Exception object
                Log.Logger = new LoggerConfiguration()
                  .WriteTo.RollingFile("log.txt",LogEventLevel.Debug)
                    .ReadFrom.AppSettings()
                    .CreateLogger();
            }
        }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Logger();
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Logs a message object with the Info level.
        /// </summary>
        /// <param name="logMessage">The message object to log.</param>
        public void LogDebug(string logMessage)
        {
            log.Debug(logMessage);
        }

        /// <summary>
        /// Logs a message object with the Info level.
        /// </summary>
        /// <param name="logMessage">The message object to log.</param>
        public void LogInfo(string logMessage)
        {
            log.Information(logMessage);
        }

        /// <summary>
        /// Log a message object with the Error level including the stack trace of the System.Exception passed as a parameter.
        /// </summary>
        /// <param name="logMessage">The message object to log.</param>
        /// <param name="ex">The exception to log, including its stack trace.</param>
        public void LogException(string logMessage, Exception ex)
        {
            log.Error(logMessage, ex);
            if (ex.InnerException != null)
            {
                LogException(logMessage, ex.InnerException);
            }
        }

        /// <summary>
        /// Logs a message object with the Error level.
        /// </summary>
        /// <param name="logMessage">The message object to log.</param>
        public void LogException(string logMessage)
        {
            log.Error(logMessage);
        }

        /// <summary>
        /// Log a message object with Warning level.
        /// </summary>
        /// <param name="logMessage">The message object to log.</param>
        public void LogWarning(string logMessage)
        {
            log.Warning(logMessage);
        }


        /// <summary>
        /// Log a message object with Warning level.
        /// </summary>
        /// <param name="logMessage">The message object to log.</param>
        public void LogFatal(Exception ex, string logMessage)
        {
            log.Fatal(ex, logMessage);
        }
    }
}