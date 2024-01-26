namespace Movie_rental.Entities
{
    public class FilmActor : BaseEntity
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
