namespace StateMachine.Oops.Interfaces;

public interface IStateMachineRuntime<TState, TEvent>
    where TState : struct
    where TEvent : struct
{
    public IEntity<TState> Execute(IEntity<TState> entity, TEvent message);
}