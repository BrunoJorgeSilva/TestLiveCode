using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestLiveCode.Model;
using TestLiveCode.Service;
using TestLiveCode.ViewModel;

namespace TestLiveCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("GetTickets")]
        public ActionResult<IEnumerable<TicketViewModel>> GetTickets()
        {
            var tickets = _ticketService.GetTickets();
            if(tickets is null) 
            {
                return NotFound("Tickets not found.");
            }
            return Ok(tickets);
        }

        [HttpGet("GetTicketById/{id}")]
        public ActionResult<TicketViewModel> GetTicketById(string id) 
        { 
            if (!Guid.TryParse(id, out Guid guid))
            {
                return BadRequest("Invalid GUID format.");
            }
            var ticket = _ticketService.GetTicketById(guid);

            if (ticket is null)
            {
                return NotFound("Ticket not found by the id informed.");
            }
            return Ok(ticket);
        }

        [HttpGet("GetTicketByClientId/{clientId}")]
        public ActionResult<List<TicketViewModel>> GetTicketsByClientId(string clientId)
        {
            if (!Guid.TryParse(clientId, out Guid guid))
            {
                return BadRequest("Invalid GUID format.");
            }

            var tickets = _ticketService.GetTicketsByClientId(guid); 

            if (tickets is null || tickets.Count() == 0)
            {
                return NotFound("Ticket not found by the id informed.");
            }
            return Ok(tickets);
        }

        [HttpGet("GetTicketByClientName/{name}")]
        public ActionResult<List<TicketViewModel>> GetTicketByClientName(string name)
        {
            var ticket = _ticketService.GetTicketByClientName(name); 

            if (ticket is null)
            {
                return NotFound("Ticket not found by the id informed.");
            }
            return Ok(ticket);
        }

        [HttpPost("AddTicket")]
        public ActionResult<TicketViewModel> AddTicket(Ticket ticket)
        {
            TicketViewModel ticketAdded = _ticketService.AddTicket(ticket);
            if (ticketAdded is null)
            {
                return NotFound("Unexpected Error, it wasn't possible to add this new Ticket");
            }
            return Ok(ticketAdded);
        }

        [HttpPut("PutTicket")]
        public ActionResult<Ticket> PutTicket(TicketViewModel ticket, Guid id)
        {
            var ticketEdited = _ticketService.PutTicket(ticket, id);
            if (ticketEdited is null)
            {
                return NotFound("Ticket not found to be edited");
            }
            return Ok(ticketEdited);
        }
        [HttpDelete("DeleteTicket")]
        public ActionResult<bool> DeleteTicket(Guid id)
        {
            if (_ticketService.DeleteTicket(id))
            {
                return NoContent();
            }
            return NotFound(false);
        }

    }
}
