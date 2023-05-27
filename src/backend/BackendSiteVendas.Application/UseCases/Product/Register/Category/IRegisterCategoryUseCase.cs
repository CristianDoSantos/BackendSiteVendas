using BackendSiteVendas.Comunication.Requests.Product;
using BackendSiteVendas.Comunication.Responses.Poduct;

namespace BackendSiteVendas.Application.UseCases.Product.Register.Category;

public interface IRegisterCategoryUseCase
{
    Task<ProductCategoryRegisterResponseJson> Execute(CategoryRegisterRequestJson request);
}
