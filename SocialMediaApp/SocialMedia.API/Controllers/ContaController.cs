﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("Cadastro")]
        public IActionResult Cadastro(CreateContaInputModel model)
        {
            var result = _contaService.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _contaService.GetById(id);

            if (!result.IsSuccess)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("BuscarPorEmail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            var result = _contaService.GetByEmail(email);

            if (!result.IsSuccess)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(int id, UpdateContaInputModel model)
        {
            var result = _contaService.Update(id, model);

            if (!result.IsSuccess)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _contaService.Delete(id);

            if (!result.IsSuccess)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("MudarSenha/{email}")]
        public IActionResult MudarSenha(string email, UpdateSenhaContaInputModel model)
        {
            var result = _contaService.MudarSenha(email, model);

            if (!result.IsSuccess)
            {
                return NotFound();
            }

            return Ok(result);
        }
}
}
