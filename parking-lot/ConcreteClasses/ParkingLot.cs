using Parking.Models;

public class ParkingLot
{
    private int Id { get; }
    private List<ParkingLevel> ParkingLevels { get; }
    private int TotalLevels { get; set; }

    private static readonly Lazy<ParkingLot> _instance = new System.Lazy<ParkingLot>(() => new ParkingLot(1));

    public static ParkingLot instance => _instance.Value;
    private ParkingLot(int Id)
    {
        this.Id = Id;
        this.ParkingLevels = [];
    }
    public void AddParkingLevel(int car, int truck, int motor)
    {
        ParkingLevels.Add(new ParkingLevel(car, truck, motor, TotalLevels));
        this.TotalLevels++;
    }
    public void AssignSpot(Vehicle vehicle)
    {
        Console.WriteLine($"Searching levels for ${vehicle.Id}..");
        bool parked = false;
        foreach (var pl in ParkingLevels)
        {
            var isParked = pl.AssignSpot(vehicle);
            if (isParked)
            {
                parked = isParked;
                return;
            }
        };
        if (parked)
        {
            // Console.WriteLine("parked");
        }
    }
}