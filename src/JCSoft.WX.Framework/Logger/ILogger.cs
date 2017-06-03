using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Logger
{
    public interface ILogger
    {
        void Warn(string content);

        void Error(string content);

        void Info(string content);

        void Log(string content);
    }
}
