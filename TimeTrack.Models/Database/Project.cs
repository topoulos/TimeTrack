using System.Collections.Generic;
using System.Diagnostics;

namespace TimeTrack.Models.Database
{
    public class Project : DbBase
    {
        public virtual ICollection<ProjectTask> Tasks { get; set; }
    }
}
