using IMDBApp.Domain.Interfaces;
using IMDBApp.Domain.Models;

namespace IMDBApp.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private List<Actor> _actors = new()
        {
            new Actor { Name = "Will Smith" },
            new Actor { Name = "Leonardo DiCaprio" },
            new Actor { Name = "Robert Downey Jr." },
            new Actor { Name = "Scarlett Johansson" },
            new Actor { Name = "Tom Hanks" },
            new Actor { Name = "Meryl Streep" },
            new Actor { Name = "Johnny Depp" },
            new Actor { Name = "Emma Watson" },
            new Actor { Name = "Brad Pitt" },
            new Actor { Name = "Angelina Jolie" }
        };

        public List<Actor> GetAllActors() => _actors;

        public void AddActor(Actor actor)
        {
            _actors.Add(actor);
        }
    }
}
