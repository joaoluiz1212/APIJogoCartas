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
        _apiClientService = new ApiClientService(new HttpClient());
    }

    [HttpGet]
    [Route("embaralhar-carta")]
    public async Task<IActionResult> EmbaralhareCarta()
    {
        var response = await _apiClientService.CriarBaralhoAsync();

        var retornoBaralho = BaralhoMapper.MapearParaBaralhoDTO(response);

        return Ok(retornoBaralho);
    }

    [HttpPost]
    [Route("distribuir-cartas")]
    [ResponseType(typeof(RetornoDistribuicaoDeCartasViewModel))]
    public async Task<IActionResult> DistribuirCartasPorJogador([FromBody] EnvioDistribuicaoDeCartasViewModel envioDistribuicaoDeCartas)
    {
        var retornoDistribuicaoDeCartaPorJogador = await _apiClientService.DistribuirCartasAsync(envioDistribuicaoDeCartas.idBaralho, envioDistribuicaoDeCartas.quantidadeDeJogadores);

        return Ok(retornoDistribuicaoDeCartaPorJogador);
    }
}

