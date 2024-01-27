namespace Movie_rental.Models
{
    public class PaymentDetailsModel
    {
        public int StoreId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int FilmId { get; set; }
        public string FilmName { get; set; }
        public decimal Amount { get; set; }
    }
}
