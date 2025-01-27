using System;
using System.Collections.Generic;
using System.Numerics;

namespace MovieApp.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public List<Actor> Actors { get; set; } = new List<Actor>();
        public Producer Producer { get; set; }

        public Movie(string name, int yearOfRelease, string plot)
        {
            Name = name;
            YearOfRelease = yearOfRelease;
            Plot = plot;
        }
    }
}
