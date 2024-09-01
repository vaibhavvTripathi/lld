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
    private Object _lockObject { get; } = new object();
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

    private void HandleNewState(State state)
    {
        this.CurrentState = state;
        Notify();
        Console.WriteLine($"{CurrentState} light is on");
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
        Console.WriteLine($"{CurrentState} light is over");
    }
    public void SetState(State state)
    {
        
            HandleNewState(state);
        
    }
    public void Notify()
    {
        foreach (var observer in Observers)
        {
            observer.Update(CurrentState);
        }
    }
}