using System.ComponentModel.DataAnnotations;

namespace TimeTrack.Models.Database
{
    public class DbBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
