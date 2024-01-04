using System.Net.Sockets;

namespace StateMachine.Oops.Example.Models
{
    public enum MusicState
    {
        Idle,
        Paused,
        Running
    }

    public enum MusicEvent
    {
        Play,
        Pause,
        Stop
    }

    public class MusicConfig : StateConfiguration<MusicState, MusicEvent>
    {
        public MusicConfig()
        {
            Add(MusicState.Idle, MusicEvent.Play, MusicState.Running, isFirst: true);
            Add(MusicState.Running, MusicEvent.Pause, MusicState.Paused);
            Add(MusicState.Running, MusicEvent.Stop, MusicState.Idle);
            Add(MusicState.Paused, MusicEvent.Play, MusicState.Running);
            Add(MusicState.Paused, MusicEvent.Stop, MusicState.Idle);
        }
    }
}