namespace StateMachine.Oops.Interfaces;

public interface ICommand<TState, TEvent>
    where TState : struct
    where TEvent : struct
{
    bool Execute(IEntity<TState> entity, TEvent @event);
    public bool IsValid(IEntity<TState> entity, TEvent @event);
}