namespace Movie_rental.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<FilmCategory> FilmCategories { get; set; }
    }
}
