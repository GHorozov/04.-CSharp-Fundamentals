﻿namespace DungeonsAndCodeWizards.Core.IO
{
    using DungeonsAndCodeWizards.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
