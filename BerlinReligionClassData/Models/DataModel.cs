using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BerlinReligionClassData.DAL;
using BerlinReligionClassData.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BerlinReligionClassData.Models {

    public class DataModel {
        public void CreateDB () 
        {
            using (var context = new ReligionDatabaseContext())
            {
                //Clears and delete the database
                context.Database.EnsureDeleted();

                //Creates the database
                context.Database.EnsureCreated();
                ExcelReader excel = new ExcelReader();

                foreach (Subvention s in excel.ReadSubventionSource())
                {
                    context.Subventions.Add(s);
                }
                foreach (Participant p in excel.ReadParticipantSource())
                {
                    context.Participants.Add(p);
                }
                context.SaveChanges();
            }   

        }
    }
}