using lift.Models;

namespace lift.Interfaces;
public interface IObserver {
    void Notify(Elevator elevator);
}