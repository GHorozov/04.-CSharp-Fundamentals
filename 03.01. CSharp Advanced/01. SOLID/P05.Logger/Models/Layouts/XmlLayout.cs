namespace P05.Logger.Models.Layouts
{
    using P05.Logger.Models.Interfaces;
    using System;
    using System.Globalization;

    public class XmlLayout : ILayout
    {
        private const string DateFormat = "HH:mm:ss dd-MMM-yyyy";
        private string Format = 
            "<log>" + Environment.NewLine +
            "\t<date>{0}</date>" + Environment.NewLine +
            "\t<level>{1}</level>" + Environment.NewLine +
            "\t<message>{2}</message>" + Environment.NewLine +
            "</log>";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            var result = string.Format(Format, dateString, error.ErrorLevel.ToString(), error.Message);

            return result;
        }
    }
}
