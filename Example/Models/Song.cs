using StateMachine;
using StateMachine.Example;
using StateMachine.Interfaces;

namespace Example.Models;

public record Song(string Name, MusicState CurrentState = MusicState.Idle) : Entity<MusicState>(CurrentState);