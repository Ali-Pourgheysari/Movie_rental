namespace Movie_rental.Models
{
    public class RentalDetails
    {
        public int RentalId { get; set; }
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string CustomerId { get; set; }
        public int NumberOfRentals { get; set; }
        public double AvgScore { get; set; }
        public double MyScore { get; set; }
        public int FilmCopies { get; set; }
        public int NumberOfDelays { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime RentalDate { get; set; }
        public int DaysLeftToReturn { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
