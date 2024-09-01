using System.Collections.Generic;
using System.Collections.Concurrent;
using lift.Interfaces;

namespace lift.Models;

public sealed class ElevatorSystem
{
    private ConcurrentDictionary<int, List<IRequest>> MovingUpMap { get; } = new();
    private ConcurrentDictionary<int, List<IRequest>> MovingDownMap { get; } = new();

    private ElevatorSystem()
    {
    }
    private static readonly Lazy<ElevatorSystem> elevatorSystem = new(() => new());

    public static ElevatorSystem GetInstance()
    {
        return elevatorSystem.Value;
    }
    public void Request(IRequest request)
    {
        var sourceFloor = request.GetCurrentFloor();
        var destFloor = request.GetDestinationFloor();
        if (destFloor > sourceFloor)
        {
            MovingUpMap.GetValueOrDefault(sourceFloor, []).Add(request);
            // Console.WriteLine("moving up req served--"+MovingUpMap.Count+"-"+sourceFloor);
        }
        else
        {
            MovingDownMap.GetValueOrDefault(sourceFloor, []).Add(request);
        }
    }
    public List<IRequest> ProcessMovingUpMap(int floor)
    {
        var requests = MovingUpMap.GetValueOrDefault(floor, []);
        MovingUpMap[floor] = [];
        return requests;
    }
    public List<IRequest> ProcessMovingDownMap(int floor)
    {
        var requests = MovingDownMap.GetValueOrDefault(floor, []);
        MovingDownMap[floor] = [];
        return requests;
    }
}