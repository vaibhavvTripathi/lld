// See https://aka.ms/new-console-template for more information
using System.Collections.Concurrent;
using lift.Models;

Console.WriteLine("Hello, World!");
var e1 = new Elevator(ElevatorState.MOVING_UP, -1, "e1");
var e2 = new Elevator(ElevatorState.MOVING_UP, 0, "e2");
var e3 = new Elevator(ElevatorState.MOVING_UP, 1, "e3");
var simulateElevators = Task.Run(() =>
{
    List<Elevator> elevatorList = [e1,e2,e3];
    Parallel.ForEach(elevatorList, (e) => e.Start());
});

var listenRequests = Task.Run(() =>
{
    List<Elevator> elevatorList = [e1,e2,e3];
    Parallel.ForEach(elevatorList, (e) => e.Listen());
});

var enqueueRequests = Task.Run(() =>
{
    var x = 0;
    while (true)
    {
        Thread.Sleep(500);
        ElevatorSystem.GetInstance().Request(new Request(x, Math.Min(x + 2, 4)));
        ElevatorSystem.GetInstance().Request(new Request(x, Math.Max(x - 2, 0)));
        x = (x + 1) % 4;
    }
});

await Task.WhenAll([simulateElevators, listenRequests, enqueueRequests]);