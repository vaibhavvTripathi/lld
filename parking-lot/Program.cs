// See https://aka.ms/new-console-template for more information
using Parking.Models;

Console.WriteLine("Hello, World!");
var parkingLot = ParkingLot.instance;
parkingLot.AddParkingLevel(0, 2, 2);
parkingLot.AddParkingLevel(0, 4, 5);
var a = VehicleFactory.Create(VehicleType.CAR);
var b = VehicleFactory.Create(VehicleType.CAR);
var c = VehicleFactory.Create(VehicleType.CAR);
var d = VehicleFactory.Create(VehicleType.CAR);

var vehicles = new List<Vehicle>
{
    VehicleFactory.Create(VehicleType.CAR),
    VehicleFactory.Create(VehicleType.CAR),
    VehicleFactory.Create(VehicleType.CAR),
    VehicleFactory.Create(VehicleType.CAR)
};

// Create a list to hold the tasks
var tasks = new List<Task>();

// Assign spots to each vehicle in parallel
foreach (var vehicle in vehicles)
{
    tasks.Add(Task.Run(() => parkingLot.AssignSpot(vehicle)));
}

// Wait for all tasks to complete
await Task.WhenAll(tasks);