using StateMachine.Oops;
using StateMachine.Oops.Example;
using StateMachine.Oops.Example.Models;
using StateMachine.Oops.Interfaces;

namespace Example.Commands;

public class PlayCommand : ICommand<MusicState, MusicEvent>
{
    public bool Execute(IEntity<MusicState> entity, MusicEvent @event)
    {
        if (entity is Song song)
        {
            Console.WriteLine($"Playing {song.Name}");
        }

        return true;
    }

    public bool IsValid(IEntity<MusicState> entity, MusicEvent @event) => (entity.CurrentState, @event) switch
    {
        (MusicState.Idle, MusicEvent.Play) => true,
        (MusicState.Paused, MusicEvent.Play) => true,
        _ => false
    };
}