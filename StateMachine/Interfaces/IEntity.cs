namespace StateMachine.Interfaces;

public interface IEntity<TState> where TState : struct
{
    public TState CurrentState { get; }
}

public abstract record Entity<TState>(TState CurrentState) : IEntity<TState> where TState : struct;