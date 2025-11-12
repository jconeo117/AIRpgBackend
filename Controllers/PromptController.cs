using AiRpgBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AiRpgBackend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CampaingController : ControllerBase
    {

        private readonly NarrativeComposerService narrativeComposerService;

        public CampaingController(NarrativeComposerService narrativeComposer)
        {
            narrativeComposerService = narrativeComposer;
        }

        [HttpPost("start")]
        public async Task<IActionResult> Start([FromBody] playerRequest request)
        {

        }
    }


    public class playerRequest
    {
        public string PlayerId { get; set; } = "player1";
        public string ActionText { get; set; }
    }
}