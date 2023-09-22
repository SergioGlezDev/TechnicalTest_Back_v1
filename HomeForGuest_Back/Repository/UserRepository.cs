using HomeForGuest_Back.Interface;
using HomeForGuest_Back.Models;
using Microsoft.CodeAnalysis;
using TecnicalTest_Back;

namespace HomeForGuest_Back.Repository
{
    public class UserRepository : IUser
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void delete(User user)
        {
            _context.Remove(user);
        }

        public Optional<User> findById(int id)
        {
            return _context.Find<User>(id);
        }

        public void put(User user)
        {
            User userModify = _context.Find<User>(user.Username);
            if (userModify != null)
            {
                userModify.Username = user.Username;
                userModify.Email = user.Email;
                userModify.Password = user.Password;
                _context.SaveChanges();
            }
            else
            {
                //Devolver 
            }
        }

        public void save(User user)
        {
            _context.Add(user);
        }
    }
}

