namespace BackendSiteVendas.Domain.Entities.Address;

public class Address : BaseEntity
{
    public long UserId { get; set; }
    public User.User User { get; set; }
    public string Postal_Code { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Street { get; set; }
    public string Neighborhood { get; set; }
    public string Address_Type { get; set; }

}
