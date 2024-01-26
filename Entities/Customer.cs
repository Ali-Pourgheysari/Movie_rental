namespace Movie_rental.Entities
{
    public class Customer : User
    {
        public int DelayCount { get; set; } = 0;
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Rental> Rentals { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
