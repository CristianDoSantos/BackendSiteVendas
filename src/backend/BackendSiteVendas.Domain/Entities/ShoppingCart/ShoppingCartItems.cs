namespace BackendSiteVendas.Domain.Entities.ShoppingCart;

public class ShoppingCartItems : BaseEntity
{
    public long UserId { get; set; }
    public User.User User { get; set; }
    public long ProductId { get; set; }
    public Product.Product Product { get; set; }
    public int Quantity { get; set; }
}
