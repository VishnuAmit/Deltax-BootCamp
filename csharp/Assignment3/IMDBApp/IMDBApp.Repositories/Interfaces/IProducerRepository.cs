using IMDBApp.Domain.Models;

namespace IMDBApp.Domain.Interfaces
{
    public interface IProducerRepository
    {
        List<Producer> GetAllProducers();
        void AddProducer(Producer producer); 
    }
}
