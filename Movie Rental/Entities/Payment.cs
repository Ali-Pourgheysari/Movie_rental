using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_rental.Entities
{
    public class Payment : BaseEntity
    {
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int RentalId { get; set; }
        public Rental Rental { get; set; }
        [Precision(8, 2)]
        public decimal Amount { get; set; }
    }
}