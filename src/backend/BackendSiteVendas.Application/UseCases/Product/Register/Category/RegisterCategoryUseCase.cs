using AutoMapper;
using BackendSiteVendas.Comunication.Requests.Product;
using BackendSiteVendas.Comunication.Responses.Poduct;
using BackendSiteVendas.Domain.Repositories;
using BackendSiteVendas.Domain.Repositories.Product.Category;
using BackendSiteVendas.Exceptions.ExceptionsBase;

namespace BackendSiteVendas.Application.UseCases.Product.Register.Category;
public class RegisterCategoryUseCase : IRegisterCategoryUseCase
{
    private IMapper _mapper;
    private IUnityOfWork _unityOfWork;
    private ICategoryWriteOnlyRepository _repository;

    public RegisterCategoryUseCase(IMapper mapper, IUnityOfWork unityOfWork, ICategoryWriteOnlyRepository repository)
    {
        _mapper = mapper;
        _unityOfWork = unityOfWork;
        _repository = repository;
    }

    public async Task<ProductCategoryRegisterResponseJson> Execute(CategoryRegisterRequestJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Domain.Entities.Product.Category>(request);

        await _repository.Register(entity);

        await _unityOfWork.Commit();

        return _mapper.Map<ProductCategoryRegisterResponseJson>(entity);
    }

    private static void Validate(CategoryRegisterRequestJson request)
    {
        var validator = new RegisterCategoryValidator();
        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ValidationErrorException(errorMessages);
        }
    }
}
