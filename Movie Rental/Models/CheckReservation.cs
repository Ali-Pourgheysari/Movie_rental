namespace Movie_rental.Models
{
    public class CheckReservation
    {
        public string CustomerName { get; set; }
        public string Title { get; set; }
        public string CustomerId { get; set; }
        public int ReservationId { get; set; }
        public int InventoryId { get; set; }
    }
}
