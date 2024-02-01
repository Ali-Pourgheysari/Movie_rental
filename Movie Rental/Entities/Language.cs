namespace Movie_rental.Entities
{
    public class Language: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}