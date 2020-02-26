namespace SimplyRugby.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimplyRugby.Models.AppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SimplyRugby.Models.AppDBContext";
        }

        protected override void Seed(SimplyRugby.Models.AppDBContext context)
        {
            
        }
    }
}
