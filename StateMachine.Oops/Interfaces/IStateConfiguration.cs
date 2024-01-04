namespace StateMachine.Oops.Interfaces;

public interface IStateConfiguration<TState, TEvent>
    where TState : struct
    where TEvent : struct
{
    public IReadOnlyCollection<StateTransition<TState, TEvent>> Transitions { get; }
}