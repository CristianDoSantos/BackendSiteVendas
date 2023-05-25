namespace BackendSiteVendas.Domain.Entities.Order
{
    public class Order : BaseEntity
    {
        public long UserId { get; set; }
        public User.User User { get; set; }
        public DateTime OrderDate { get; set; }
        public long StatusId { get; set; }
        //referenciar
        public long PaymentId { get; set; }
        //referenciar
        public long DeliveryAddressId { get; set; }
        //referenciar
    }
}
