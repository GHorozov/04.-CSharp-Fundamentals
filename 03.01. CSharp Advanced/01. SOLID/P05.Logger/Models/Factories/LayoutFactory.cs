using P05.Logger.Models.Interfaces;
using P05.Logger.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P05.Logger.Models.Factories
{
    public class LayoutFactory
    {
        public ILayout GetLayout(string layoutType)
        {
            ILayout layout = null; 
            switch (layoutType)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;
                case "XmlLayout":
                    layout = new XmlLayout();
                    break;
                default:
                    throw new InvalidOperationException("Invalid layout type!!!");
            }

            return layout;
        }
    }
}
