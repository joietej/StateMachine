using Example.Models;
using StateMachine;
using StateMachine.Example;
using StateMachine.Interfaces;

namespace Example.Commands;

public class PauseCommand : ICommand<MusicState, MusicEvent>
{
    public bool Execute(IEntity<MusicState> entity, MusicEvent @event)
    {
        if (entity is Song song)
        {
            Console.WriteLine($"Pausing {song.Name}");
        }

        return true;
    }

    public bool IsValid(IEntity<MusicState> entity, MusicEvent @event) => (entity.CurrentState, @event) switch
    {
        (MusicState.Running, MusicEvent.Pause) => true,
        _ => false
    };
}