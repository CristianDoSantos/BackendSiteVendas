namespace BackendSiteVendas.Domain.Entities;

public class BaseEntityWithNameAndDescription : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
}
