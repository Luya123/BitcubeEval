﻿using Luya123.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Luya123
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {

                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<SchoolContext>();
                    Dbinitializer.Initialize(context);
                }
                     catch (Exception ex)
                     {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Error during seeding the database");
                      }
             }
            host.Run();
        }              

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
