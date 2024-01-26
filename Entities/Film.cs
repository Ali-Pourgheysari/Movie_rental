using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_rental.Entities
{
    public class Film : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int RentalDuration { get; set; }
        [Precision(8, 2)]
        public decimal RentalRate { get; set; }
        public int Length { get; set; }
        public string Rating { get; set; }
        public ICollection<FilmCategory> FilmCategories { get; set; }
        public ICollection<FilmActor> FilmActors { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
    }
}
