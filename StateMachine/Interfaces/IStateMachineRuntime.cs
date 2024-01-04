namespace StateMachine.Interfaces;

public interface IStateMachineRuntime<TState, TEvent>
    where TState : struct
    where TEvent : struct
{
    public Entity<TState> Execute(Entity<TState> entity, TEvent message);
}