namespace Movie_rental.Entities
{
    public class Inventory : BaseEntity
    {
        public int FilmId { get; set; }
        public Film Movie { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        ICollection<Reservation> Reservations { get; set; }
        ICollection<Rental> Rentals { get; set;}
    }
}
