using APIJogoBaralho.Mapper;
using APIJogoBaralho.Service;
using APIJogoBaralho.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

namespace APIJogoBaralho.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class JogoApiController : ControllerBase
{
    private readonly ApiClientService _apiClientService;

    public JogoApiController()
    {
        _apiClientService = new ApiClientService();
    }

    [HttpGet]
    [Route("embaralhar-carta")]
    public async Task<IActionResult> EmbaralhareCarta()
    {
        try
        {
            var response = await _apiClientService.CriarBaralhoAsync();

            if( response == null)
            {
                return NotFound("Não houve retorno na requisição.");
            }

            var retornoBaralho = BaralhoMapper.MapearParaBaralhoDTO(response);

            return Ok(retornoBaralho);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("distribuir-cartas")]
    [ResponseType(typeof(RetornoDistribuicaoDeCartasViewModel))]
    public async Task<IActionResult> DistribuirCartasPorJogador([FromBody] EnvioDistribuicaoDeCartasViewModel envioDistribuicaoDeCartas)
    {
        try
        {
            var retornoDistribuicaoDeCartaPorJogador = await _apiClientService.DistribuirCartasAsync(baralhoID: envioDistribuicaoDeCartas.idBaralho, 
               quantidadeDeJogador: envioDistribuicaoDeCartas.quantidadeDeJogadores);

            if (retornoDistribuicaoDeCartaPorJogador == null)
            {
                return NotFound("Não foi possível distribuir cartas ao jogadores.");
            }

            return Ok(retornoDistribuicaoDeCartaPorJogador);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("devolver-cartas-ao-baralho")]
    public async Task<IActionResult> DevolverCartasAoBaralho(string baralhoId)
    {
        try
        {
            await _apiClientService.DevolverCartasAsync(baralhoID: baralhoId);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

