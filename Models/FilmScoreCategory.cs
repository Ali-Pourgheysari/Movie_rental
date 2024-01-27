using Movie_rental.Entities;

namespace Movie_rental.Models
{
    public class FilmScoreCategory
    {
        public int FilmId { get; set; }
        public string FilmTitle { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public double AvgScore { get; set; }
    }
}
