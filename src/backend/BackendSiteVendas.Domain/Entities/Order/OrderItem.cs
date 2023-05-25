namespace BackendSiteVendas.Domain.Entities.Order;

public class OrderItem : BaseEntity
{
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public long ProductId { get; set; }
    public Product.Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
