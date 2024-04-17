using TestLiveCode.Model;

namespace TestLiveCode.ViewModel
{
    public class ClientViewModel
    {
        public string Name { get; set; }
        public bool IsTop500 { get; set; }
        public DateTime DateAdded { get; set; }
        public int TasksToBeDone { get; set; }
        public int TasksDone { get; set; }
        public bool Active { get; set; }
        public List<TicketViewModel>? Tickets { get; set; }
    }
}
