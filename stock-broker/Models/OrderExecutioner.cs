using Models.Stock;

namespace Models.Stock;

public class OrderExecutioner
{

    public void Placeorder(string userId, Order order)
    {
        var exchangeConnector = ExchangeConnector.GetInstance();
        exchangeConnector.SendOrderToExchage(userId, order);
    }
}