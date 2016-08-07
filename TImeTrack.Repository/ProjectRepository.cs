using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TimeTrack.Data;
using TimeTrack.Models.Database;

namespace TImeTrack.Repository
{
    public class ProjectRepository
    {
        private readonly TimeTrackContext context;

        public ProjectRepository(TimeTrackContext context)
        {
            this.context = context;
        }

        public IEnumerable<Project> GetAll()
        {
            return context.Projects.ToList();
        }
    }
}