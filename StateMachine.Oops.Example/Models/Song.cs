using StateMachine.Oops.Interfaces;

namespace StateMachine.Oops.Example.Models
{
    public class Song : IEntity<MusicState>
    {
        public Song(string name, MusicState currentState = MusicState.Idle)
        {
            this.Name = name;
            this.CurrentState = currentState;
        }

        public string Name { get; }
        public MusicState CurrentState { get; set; }
    }
}