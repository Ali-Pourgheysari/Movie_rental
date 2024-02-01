namespace Movie_rental.Entities
{
    public class Actor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<FilmActor> FilmActors { get; set; }
    }
}
