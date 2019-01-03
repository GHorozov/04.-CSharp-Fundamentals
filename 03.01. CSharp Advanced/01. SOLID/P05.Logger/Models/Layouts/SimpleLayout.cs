namespace P05.Logger.Models.Layouts
{
    using P05.Logger.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    public class SimpleLayout : ILayout
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            var result = $"{dateString}, {error.ErrorLevel.ToString()}, {error.Message}";

            return result;
        }
    }
}
