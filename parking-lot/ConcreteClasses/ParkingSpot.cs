using Parking.Models;

namespace Parking.Models;
public class ParkingSpot
{
    public int Id { get; }
    private VehicleType vehicleType { get; }
    public Vehicle? Vehicle;
    private readonly object _lockObject = new object();

    public ParkingSpot(int id, VehicleType vehicleType)
    {
        this.Id = id;
        this.vehicleType = vehicleType;
    }

    private bool IsAvailable()
    {
        return this.Vehicle == null;
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        // Console.WriteLine($"Waiting for lock ${vehicle.Id} at {Id}..");

        lock (_lockObject)
        {
            // Console.WriteLine($"Checking if spot is available ${vehicle.Id}..");
            if (IsAvailable() && vehicle.VehicleType == vehicleType) { this.Vehicle = vehicle; return true; }
            return false;
        }
    }
    public void RemoveVehicle()
    {
        lock (_lockObject)
        {
            Thread.Sleep(10000);
            this.Vehicle = null;
        }
    }

}