namespace Movie_rental.Entities
{
    public class Store : BaseEntity
    {
        public string ManagerId { get; set; }
        public Manager Manager { get; set; }
        public string Address { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
    }
}