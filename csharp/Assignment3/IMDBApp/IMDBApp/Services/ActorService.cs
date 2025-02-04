using IMDBApp.Domain.Interfaces;
using IMDBApp.Domain.Models;
using IMDBApp.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace IMDBApp.Services
{
    public class ActorService
    {
        private readonly IActorRepository _actorRepo;

        public ActorService(IActorRepository actorRepo)
        {
            _actorRepo = actorRepo;
        }

        public void AddActor(string actorName)
        {
            if (string.IsNullOrWhiteSpace(actorName))
            {
                throw new ValidationException("Actor name cannot be empty.");
            }

            var actor = new Actor { Name = actorName };
            _actorRepo.AddActor(actor);
            Console.WriteLine($"Actor '{actorName}' added successfully.");
        }

        public List<Actor> GetAllActors()
        {
            try
            {
                var actors = _actorRepo.GetAllActors();
                if (actors.Count == 0)
                {
                    Console.WriteLine("No actors found.");
                }
                return actors;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching actors: {ex.Message}");
                return new List<Actor>();
            }
        }
    }
}
