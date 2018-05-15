using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Logger.Interfaces
{
    public interface ILayout
    {
        string FormatMessage(string timeString, string reportLevel, string message);
    }
}
