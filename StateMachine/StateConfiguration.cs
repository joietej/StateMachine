using StateMachine.Interfaces;

namespace StateMachine;

public class StateConfiguration<TState, TEvent> : IStateConfiguration<TState, TEvent>
    where TState : struct
    where TEvent : struct
{
    private List<StateTransition<TState, TEvent>> _transitions = new();

    public IReadOnlyCollection<StateTransition<TState, TEvent>> Transitions => _transitions.AsReadOnly();

    public void Add(TState from, TEvent @event, TState to, bool isFirst = false,
        bool isLast = false)
    {
        _transitions.Add(new StateTransition<TState, TEvent>(from, to, @event, isFirst, isLast));
    }
}