using lift.Interfaces;

namespace lift.Models;
public class Elevator(ElevatorState state, int currentFloor, string id)
{
    private string Id { get; } = id;
    private HashSet<int> UpRequests { get; } = [];
    private HashSet<int> DownRequests { get; } = [];
    public ElevatorState ElevatorState { get; private set; } = state;
    public int CurrentFloor { get; private set; } = Math.Min(Math.Max(currentFloor, -1), MAX_FLOOR - 1);
    private readonly ElevatorSystem elevatorSystem = ElevatorSystem.GetInstance();

    private const int MAX_FLOOR = 10;

    public void SetState(ElevatorState state)
    {
        this.ElevatorState = state;
    }
    public void SetCurrentFloor(int currentFloor)
    {
        this.CurrentFloor = currentFloor;
    }
    public void AddRequest(int floor)
    {
        UpRequests.Add(floor);
    }
    public void Open()
    {
        Thread.Sleep(500);
        // Console.WriteLine($"Elevator {this.Id} opening doors");
    }
    public void Close()
    {
        Thread.Sleep(500);
        // Console.WriteLine($"Elevator {this.Id} closing doors");
    }

    public void Listen()
    {
        while (ElevatorState != ElevatorState.NOT_WORKING)
        {
            Thread.Sleep(100);
            if (ElevatorState == ElevatorState.MOVING_UP)
            {
                var requests = elevatorSystem.ProcessMovingUpMap(this.CurrentFloor + 1);
                // Console.WriteLine(requests.Count);
                requests.ForEach(r =>
                {
                    // Console.WriteLine($"{r.GetCurrentFloor()} has requested {r.GetDestinationFloor()}");
                    this.UpRequests.Add(r.GetCurrentFloor());
                    this.UpRequests.Add(r.GetDestinationFloor());
                });
            }
            else
            {
                var requests = elevatorSystem.ProcessMovingDownMap(this.CurrentFloor - 1);
                requests.ForEach(r =>
                {
                    // Console.WriteLine($"{r.GetCurrentFloor()} has requested {r.GetDestinationFloor()}");
                    this.DownRequests.Add(r.GetCurrentFloor());
                    this.DownRequests.Add(r.GetDestinationFloor());
                });
            }
        }
    }

    public void Start()
    {
        while (ElevatorState != ElevatorState.NOT_WORKING)
        {
            if (this.UpRequests.Contains(this.CurrentFloor) && this.ElevatorState == ElevatorState.MOVING_UP)
            {
                this.UpRequests.Remove(this.CurrentFloor);
                Console.WriteLine($"Elevator {this.Id} is opening doors at floor {this.CurrentFloor} {this.ElevatorState}");
                Open();
                Console.WriteLine($"Elevator {this.Id} is closing doors at floor {this.CurrentFloor} {this.ElevatorState}");
                Close();

            }
            if (this.DownRequests.Contains(this.CurrentFloor) && this.ElevatorState == ElevatorState.MOVING_DOWN)
            {
                this.DownRequests.Remove(this.CurrentFloor);
                Console.WriteLine($"Elevator {this.Id} is opening doors at floor {this.CurrentFloor} {this.ElevatorState}");
                Open();
                Console.WriteLine($"Elevator {this.Id} is closing doors at floor {this.CurrentFloor} {this.ElevatorState}");
                Close();

            }
            Console.WriteLine($"Elevator {this.Id} is now on {this.CurrentFloor} moving {this.ElevatorState}");
            Thread.Sleep(2000);
            var floor = this.CurrentFloor;
            if (ElevatorState == ElevatorState.MOVING_DOWN)
            {
                floor--;
                if (floor < 0)
                {
                    floor += 2;
                    this.ElevatorState = ElevatorState.MOVING_UP;

                }
                this.CurrentFloor = floor;
            }
            else if (ElevatorState == ElevatorState.MOVING_UP)
            {
                floor++;
                if (floor > MAX_FLOOR - 1)
                {
                    floor -= 2;
                    this.ElevatorState = ElevatorState.MOVING_DOWN;

                }
                this.CurrentFloor = floor;
            }
        }
    }
    public void Stop()
    {
        this.ElevatorState = ElevatorState.NOT_WORKING;
    }
}

public enum ElevatorState
{
    MOVING_UP,
    MOVING_DOWN,
    NOT_WORKING
}