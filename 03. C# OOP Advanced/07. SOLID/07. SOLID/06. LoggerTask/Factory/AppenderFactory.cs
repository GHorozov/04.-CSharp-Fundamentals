﻿using _06.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _06.LoggerTask.Factory
{
    public class AppenderFactory
    {
        public static IAppender GetAppender(string appenderType, ILayout layout)
        {
            Type typeOfAppender = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == appenderType);

            return (IAppender)Activator.CreateInstance(typeOfAppender, layout);
        }
    }
}
