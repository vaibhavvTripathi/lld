namespace Traffic.Interfaces;
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
    void HandleEmergency();
}