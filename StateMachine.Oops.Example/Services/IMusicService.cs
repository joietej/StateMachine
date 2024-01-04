using StateMachine.Oops.Example.Models;

namespace StateMachine.Oops.Example.Services;

public interface IMusicService
{
    public void Play(Song song);
    public void Stop(Song song);
    public void Pause(Song song);
}