using Example.Models;
using StateMachine;
using StateMachine.Example;
using StateMachine.Interfaces;

namespace Example.Services;

public class MusicService : IMusicService
{
    private readonly IStateMachineRuntime<MusicState, MusicEvent> _stateMachineRuntime;

    public MusicService(IStateMachineRuntime<MusicState, MusicEvent> stateMachineRuntime)
    {
        _stateMachineRuntime = stateMachineRuntime;
    }

    public Song Play(Song song)
    {
        return (Song) _stateMachineRuntime.Execute(song, MusicEvent.Play);
    }

    public Song Stop(Song song)
    {
        return (Song) _stateMachineRuntime.Execute(song, MusicEvent.Stop);
    }

    public Song Pause(Song song)
    {
        return (Song) _stateMachineRuntime.Execute(song, MusicEvent.Pause);
    }
}