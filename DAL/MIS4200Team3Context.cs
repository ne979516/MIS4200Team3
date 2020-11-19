using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS4200Team3.Models;
using System.Data.Entity;

namespace MIS4200Team3.DAL
{
    public class MIS4200Team3Context : DbContext
    {

        public MIS4200Team3Context() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MIS4200Team3Context, MIS4200Team3.Migrations.MISContext.Configuration>("DefaultConnection"));
        }
            public DbSet<Profile> Profiles { get; set; }

        public System.Data.Entity.DbSet<MIS4200Team3.Models.Refer> Refers { get; set; }
    }
}
    
