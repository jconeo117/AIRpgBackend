using AiRpgBackend.Interfaces;
using AiRpgBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AiRpgBackend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CampaingController : ControllerBase
    {

        private readonly IGameManagerService _gameManager;

        public CampaingController(IGameManagerService gameManager)
        {
            _gameManager = gameManager;
        }

        [HttpPost("start")]
        public async Task<IActionResult> Start([FromBody] playerRequest request)
        {
            var response = await _gameManager.ProccesPlayerAction(request.ActionText);

            return Ok(response);
        }
    }


    public class playerRequest
    {
        public string PlayerId { get; set; } = "player1";
        public string ActionText { get; set; }
    }
}