using Traffic.Interfaces;
using Traffic.Models;
namespace Traffic.Interfaces;
public class TrafficLight : ISubject
{
    private List<IObserver> Observers { get; set; } = [];
    private State CurrentState { get; set; }
    private RedSignal RedSignal { get; set; }
    private GreenSignal GreenSignal { get; set; }
    private YellowSignal YellowSignal { get; set; }
    public TrafficLight(int red, int yellow, int green, State initalState)
    {
        this.RedSignal = new RedSignal(red);
        this.GreenSignal = new GreenSignal(green);
        this.YellowSignal = new YellowSignal(yellow);
        this.CurrentState = initalState;
        Notify();
    }

    public void HandleEmergency()
    {
        Console.WriteLine("Emergency mode !!");
        SetState(State.GREEN);
        Notify();
    }
    public void Attach(IObserver observer)
    {
        this.Observers.Add(observer);
        observer.AttachSubject(this);
    }

    public void Detach(IObserver observer)
    {
        this.Observers.Remove(observer);
        observer.DetachSubject();
    }

    public void SetState(State state)
    {

        this.CurrentState = state;
        Notify();
        if (this.CurrentState == State.GREEN)
        {
            Thread.Sleep(GreenSignal.Duration);
        }
        else if (this.CurrentState == State.YELLOW)
        {
            Thread.Sleep(YellowSignal.Duration);
        }
        else if (this.CurrentState == State.RED)
        {
            Thread.Sleep(RedSignal.Duration);
        }
    }
    public void Notify()
    {
        foreach (var observer in Observers)
        {
            observer.Update(CurrentState);
        }
    }
}