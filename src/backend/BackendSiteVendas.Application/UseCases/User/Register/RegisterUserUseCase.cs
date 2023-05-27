using AutoMapper;
using BackendSiteVendas.Application.Services.Cryptography;
using BackendSiteVendas.Application.Services.Token;
using BackendSiteVendas.Comunication.Requests.User;
using BackendSiteVendas.Comunication.Responses.User;
using BackendSiteVendas.Domain.Repositories;
using BackendSiteVendas.Domain.Repositories.User;
using BackendSiteVendas.Exceptions;
using BackendSiteVendas.Exceptions.ExceptionsBase;

namespace BackendSiteVendas.Application.UseCases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IUserWriteOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnityOfWork _unityOfWork;
    private readonly PasswordScrambler _passwordScrambler;
    private readonly TokenController _tokenController;

    public RegisterUserUseCase(IUserReadOnlyRepository userReadOnlyRepository, IUserWriteOnlyRepository repository, IMapper mapper, IUnityOfWork unityOfWork, PasswordScrambler passwordScrambler, TokenController tokenController)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _repository = repository;
        _mapper = mapper;
        _unityOfWork = unityOfWork;
        _passwordScrambler = passwordScrambler;
        _tokenController = tokenController;
    }

    public async Task<RegisteredUserResponseJson> Execute(UserRegisterRequestJson request)
    {
        await Validate(request);

        var entity = _mapper.Map<Domain.Entities.User.User>(request);
        entity.Password = _passwordScrambler.Encrypt(request.Password);

        await _repository.Register(entity);

        await _unityOfWork.Commit();

        var token = _tokenController.GenerateToken(entity.Email);

        return new RegisteredUserResponseJson
        {
            Token = token
        };
    }

    private async Task Validate(UserRegisterRequestJson request)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request);

        var hasUserWithEmail = await _userReadOnlyRepository.UserHasEmail(request.Email);
        if (hasUserWithEmail)
        {
            result.Errors.Add(new FluentValidation.Results.ValidationFailure("email", ResourceCustomErrorMessages.EMAIL_ALREADY_REGISTERED));
        }
        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ValidationErrorException(errorMessages);
        }
    }
}
