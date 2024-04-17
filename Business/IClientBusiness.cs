using TestLiveCode.Model;
using TestLiveCode.ViewModel;

namespace TestLiveCode.Business
{
    public interface IClientBusiness
    {
        public List<Client> GetClients();
        public Client GetClientById(Guid id);
        public Client GetClientByName(string id);
        public Client PostNewClient(Client client);
        public Client PutClient(ClientViewModel client, Guid id);
        public bool DeleteClient(Guid id);
    }
}
