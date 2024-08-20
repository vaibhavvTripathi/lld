namespace Traffic.Models;
public enum State
{
    RED = 0,
    GREEN = 1,
    YELLOW = 2
}
public abstract class Signal(State state, int duration)
{
    public State State { get; } = state;
    public int Duration { get; } = duration;
}
public class RedSignal(int duration) : Signal(State.RED, duration)
{
}
public class GreenSignal(int duration) : Signal(State.GREEN, duration)
{
}
public class YellowSignal(int duration) : Signal(State.YELLOW, duration)
{
}