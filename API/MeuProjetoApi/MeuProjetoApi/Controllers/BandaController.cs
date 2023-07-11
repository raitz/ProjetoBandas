using MeuProjetoApi.BancoDados.Contexto;
using MeuProjetoApi.BancoDados.Repositorios;
using MeuProjetoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace MeuProjetoApi.Controllers
{
    [ApiController]
    public class BandaController : ControllerBase
    {
        public BandaRepositorio Repositorio = new BandaRepositorio();

        [HttpGet]
        [Route("banda/obterTodos")]
        [ProducesResponseType(typeof(List<Banda>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public IActionResult ObterTodos()
        {
            try
            {
                var todasBandas = Repositorio.ObterTodos();
                return Ok(todasBandas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpGet]
        [Route("banda/obterPorNome/{nome}")]
        [ProducesResponseType(typeof(Banda), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public IActionResult ObterPorNome(string nome)
        {
            try
            {
                var banda = Repositorio.ObterPorNome(nome);

                if (banda == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(banda);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpPost]
        [Route("banda/adicionar")]
        [ProducesResponseType(typeof(Banda), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Adicionar([FromBody] Banda banda)
        {
            try
            {
                if (banda == null)
                {
                    return BadRequest("Não foi possível obter a banda");
                }

                Repositorio.Adicionar(banda);

                return Created($"", banda);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpPut]
        [Route("banda/atualizar")]
        [ProducesResponseType(typeof(Banda), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Atualizar([FromBody] Banda banda)
        {
            try
            {
                var bandaAtualizar = Repositorio.ObterPorNome(banda.Nome);

                if (bandaAtualizar == null)
                {
                    return NotFound("Não foi possível encontrar a banda");
                }
                else
                {
                    bandaAtualizar.Nome = banda.Nome;
                    bandaAtualizar.GeneroMusical = banda.GeneroMusical;
                    bandaAtualizar.Descricao = banda.Descricao;
                    bandaAtualizar.Imagem = banda.Imagem;

                    Repositorio.Atualizar(bandaAtualizar);
                    return Ok(bandaAtualizar);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpDelete]
        [Route("banda/excluir/{nome}")]
        [ProducesResponseType(typeof(Nullable), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Excluir(string nome)
        {
            try
            {
                var banda = Repositorio.ObterPorNome(nome);

                if (banda == null)
                {
                    return NotFound("Banda não encontrada");
                }

                Repositorio.Excluir(banda);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }
    }
}
