namespace BackendSiteVendas.Domain.Entities.Order
{
    public class Order : BaseEntity
    {
        public long UserId { get; set; }
        public User.User User { get; set; }
        public DateTime OrderDate { get; set; }
        public long OrderStatusId { get; set; }
        public OrderStatus Status { get; set; }
        public long PaymentId { get; set; }
        public Payment.Payment Payment { get; set; }
        public long DeliveryAddressId { get; set; }
        public Address.Address Address { get; set; }
    }
}
