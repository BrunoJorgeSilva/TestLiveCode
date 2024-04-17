using AutoMapper;
using TestLiveCode.Business;
using TestLiveCode.Model;
using TestLiveCode.ViewModel;

namespace TestLiveCode.Service
{
    public class TicketService : ITicketService
    {
        private readonly ITicketBusiness _ticketBusiness;
        private readonly IMapper _map;

        public TicketService(ITicketBusiness ticketBusiness, IMapper map)
        {
            _ticketBusiness = ticketBusiness;
            _map = map;
        }
        public List<TicketViewModel> GetTickets()
        {
            return _map.Map<List<TicketViewModel>> (_ticketBusiness.GetTickets());
        }
        public TicketViewModel GetTicketById(Guid id)
        {
            return _map.Map<TicketViewModel>(_ticketBusiness.GetTicketById(id));
        }

        public List<TicketViewModel> GetTicketsByClientId(Guid clientId)
        {
            return _map.Map<List<TicketViewModel>> (_ticketBusiness.GetTicketsByClientId(clientId));
        }
        public List<TicketViewModel> GetTicketByClientName(string name)
        {
            return _map.Map<List<TicketViewModel>>(_ticketBusiness.GetTicketByClientName(name)); 
        }

        public TicketViewModel AddTicket(Ticket ticket)
        {
            return _map.Map<TicketViewModel>(_ticketBusiness.AddTicket(ticket));
        }

        public TicketViewModel PutTicket(TicketViewModel ticket, Guid id)
        {
            return _map.Map<TicketViewModel> (_ticketBusiness.PutTicket(ticket, id));
        }

        public bool DeleteTicket(Guid id)
        {
            return _ticketBusiness.DeleteTicket(id);
        }
    }
}
