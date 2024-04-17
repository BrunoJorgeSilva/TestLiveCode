using TestLiveCode.Model;
using TestLiveCode.ViewModel;

namespace TestLiveCode.Business
{
    public interface ITicketBusiness
    {
        public List<Ticket> GetTickets();
        public List<Ticket>? GetTicketsByClientId(Guid clientId);
        public List<Ticket>? GetTicketByClientName(string name);
        public Ticket GetTicketById(Guid ticketId);
        public bool DeleteTicket(Guid id);
        public Ticket PutTicket(TicketViewModel ticket, Guid id);
        public Ticket AddTicket(Ticket ticket);
    }
}
