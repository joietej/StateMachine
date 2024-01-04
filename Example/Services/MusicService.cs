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

    public void Play(Song song)
    {
        _stateMachineRuntime.Execute(song, MusicEvent.Play);
    }

    public void Stop(Song song)
    {
        _stateMachineRuntime.Execute(song, MusicEvent.Stop);
    }

    public void Pause(Song song)
    {
        _stateMachineRuntime.Execute(song, MusicEvent.Pause);
    }
}