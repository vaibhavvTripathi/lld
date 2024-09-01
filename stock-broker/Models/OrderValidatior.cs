using Models.Stock;


namespace Models.Stock;
public class OrderValidator
{
    public bool ValidateOrder(string userId, Order order)
    {
        if (order.TransactionType == TXN_TYPE.BUY)
        {
            Console.WriteLine("Buying the stock");
        }
        else
        {
            Console.WriteLine("Selling the stock");
        }
        Console.WriteLine("Order is validated");
        return true;
    }
}