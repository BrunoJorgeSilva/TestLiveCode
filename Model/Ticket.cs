using System.ComponentModel.DataAnnotations;

namespace TestLiveCode.Model
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Done {  get; set; }
        public bool Active { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}
