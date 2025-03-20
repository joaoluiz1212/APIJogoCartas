using APIJogoBaralho.Moldes.DTO;

namespace APIJogoBaralho.ViewModel;

public class RetornoDistribuicaoDeCartasViewModel
{
    public string NomeJogador { get; set; }
    public List<CartaDTO> Cartas { get; set; }
}
