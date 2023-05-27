using BackendSiteVendas.Comunication.Requests.Product;
using Bogus;

namespace UtilitiesForTests.Requests.Product.Category;

public class CategoryRegisterRequestBuilder
{
    public static CategoryRegisterRequestJson Build()
    {
        return new Faker<CategoryRegisterRequestJson>()
            .RuleFor(c => c.Name, f => f.Commerce.Product())
            .RuleFor(c => c.Description, f => f.Commerce.ProductDescription());
    }
}
