using IMDBApp.Domain.Interfaces;
using IMDBApp.Domain.Models;
namespace IMDBApp.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly List<Producer> _producers;

        // Added a constructor..
        public ProducerRepository()
        {
            _producers = new List<Producer>
            {
                new Producer { Name = "James Cameron" },
                new Producer { Name = "Christopher Nolan" },
                new Producer { Name = "Steven Spielberg" },
                new Producer { Name = "George Lucas" },
                new Producer { Name = "Quentin Tarantino" },
                new Producer { Name = "Martin Scorsese" },
                new Producer { Name = "J.J. Abrams" },
                new Producer { Name = "Kathleen Kennedy" },
                new Producer { Name = "Zack Snyder" },
                new Producer { Name = "Peter Jackson" }
            };
        }

        public List<Producer> GetAllProducers() => _producers;
    }
}
