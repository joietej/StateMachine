using Microsoft.Extensions.DependencyInjection;
using StateMachine.Interfaces;

namespace StateMachine;

public class StateMachineRuntime<TState, TEvent> : IStateMachineRuntime<TState, TEvent>
    where TState : struct
    where TEvent : struct
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IStateMachine<TState, TEvent> _stateMachine;

    public StateMachineRuntime(IServiceProvider serviceProvider, IStateMachine<TState, TEvent> stateMachine)
    {
        _serviceProvider = serviceProvider;
        _stateMachine = stateMachine;
    }

    public IEntity<TState> Execute(IEntity<TState> entity, TEvent @event)
    {
        var tran = _stateMachine.GetNext(@event);
        if (tran == null) return entity;

        var commandServices = _serviceProvider
            .GetServices(typeof(ICommand<TState, TEvent>))
            .OfType<ICommand<TState, TEvent>>();

        var validCommand = commandServices.FirstOrDefault(c => c.IsValid(entity, @event));

        if (validCommand == null) return entity;
        if (validCommand.Execute(entity, @event))
        {
            _stateMachine.MoveNext(tran);
        }

        entity.CurrentState = _stateMachine.Current;

        return entity;
    }
}