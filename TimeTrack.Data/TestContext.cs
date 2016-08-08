using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TimeTrack.Models.Database;

namespace TimeTrack.Data
{
    public class TestContext : DbContext
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TimeTrackTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public TestContext() : base (ConnectionString)
        {
            
        }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectTask> ProjectTasks { get; set; }
        public virtual DbSet<TimeEntry> TimeEntries { get; set; }
    }
}
