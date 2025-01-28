namespace IMDBApp.Domain.Models
{
    public class Movie
    {
        public required string Name { get; set; }
        public int YearOfRelease { get; set; }
        public required string Plot { get; set; }
        public required List<Actor> Actors { get; set; }
        public required Producer Producer { get; set; }
    }
}