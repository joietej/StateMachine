namespace StateMachine.Oops;

public class StateTransition<TState, TEvent> where TState : struct
    where TEvent : struct
{
    public StateTransition(TState from,
        TState to,
        TEvent @event,
        bool isFirst = false,
        bool isLast = false)
    {
        this.From = from;
        this.To = to;
        this.Event = @event;
        this.IsFirst = isFirst;
        this.IsLast = isLast;
    }

    public TState From { get; }
    public TState To { get; }
    public TEvent Event { get; }
    public bool IsFirst { get; }
    public bool IsLast { get; }
}