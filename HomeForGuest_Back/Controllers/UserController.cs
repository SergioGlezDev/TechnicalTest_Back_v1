using HomeForGuest_Back.Interface;
using HomeForGuest_Back.Models;
using HomeForGuest_Back.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace HomeForGuest_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly IUser _userRepository;

        public UserController(ILogger<UserController> logger, IUser userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        [HttpGet("AllUser")]
        public IEnumerable<User> Get()
        {
            var userList = new List<User>();
            return userList;
        }

        [HttpGet("UserById/{id}")]
        public Optional<User> GetById(int id)
        {
            return _userRepository.findById(id);
        }

        [HttpPost("SaveUser")]
        public void Post(User user)
        {
            _userRepository.save(user);
        }

        [HttpPut("EditUser")]
        public void Put(User user)
        {
            _userRepository.put(user);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("DeleteUser")]
        public void Delete(User user)
        {
            _userRepository.delete(user);
        }
    }
}

