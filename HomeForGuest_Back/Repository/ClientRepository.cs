using HomeForGuest_Back.Interface;
using HomeForGuest_Back.Models;
using Microsoft.CodeAnalysis;
using static HomeForGuest_Back.Repository.ClientRepository;
using TecnicalTest_Back;
using Microsoft.EntityFrameworkCore;

namespace HomeForGuest_Back.Repository
{
    public class ClientRepository : IClient
    {  
        
            private readonly ApplicationContext _context;
            public ClientRepository(ApplicationContext context)
            {
                _context = context;
            }

            public void Delete(int id)
            {
                var client = _context.Clients.SingleOrDefault(c => c.Id == id);
                if (client != null)
                {
                    _context.Clients.Remove(client);
                    _context.SaveChanges();
                }
                else
                {
                    //error
                }

            }

            public Optional<Client> findById(int id)
            {
                Client client = _context.Clients.SingleOrDefault(c => c.Id == id);
                if (client != null)
                {
                    return new Optional<Client>(client);
                }
                return null;


            }

            public async Task<List<Client>> GetClients()
            {
                var clients = await _context.Clients.ToListAsync(); 
                return clients;
            }

            public void put(Client client)
            {
                Client clientModify = _context.Find<Client>(client.Id);
                if (clientModify != null)
                {
                    clientModify.Name = client.Name;
                    clientModify.Surname = client.Surname;
                    clientModify.Photo_Url = client.Photo_Url;
                    _context.SaveChanges();
                }
                else
                {
                    //error
                }

            }

            public void save(Client client)
            {
                _context.Add(client);
                _context.SaveChanges();
            }
      
    }
}
