using _06.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string timeString, string reportLevel, string message)
        {
            return $"{timeString} - {reportLevel} - {message}";
        }
    }
}
