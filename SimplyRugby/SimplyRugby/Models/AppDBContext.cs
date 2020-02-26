using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimplyRugby.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base("name=AppDBContext")
        {
        }

        public DbSet<SimplyRugby.Models.Player> Players { get; set; }

        public DbSet<SimplyRugby.Models.nonPlayer> nonPlayers { get; set; }

        public DbSet<SimplyRugby.Models.Guardian> Guardians { get; set; }

        public DbSet<SimplyRugby.Models.GameRecord> GameRecords { get; set; }

        public DbSet<SimplyRugby.Models.Skills> Skills { get; set; }

        public DbSet<SimplyRugby.Models.TrainingRecord> TrainingRecords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { }
    }
}
