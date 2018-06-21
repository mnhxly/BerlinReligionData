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

                //Adds every Subvention from the ReadSubventionSource SubventionList into the DatabaseContext
                foreach (Subvention s in excel.ReadSubventionSource())
                {
                    context.Subventions.Add(s);
                }
                //Adds every Participant from the ReadParticipantSource ParticipantList into the DatabaseContext
                foreach (Participant p in excel.ReadParticipantSource())
                {
                    context.Participants.Add(p);
                }

                //Saves all Changes to the database
                context.SaveChanges();
            }   

        }
    }
}