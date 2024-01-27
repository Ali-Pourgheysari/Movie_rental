using System.ComponentModel.DataAnnotations;

namespace Movie_rental.Entities
{
    public class Rental : BaseEntity
    {
        public DateOnly RentalDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public float Score { get; set; }
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<Payment> payments { get; set; }

    }
}