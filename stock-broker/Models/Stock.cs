
namespace Models.Stock;
public class Stock(EXCHANGE exchangeType, string name, double price)
{
    public EXCHANGE ExchangeType { get; } = exchangeType;
    public string Name { get; } = name;
    public double Price { get; } = price;
}