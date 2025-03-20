using APIJogoBaralho.Mapper;
using APIJogoBaralho.Moldes;
using APIJogoBaralho.Moldes.DTO;
using System.Text.Json;

namespace APIJogoBaralho.Service;

public class ApiClientService
{
    private readonly HttpClient _httpClient;
    private const string _baseUrl = "https://deckofcardsapi.com/api/deck/";

    public ApiClientService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient)); ;
    }

    public async Task<BaralhoResponse> CriarBaralhoAsync()
    {
        return await ObterRequisicaoAsync<BaralhoResponse>($"{_baseUrl}new/shuffle/?deck_count=1");
    }

    public async Task<List<JogadorDTO>> DistribuirCartasAsync(string baralhoID, int quantidadeDeJogador)
    {

        var jogadores = new List<JogadorDTO>();
        for (int i = 1; i <= quantidadeDeJogador; i++)
        {
            var baralho = await ObterRequisicaoAsync<BaralhoResponse>($"{_baseUrl}{baralhoID}/draw/?count=5");

            var cartasDTO = CartasMapper.MapearParaCartaDTO(baralho.cards);

            jogadores.Add(CriarJogador(i, cartasDTO));
        }

        return jogadores;
    }

    public async Task DevolverCartasAsync(string baralhoID)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}{baralhoID}/return/");
        response.EnsureSuccessStatusCode();
    }

    private async Task<T> ObterRequisicaoAsync<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content);
    }

    private JogadorDTO CriarJogador(int numeroJogador, List<CartaDTO> carta)
    {
        return new JogadorDTO
        {
            NomeJogador = $"Jogador {numeroJogador}",
            Cartas = carta
        };
    }
}
