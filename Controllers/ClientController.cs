using Microsoft.AspNetCore.Mvc;
using TestLiveCode.Model;
using TestLiveCode.Service;
using TestLiveCode.ViewModel;

namespace TestLiveCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("GetClients")]
        public ActionResult<IEnumerable<ClientViewModel>> GetClients()
        {
            var clients = _clientService.GetClients();
            if (clients is null || clients.Count == 0)
            {
                return NotFound("Clients not found.");
            }
            return Ok(clients);
        }

        [HttpGet("GetClientById/{id}", Name = "GetClientById")]
        public ActionResult<Client> GetClientById(string id)
        {
            if (!Guid.TryParse(id, out Guid guid))
            {
                return BadRequest("Invalid GUID format.");
            }

            var client = _clientService.GetClientById(guid);
            if (client is null)
            {
                return NotFound("Client not found by this Id");
            }
            return Ok(client);
        }

        [HttpGet("GetClientByName/{name}", Name = "GetClientByName")]
        public ActionResult<Client> GetClientByName(string name)
        {
            
            var client = _clientService.GetClientByName(name);
            if (client is null)
            {
                return NotFound("Client not found by this name");
            }
            return Ok(client);
        }

        [HttpPost("PostNewClient")]
        public ActionResult<ClientViewModel> PostNewClient(ClientViewModel client)
        {
            var newClient = _clientService.PostNewClient(client);
            if (newClient is null)
            {
                return NotFound("Unexpected Error, It wasn't possible to add this new Client");
            }
            return Ok(newClient);
        }

        [HttpPut("PutClient")]
        public ActionResult<ClientViewModel> PutClient(ClientViewModel client, Guid id)
        {
            var editedClient = _clientService.PutClient(client, id);

            if (editedClient is null)
                return NotFound("Client not found to be edited.");

            return Ok(editedClient);
        }

        [HttpDelete (Name = "DeleteClient")]
        public ActionResult<bool> DeleteClient(Guid id)
        {
            if (_clientService.DeleteClient(id))
                return NoContent();

            return NotFound(false);
        }
        
    }
}
