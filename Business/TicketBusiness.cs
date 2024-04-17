using AutoMapper;
using TestLiveCode.Context;
using TestLiveCode.Model;
using TestLiveCode.ViewModel;

namespace TestLiveCode.Business
{
    public class TicketBusiness : ITicketBusiness
    {
        private readonly DbContextExample _context;
        private readonly IMapper _map;
        private readonly IClientBusiness _clientBusiness;

        public TicketBusiness(DbContextExample context, IMapper map, IClientBusiness clientBusiness)
        {
            _context = context;
            _map = map;
            _clientBusiness = clientBusiness;
        }

        public List<Ticket> GetTickets()
        {
            return _context.Ticket.Where(x => x.Active == true).ToList();
        }
        public List<Ticket> GetTicketsByClientId(Guid clientId)
        {
            var clientExists = _clientBusiness.GetClientById(clientId);
            if (clientExists is not null) 
            {
                return clientExists?.Tickets?.Where(x => x.Active == true).ToList();
            }
            return null;
        }
        public List<Ticket>? GetTicketByClientName(string name)
        {
            var tickets = _context.Ticket.Where(x => x.Client.Name == name).ToList();
            if (tickets is not null)
            {
                return tickets.Where(x => x.Active == true)?.ToList();
            }
            return null;
        }
        public Ticket GetTicketById(Guid ticketId)
        {
            return _context.Ticket.Where(x => x.TicketId == ticketId).FirstOrDefault();
        }

        public Ticket AddTicket(Ticket ticket)
        {
            _context.Ticket.Add(ticket);
            _context.SaveChanges();
            return ticket;
        }
        public Ticket PutTicket(TicketViewModel ticket, Guid id)
        {
            var oldTicket = GetTicketById(id);
            if (oldTicket is null)
                return null;

            Ticket ticketToEdit = _map.Map<Ticket>(ticket);
            ticketToEdit.TicketId = id;

            try
            {
                _context.Ticket.Update(ticketToEdit);
                _context.SaveChanges();
                return ticketToEdit;
            }
            catch
            {
                throw new Exception("Failed to conect to database");
            }
        }

        public bool DeleteTicket(Guid id)
        {
            var ticket = GetTicketById(id);
            ticket.Active = false;

            try
            {
                _context.Ticket.Update(ticket);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
