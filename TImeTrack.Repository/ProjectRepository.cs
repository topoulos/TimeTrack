using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using TimeTrack.Data;
using TimeTrack.Models.Database;

namespace TImeTrack.Repository
{
    public class ProjectRepository
    {
        public DbContext context;

        public ProjectRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Project> GetAll()
        {
            return context.Set<Project>().ToList();
        }

        public Project Add(Project newProject)
        {
            context.Set<Project>().Add(newProject);
            context.SaveChanges();
            return newProject;
        }
    }
}