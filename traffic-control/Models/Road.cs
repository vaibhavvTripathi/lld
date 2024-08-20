using Traffic.Interfaces;

namespace Traffic.Models;
public class Road : IObserver
{
    private string Id { get; } = Guid.NewGuid().ToString();
    public State CurrentState { get; private set; } = State.RED;

    public ISubject? Subject { get; private set; }

    public void Update(State state)
    {
        this.CurrentState = state;
        Console.WriteLine($"{Id} road is seeing {state} signal");
    }

    public void AttachSubject(ISubject subject)
    {
        this.Subject = subject;
    }
    public void DetachSubject()
    {
        this.Subject = null;
    }
    public void HandleEmergency()
    {
        if (this.Subject == null) return;
        this.Subject.HandleEmergency();
    }
}