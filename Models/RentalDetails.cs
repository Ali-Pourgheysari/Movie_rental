namespace Movie_rental.Models
{
    public class RentalDetails
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public int NumberOfRentals { get; set; }
        public double AvgScore { get; set; }
        public int FilmCopies { get; set; }
        public int NumberOfDelays { get; set; }
    }
}
