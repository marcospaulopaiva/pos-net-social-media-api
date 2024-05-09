using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Models.Contas;
using SocialMedia.Application.Services;

namespace SocialMedia.API.Controllers
{
    [Route("api/contas")]
    [ApiController]
    public class ContaController : Controller
    {
        private readonly IContaService _contaService;

        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpPost]
        public IActionResult Post(CreateContaInputModel model)
        {
            var result = _contaService.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _contaService.GetById(id);

            if (!result.IsSuccess)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateContaInputModel model)
        {
            var result = _contaService.Update(id, model);

            if (!result.IsSuccess)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _contaService.Delete(id);

            if (!result.IsSuccess)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
