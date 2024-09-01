using Models.Stock;


namespace Models.Stock;
public sealed class ExchangeConnector
{

    private static readonly Lazy<ExchangeConnector> instance = new Lazy<ExchangeConnector>(() => new ExchangeConnector());
    private ExchangeConnector()
    {

    }
    public static ExchangeConnector GetInstance()
    {
        return instance.Value;
    }
    public void SendOrderToExchage(string userId,Order order) {
      Console.WriteLine("Sending order to exchange");
    }
}