using Models.Stock;

namespace Models.Stock;

public class OrderManager(OrderValidator orderValidator, OrderExecutioner orderExecutioner)
{
    private readonly OrderValidator _orderValidator = orderValidator;
    private readonly OrderExecutioner _orderExecutioner = orderExecutioner;

    public void PlaceOrder(string userId,Order order) {
        if(_orderValidator.ValidateOrder(userId,order)) {
             _orderExecutioner.Placeorder(userId,order);
        }
    }
}