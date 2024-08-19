namespace Parking.Models;
public enum VehicleType
{
    CAR = 0,
    MOTORCYCLE = 1,
    TRUCK = 2
}

public abstract class Vehicle
{
    public VehicleType VehicleType { get; }
    public string Id { get; } = Guid.NewGuid().ToString();
    public Vehicle(VehicleType vehicleType)
    {
        this.VehicleType = vehicleType;
    }
}

public class Car : Vehicle
{
    public Car() : base(VehicleType.CAR) { }
}

public class Truck : Vehicle
{
    public Truck() : base(VehicleType.TRUCK) { }
}
public class MotorCycle : Vehicle
{
    public MotorCycle() : base(VehicleType.MOTORCYCLE) { }
}

public static class VehicleFactory
{
    public static Vehicle Create(VehicleType vehicleType)
    {
        return vehicleType switch
        {
            VehicleType.CAR => new Car(),
            VehicleType.MOTORCYCLE => new MotorCycle(),
            VehicleType.TRUCK => new Truck(),
            _ => throw new ArgumentException("Invalid vehicle type")
        };
    }
}