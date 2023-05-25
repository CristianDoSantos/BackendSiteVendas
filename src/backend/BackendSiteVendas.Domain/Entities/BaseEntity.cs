namespace BackendSiteVendas.Domain.Entities;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CriationDate { get; set; } = DateTime.Now;
}
