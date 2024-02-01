using Movie_rental.Entities;

namespace Movie_rental.Models
{
    public class SearchModel
    {
        public List<Actor> Actors { get; set; }
        public List<Category> Categories { get; set; }
        public List<Film> Films { get; set; }
        public List<Language> Languages { get; set; }
    }
}
