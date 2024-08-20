using Traffic.Models;
namespace Traffic.Interfaces;
public interface IObserver
{
    void Update(State state);
    void AttachSubject(ISubject subject);
    void DetachSubject();
}

