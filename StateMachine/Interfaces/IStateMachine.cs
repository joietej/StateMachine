namespace StateMachine.Interfaces;

public interface IStateMachine<TState, TEvent>
    where TState : struct
    where TEvent : struct
{
    public TState Current { get; }
    public void MoveNext(StateTransition<TState, TEvent> transition);
    public StateTransition<TState, TEvent>? GetNext(TEvent message);
}