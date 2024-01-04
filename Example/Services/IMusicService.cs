using Example.Models;

namespace Example.Services;

public interface IMusicService
{
    public Song Play(Song song);
    public Song Stop(Song song);
    public Song Pause(Song song);
}