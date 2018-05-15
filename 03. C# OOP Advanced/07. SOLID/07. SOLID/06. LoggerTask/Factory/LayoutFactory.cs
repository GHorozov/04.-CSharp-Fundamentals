using _06.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _06.LoggerTask.Factory
{
    public class LayoutFactory
    {
        public static ILayout GetInstance(string typeLayout)
        {
            Type layoutType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == typeLayout);

            return (ILayout)Activator.CreateInstance(layoutType);
        }
        
    }
}
