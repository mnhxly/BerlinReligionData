using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using LeenartMalteProject.Models;

namespace BerlinReligionData
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //DataModel data = new DataModel();
            //data.CheckIfDBAlreadyExists();
            //data.CreateDB();

            BuildWebHost(args).Run();


        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
