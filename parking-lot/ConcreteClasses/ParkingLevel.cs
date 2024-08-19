using Parking.Models;

public class ParkingLevel
{
    public int Id { get; }
    private List<ParkingSpot> ParkingSpots { get; }

    public ParkingLevel(int carSports, int truckSports, int motorCycleSports, int id)
    {
        this.ParkingSpots = [];
        this.Id = id;
        for (int i = 0; i < carSports; i++)
        {
            ParkingSpots.Add(new ParkingSpot(i, VehicleType.CAR));
        }
        for (int i = 0; i < truckSports; i++)
        {
            ParkingSpots.Add(new ParkingSpot(i + carSports, VehicleType.TRUCK));
        }
        for (int i = 0; i < motorCycleSports; i++)
        {
            ParkingSpots.Add(new ParkingSpot(i + carSports + truckSports, VehicleType.MOTORCYCLE));
        }
    }
    public bool AssignSpot(Vehicle vehicle)
    {
        // Console.WriteLine($"Searching spots for ${vehicle.Id}..");
        bool isParked = false;
        foreach (var ps in ParkingSpots)
        {
            // Console.WriteLine($"Checking in {ps.Id}");
            var parked = ps.ParkVehicle(vehicle);
            // Console.WriteLine($"{parked} is the status at {ps.Id}");

            if (parked)
            {
                Console.WriteLine($"${vehicle.Id} is parked at ${ps.Id} at {Id}");
                isParked = true;
                break; // Exit the loop once parked
            }
        }

        return isParked;
    }
    public void RemoveSpots(Vehicle vehicle)
    {
        var spot = ParkingSpots.Find(ps => ps.Vehicle.Equals(vehicle));
        spot.RemoveVehicle();
    }
}