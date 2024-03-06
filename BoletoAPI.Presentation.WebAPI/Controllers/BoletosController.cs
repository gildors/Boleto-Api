using BoletoAPI.Application.Dtos;
using BoletoAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoletoAPI.Apresentation.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoletosController : ControllerBase
    {
        private readonly IBoletoService _boletoService;

        public BoletosController(IBoletoService boletoService)
        {
            _boletoService = boletoService;
        }

        [ProducesResponseType(typeof(DadosBoletoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("gerarHTMLBoleto")]
        public IActionResult GetHTMLBoleto(DadosBoletoDto dadosBoletoDto)
        {
            try
            {
                var gerarHTMLBoleto = _boletoService.GerarHTMLBoleto(dadosBoletoDto);
                return Ok(gerarHTMLBoleto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [ProducesResponseType(typeof(DadosBoletoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("gerarLinhaDigitavel")]
        public IActionResult GetLinhaDigitavelBoleto(DadosBoletoDto dadosBoletoDto)
        {
            try
            {
                var gerarHTMLBoleto = _boletoService.GerarLinhaDigitavelBoleto(dadosBoletoDto);
                return Ok(gerarHTMLBoleto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(DadosRemessaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("gerarRemessa")]
        public IActionResult GetRemessa(DadosRemessaDto dadosRemessaDto)
        {
            try
            {
                var gerarArquivoRemessa = _boletoService.GerarArquivoRemessa(dadosRemessaDto);
                return Ok(gerarArquivoRemessa);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}