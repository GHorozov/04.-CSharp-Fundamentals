using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Logger.Interfaces
{
    public interface ILogger
    {
        void Error(string timeString, string message);

        void Info(string timeString, string message);

        void Fatal(string timeString, string message);

        void Critical(string timeString, string message);

        void Warn(string timeString, string message);
    }
}
