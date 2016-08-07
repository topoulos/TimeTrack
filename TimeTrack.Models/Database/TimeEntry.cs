using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrack.Models.Database
{
    public class TimeEntry : DbBase
    {
        
        public DateTime? EntryDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int? ProjectId { get; set; }
        public int? ProjectTaskId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ProjectTask ProjectTask { get; set; }

    }
}
