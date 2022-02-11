using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebRole1.Models
{
    public class GameContext : DbContext
    {

        public GameContext() : base("GameContext")
        {
        }

        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<TitleDataHeld> TitleDataHelds { get; set; }
        public DbSet<TitleMaster> TitleMasters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}