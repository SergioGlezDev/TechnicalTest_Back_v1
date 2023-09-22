using HomeForGuest_Back.Models;
using Microsoft.CodeAnalysis;

namespace HomeForGuest_Back.Interface
{
    public interface IUser
    {
        Optional<User> findById(int id);
        void save(User user);
        void put(User user);
        void delete(User user);
    }
}
