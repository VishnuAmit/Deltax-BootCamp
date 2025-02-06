using IMDBApp.Domain.Models;

namespace IMDBApp.Domain.Interfaces
{
    public interface IActorRepository
    {
        List<Actor> GetAllActors();
    }
}
