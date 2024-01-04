using StateMachine.Interfaces;

namespace StateMachine;

public class StateMachine<TState, TEvent> : IStateMachine<TState, TEvent>
    where TState : struct
    where TEvent : struct
{
    public StateMachine(IStateConfiguration<TState, TEvent> config)
    {
        Transitions = config.Transitions;
        Current = InitialState;
    }

    public TState InitialState => Transitions.FirstOrDefault(t => t.IsFirst)?.From ?? default;

    private IEnumerable<StateTransition<TState, TEvent>> Transitions { get; }

    public TState Current { get; private set; }

    public void MoveNext(StateTransition<TState, TEvent> transition)
    {
        Current = transition.To;
        //return Transitions.First(t => t.From.Equals(tran.To));
    }

    public StateTransition<TState, TEvent>? GetNext(TEvent message)
    {
        var nextTransition = Transitions.FirstOrDefault(t => t.From.Equals(Current) && t.Event.Equals(message));
        return nextTransition;
    }
}