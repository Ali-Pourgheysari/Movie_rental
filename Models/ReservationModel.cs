namespace Movie_rental.Models
{
    public class ReservationModel
    {
        public int FilmId { get; set; }
        public string FilmTitle { get; set; }
        public int InventoryId { get; set; }
        public int AvailableCopies { get; set; }
    }
}
