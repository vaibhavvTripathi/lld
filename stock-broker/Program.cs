// See https://aka.ms/new-console-template for more information
using Models.Stock;


Console.WriteLine("Hello, World!");
var user = new User("nigga"); 
// BrokerSystem.AddUser("niga", user);
var stock = new Stock(EXCHANGE.NSE, "TCS", 100);

var orderValidator = new OrderValidator();
var orderExecutioner = new OrderExecutioner();
var orderManager = new OrderManager(orderValidator, orderExecutioner);
var order = new Order(TXN_TYPE.BUY, ORDER_TYPE.MARKET, 1000, 10, stock);
orderManager.PlaceOrder("niga", order);