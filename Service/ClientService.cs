using AutoMapper;
using TestLiveCode.Business;
using TestLiveCode.Model;
using TestLiveCode.ViewModel;

namespace TestLiveCode.Service
{
    public class ClientService : IClientService
    {
        IClientBusiness _clientBusiness;
        IMapper _map;

        public ClientService(IClientBusiness clientBusiness, IMapper map)
        {
            _clientBusiness = clientBusiness;
            _map = map;
        }
        public List<ClientViewModel> GetClients()
        {
            return _map.Map<List<ClientViewModel>>(_clientBusiness.GetClients());
        }

        public ClientViewModel GetClientById(Guid id)
        {
            return _map.Map<ClientViewModel>(_clientBusiness.GetClientById(id));
        }

        public ClientViewModel GetClientByName(string id)
        {
            return _map.Map<ClientViewModel>(_clientBusiness.GetClientByName(id));
        }

        public ClientViewModel PostNewClient(ClientViewModel client)
        {
            Client newClient = _map.Map<Client>(client);
            return _map.Map<ClientViewModel>(_clientBusiness.PostNewClient(newClient));
        }

        public ClientViewModel PutClient(ClientViewModel client, Guid id)
        {
            return _map.Map<ClientViewModel>(client);
        }
        public bool DeleteClient(Guid id)
        {
            return _clientBusiness.DeleteClient(id);
        }
    }
}
