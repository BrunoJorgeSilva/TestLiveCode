using TestLiveCode.Model;
using TestLiveCode.ViewModel;

namespace TestLiveCode.Service
{
    public interface IClientService
    {
        public List<ClientViewModel> GetClients();
        public ClientViewModel GetClientById(Guid id);
        public ClientViewModel GetClientByName(string id);
        public ClientViewModel PostNewClient(ClientViewModel client);
        public ClientViewModel PutClient(ClientViewModel client, Guid id);
        public bool DeleteClient(Guid id);
    }
}
