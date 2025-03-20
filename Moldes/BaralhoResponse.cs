namespace APIJogoBaralho.Moldes;

public class BaralhoResponse
{
    public bool success { get; set; }
    public string deck_id { get; set; }
    public int remaining { get; set; }
    public bool shuffled { get; set; }
    public List<CartaResponse> cards { get; set; }

}
