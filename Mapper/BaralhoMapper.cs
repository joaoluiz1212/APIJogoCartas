using APIJogoBaralho.Moldes;
using APIJogoBaralho.Moldes.DTO;

namespace APIJogoBaralho.Mapper;

public static class BaralhoMapper
{
    public static BaralhoDTO MapearParaBaralhoDTO(BaralhoResponse baralhoResponse)
    {

        return new BaralhoDTO
        {
            baralhoID = baralhoResponse.deck_id
        };
    }
}
