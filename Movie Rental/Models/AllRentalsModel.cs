using Movie_rental.Entities;

namespace Movie_rental.Models
{
    public class AllRentalsModel
    {
        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public float? Score { get; set; }
        public int InventoryId { get; set; }
        public string CustomerName { get; set; }
    }
}
