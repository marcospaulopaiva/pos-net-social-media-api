using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Services.Feeds;

namespace SocialMedia.API.Controllers
{
    [Route("api/feeds")]
    [ApiController]
    public class FeedController : Controller
    {
        private readonly IFeedService _feedService;

        public FeedController(IFeedService feedService)
        {
            _feedService = feedService;
        }

        [HttpGet("Listagem/{idPerfil}")]
        public IActionResult ObterFeed(int idPerfil)
        {
            var result = _feedService.GetAll(idPerfil);

            return Ok(result);
        }
    }
}
