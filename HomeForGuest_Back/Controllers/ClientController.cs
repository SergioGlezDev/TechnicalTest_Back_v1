using HomeForGuest_Back.Interface;
using HomeForGuest_Back.Models;
using HomeForGuest_Back.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace HomeForGuest_Back.Controllers
{
    [ApiController]
    [Route("api/v1/Client")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        private readonly IClient _clientRepository;

        public ClientController(ILogger<ClientController> logger, IClient clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }

        [HttpGet(template: "AllClient", Name = "AllClient")]
        [Authorize]
        public async Task<IEnumerable<Client>> Get()
        {
            var clients = await _clientRepository.GetClients();
            return clients;
        }
        [HttpGet("ClientById/{id}")]
        public Optional<Client> GetClientId(int id)
        {
            return _clientRepository.findById(id);
        }
        [HttpPost("SaveClient")]
        [Authorize(Roles = "admin")]
        public void Post([FromBody] Client client)
        {
            _clientRepository.save(client);
        }
        [HttpPut("EditClient")]
        public void Put([FromBody] Client client)
        {
            _clientRepository.put(client);
        }
        [HttpDelete("DeleteClient")]
        public void Delete(int id)
        {
            _clientRepository.Delete(id);
        }
    }
}
