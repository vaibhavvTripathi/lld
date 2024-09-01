using Models.Stock;

namespace Models.Stock;
public class Order
{
    public TXN_TYPE TransactionType { get; }
    public ORDER_TYPE OrderType { get; }
    public double Price { get; }
    public int Quantity { get; }
    public Stock Stock {get;}
    public Order(TXN_TYPE transactionType,ORDER_TYPE orderType, double price, int quantity, Stock stock)
    {
      this.TransactionType = transactionType;
      this.OrderType = orderType;
      this.Price = price;
      this.Quantity = quantity;
      this.Stock = stock;   
    }
}