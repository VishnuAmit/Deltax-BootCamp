using IMDBApp.Domain.Interfaces;
using IMDBApp.Domain.Models;
using IMDBApp.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace IMDBApp.Services
{
    public class ProducerService
    {
        private readonly IProducerRepository _producerRepo;

        public ProducerService(IProducerRepository producerRepo)
        {
            _producerRepo = producerRepo;
        }

        public void AddProducer(string producerName)
        {
            if (string.IsNullOrWhiteSpace(producerName))
            {
                throw new ValidationException("Producer name cannot be empty.");
            }

            var producer = new Producer { Name = producerName };
            _producerRepo.AddProducer(producer);
            Console.WriteLine($"Producer '{producerName}' added successfully.");
        }

        public List<Producer> GetAllProducers()
        {
            try
            {
                var producers = _producerRepo.GetAllProducers();
                if (producers == null || !producers.Any())
                {
                    Console.WriteLine("No producers found.");
                    return new List<Producer>();
                }
                return new List<Producer>(producers);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching producers: {ex.Message}");
                return new List<Producer>();
            }
        }

    }
}
