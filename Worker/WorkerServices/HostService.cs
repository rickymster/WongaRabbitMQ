using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Worker.WorkerServices
{
    public class HostService : IHostService
    {
        public string GetHost()
        {
            var directoryInfo = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).FullName;
            var builder = new ConfigurationBuilder()
            .SetBasePath(directoryInfo)
            .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();
            string host = configuration["AllowedHosts"];

            return host;
        }
    }
}
