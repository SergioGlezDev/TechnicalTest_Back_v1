using HomeForGuest_Back.Models;
using Microsoft.CodeAnalysis;

namespace HomeForGuest_Back.Interface
{
    public interface IClient
    {
        Task<List<Client>> GetClients();
        Optional<Client> findById(int id);
        void save(Client client);
        void put(Client client);
        void Delete(int id);
    }
}
