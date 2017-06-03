using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Logger
{
    public class LoggerHelper
    {
        private LoggerHelper()
        {

        }

        private ILogger Logger { get; set; }


        private static Lazy<LoggerHelper> s_instance = new Lazy<LoggerHelper>(() =>
        {
            return new LoggerHelper();
        });

        public static LoggerHelper Instance
        {
            get
            {
                return s_instance.Value;
            }
        }

        public void Error(string content)
        {
            Logger.Error(content);
        }

        public void Warn(string content)
        {
            Logger.Warn(content);
        }

        public void Info(string content)
        {
            Logger.Info(content);
        }

        public void Log(string content)
        {
            Logger.Log(content);
        }
    }
}
