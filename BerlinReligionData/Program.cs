using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using BerlinReligionData.DAL;
using BerlinReligionData.Models;

namespace BerlinReligionData
{
    public class Program
    {
        public static void Main(string[] args)
        {

            using (var context = new ReligionDatabaseContext()) 
            {
                //Clears and delete the database
                context.Database.EnsureDeleted();

                //Creates the database
                context.Database.EnsureCreated();

                var sub1 = new Subvention(1, 26170923, 2011, "Evangelsiche Kische");
                var sub2 = new Subvention(2, 25927285, 2012, "Evangelsiche Kische");
                var sub3 = new Subvention(3, 25601313, 2013, "Evangelsiche Kische");
                var sub4 = new Subvention(4, 25722940, 2014, "Evangelsiche Kische");
                var sub5 = new Subvention(5, 25688712, 2015, "Evangelsiche Kische");
                var sub6 = new Subvention(6, 28134983, 2016, "Evangelsiche Kische");

                var sub7 = new Subvention(7, 13603080, 2011, "Humanistischer Verband");
                var sub8 = new Subvention(8, 14160080, 2012, "Humanistischer Verband");
                var sub9 = new Subvention(9, 14645942, 2013, "Humanistischer Verband");
                var sub10 = new Subvention(10, 15110188, 2014, "Humanistischer Verband");
                var sub11 = new Subvention(11, 15574620, 2015, "Humanistischer Verband");
                var sub12 = new Subvention(12, 18082480, 2016, "Humanistischer Verband");



                context.Subventions.Add(sub1);
                context.Subventions.Add(sub2);
                context.Subventions.Add(sub3);
                context.Subventions.Add(sub4);
                context.Subventions.Add(sub5);
                context.Subventions.Add(sub6);

                context.Subventions.Add(sub7);
                context.Subventions.Add(sub8);
                context.Subventions.Add(sub9);
                context.Subventions.Add(sub10);
                context.Subventions.Add(sub11);
                context.Subventions.Add(sub12);


                context.SaveChanges();
            }


        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
