namespace Movie_rental.Entities
{
    public class Reservation : BaseEntity
    {
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int InventoryId { get; set; }
        public Inventory inventory { get; set; }
    }
}