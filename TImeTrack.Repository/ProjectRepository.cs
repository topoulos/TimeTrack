using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TimeTrack.Data;
using TimeTrack.Models.Database;

namespace TImeTrack.Repository
{
    public class ProjectRepository
    {
        public TimeTrackContext context;

        public ProjectRepository(TimeTrackContext context)
        {
            this.context = context;
        }

        public IEnumerable<Project> GetAll()
        {
            return context.Projects.ToList();
        }

        public Project Add(Project newProject)
        {
            context.Projects.Add(newProject);
            context.SaveChanges();
            return newProject;
        }
    }
}