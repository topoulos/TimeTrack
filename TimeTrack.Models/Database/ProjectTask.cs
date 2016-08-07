using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrack.Models.Database
{
    public class ProjectTask : DbBase
    {
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
