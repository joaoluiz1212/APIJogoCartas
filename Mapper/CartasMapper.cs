using APIJogoBaralho.Moldes.DTO;
using APIJogoBaralho.Moldes;

namespace APIJogoBaralho.Mapper;

public static class CartasMapper
{
    public static List<CartaDTO> MapearParaCartaDTO(List<CartaResponse> cartas)
    {

        return cartas.Select(t => new CartaDTO
        {
            Codigo = t.code,
            ImagemCarta = t.image,
            ValorCarta = t.value,
            Naipe = t.suit
        }).ToList();
    }
}

