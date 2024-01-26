namespace Movie_rental.Entities
{
    public class Rental : BaseEntity
    {
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<Payment> payments { get; set; }

    }
}