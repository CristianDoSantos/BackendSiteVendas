namespace BackendSiteVendas.Domain.Entities.Product;

public class ProductReview : BaseEntity
{
    public long UserId { get; set; }
    public User.User User { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public int Rating { get; set; }
    public string Comments { get; set; }
}
