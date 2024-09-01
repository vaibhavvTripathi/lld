using lift.Interfaces;
namespace lift.Models;
public class Request(int currentFloor, int destFloor) : IRequest
{
    private int CurrentFloor { get; } = currentFloor;
    private int DestinationFloor { get; } = destFloor;

    public int GetCurrentFloor()
    {
        return this.CurrentFloor;
    }

    public int GetDestinationFloor()
    {
        return this.DestinationFloor;

    }
}