using System.ComponentModel.DataAnnotations;

namespace TestLiveCode.Model
{
    public class Client
    {
        public Guid ClientId { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        public bool IsTop500 { get; set; }
        public DateTime DateAdded { get; set; }
        public int TasksToBeDone { get; set; } 
        public int TasksDone { get; set; }
        public bool Active { get; set; }
        public List<Ticket>? Tickets { get; set; }
    }
}
