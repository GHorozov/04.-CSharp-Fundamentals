using P05.Logger.Enums;
using P05.Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace P05.Logger.Models.Factories
{
    public class ErrorFactory
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public IError GetError(string errorLevel, string dateTime, string message)
        {
            var time = DateTime.ParseExact(dateTime, DateFormat, CultureInfo.InvariantCulture);
            ErrorLevel currentErrorLevel;
            var isValidErrorLevel = Enum.TryParse<ErrorLevel>(errorLevel, out currentErrorLevel);
        
            IError error = new Error(time, currentErrorLevel, message);

            return error;
        }
    }
}
