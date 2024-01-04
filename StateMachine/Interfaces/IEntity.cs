namespace StateMachine.Interfaces;

public interface IEntity<TState> where TState : struct
{
    public TState CurrentState { get; set; }
}