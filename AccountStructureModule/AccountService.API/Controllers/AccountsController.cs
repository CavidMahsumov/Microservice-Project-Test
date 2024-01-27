using AccountService.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using AccountService.API.Repositories;
namespace AccountService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly PlayerRepository _playerRepository;

        [HttpPost]
        public async Task<IActionResult> Create(PlayerCreateDto playercreatedto)
        {
            _playerRepository.Create(new Entities.Player
            {
                FirstName = playercreatedto.FirstName,
                LastName = playercreatedto.LastName,
                Username = playercreatedto.Username,
            });
            return Created("", "");
        }
            
        [HttpGet]
        public IActionResult Get()
        {
            var repo = new PlayerRepository();
            return Ok();
        }
    }
}
