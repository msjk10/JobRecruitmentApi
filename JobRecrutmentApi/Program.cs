using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace JobRecrutmentApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateFileLogger();
            BuildWebHost(args).Run();
        }

        public static void CreateFileLogger()
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Information()
                            .MinimumLevel.Override("JobLog", LogEventLevel.Information)
                            .WriteTo.File("Logs/Log.txt",
                                    LogEventLevel.Information,
                                    rollingInterval: RollingInterval.Day,
                                    retainedFileCountLimit: null,
                                    fileSizeLimitBytes: null,
                                    outputTemplate: "{Timestamp:dd-MMM-yyyy HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",  
                                    shared: true
                                    )
                            .CreateLogger();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog()
                .Build();
    }
}
