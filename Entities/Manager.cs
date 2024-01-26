namespace Movie_rental.Entities
{
    public class Manager : User
    {
        public ICollection<Store> Stores { get; set; }
    }
}
