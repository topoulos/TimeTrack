using System.Data.Entity.Migrations;
using TimeTrack.Models.Database;

namespace TimeTrack.Data
{
    internal sealed class TestConfig : DbMigrationsConfiguration<TimeTrack.Data.TestContext>
    {
        public TestConfig()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestContext testContext)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //testContext.ProjectTasks.AddOrUpdate(p=>p.Id,
            //  new ProjectTask { Name = "Andrew Peters" },
            //  new ProjectTask { Name = "Brice Lambson" },
            //  new ProjectTask { Name = "Rowan Miller" }
            //);
            //
        }
    }
}
