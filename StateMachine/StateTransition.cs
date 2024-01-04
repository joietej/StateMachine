namespace StateMachine;

public record StateTransition<TState, TEvent>(
    TState From,
    TState To,
    TEvent Event,
    bool IsFirst = false,
    bool IsLast = false)
    where TState : struct
    where TEvent : struct;