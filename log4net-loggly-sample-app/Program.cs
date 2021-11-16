using System;
using System.Collections.Generic;
using log4net;

namespace log4net_loggly_sample_app
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetLogger(typeof(Program));
            //Send plaintext
            logger.Info("First log line");

            //Send an exception
            logger.Error("Some exception", new Exception("Explicit excpetion"));

            //Send a JSON object
            var items = new Dictionary<string, string>();
            items.Add("key1", "value1");
            items.Add("key2", "value2");
            logger.Info(items);
            
            //Wait atleast 5 seconds before terminating the application to send logs to loggly
            Console.WriteLine("Log is sending to loggly. Wait atleast 5 seconds before terminating the application.");
            //safe close, remove/close all appenders
            logger.Logger.Repository.Shutdown();
            Console.ReadKey();
        }
    }
}
