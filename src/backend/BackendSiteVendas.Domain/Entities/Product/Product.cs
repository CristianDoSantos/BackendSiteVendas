namespace BackendSiteVendas.Domain.Entities.Product;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public long? CategoryId { get; set; }
    public Category Category { get; set; }
    public string? Brand { get; set; }
    public string? Image { get; set; }
    public DateTime? UpdateDate { get; set; }
    public bool? Emphasis { get; set; } = false;
    public bool? Active { get; set; } = true;
    public decimal? Weight { get; set; }
    public decimal? Length { get; set; }
    public decimal? Width { get; set; }
    public decimal? Height { get; set; }
}
