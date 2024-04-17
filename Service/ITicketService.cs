using TestLiveCode.Model;
using TestLiveCode.ViewModel;

namespace TestLiveCode.Service
{
    public interface ITicketService
    {
        public List<TicketViewModel> GetTickets();
        public TicketViewModel GetTicketById(Guid id);
        public List<TicketViewModel> GetTicketsByClientId(Guid clientId);
        public List<TicketViewModel> GetTicketByClientName(string name);
        public TicketViewModel AddTicket(Ticket ticket);
        public TicketViewModel PutTicket(TicketViewModel ticket, Guid id);
        public bool DeleteTicket(Guid id);
    }
}
