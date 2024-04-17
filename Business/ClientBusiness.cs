using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using TestLiveCode.Context;
using TestLiveCode.Model;
using TestLiveCode.ViewModel;

namespace TestLiveCode.Business
{
    public class ClientBusiness : IClientBusiness
    {
        private readonly DbContextExample _context;
        private readonly IMapper _map;

        public ClientBusiness(DbContextExample context, IMapper map)
        {
            _context = context;
            _map = map;
        }
        public List<Client> GetClients()
        {
            return _context.Client.Where(x => x.Active == true).ToList();
        }

        public Client GetClientById(Guid id)
        {
            return _context.Client.Include(x => x.Tickets).Where(x => x.ClientId == id).FirstOrDefault();
        }

        public Client GetClientByName(string name)
        {
            return _context.Client.Include(x => x.Tickets).Where(x => x.Name == name).FirstOrDefault();
        }

        
        public Client PostNewClient(Client client)
        {
            Client newClient = client;
            
            try
            {
               _context.Client.Add(newClient);
               _context.SaveChanges();
            }
            catch 
            {
                return null;
            }
            return newClient;
        }

        public Client PutClient(ClientViewModel client, Guid id)
        {
            var oldClient = GetClientById(id);
            if (oldClient == null)
                return null;

            Client clientToEdit = new Client()
            {
                ClientId = id,
                Name = client.Name,
                IsTop500 = client.IsTop500,
                DateAdded = client.DateAdded,
                TasksToBeDone = client.TasksToBeDone,
                TasksDone = client.TasksDone,
                Active = client.Active,
            };

            try
            {
                _context.Client.Update(clientToEdit);
                _context.SaveChanges();
                return clientToEdit;
            }
            catch
            {
                throw new Exception("Failed to conect to database");
            }
        }
        public bool DeleteClient(Guid id)
        {
            var client = GetClientById(id);
            if(client is null)
            {
                return false;
            }
            client.Active = false;

            try
            {
                _context.Client.Update(client);
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
