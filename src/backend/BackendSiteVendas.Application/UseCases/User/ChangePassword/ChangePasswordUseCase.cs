using BackendSiteVendas.Application.Services.Cryptography;
using BackendSiteVendas.Application.Services.LoggedUser;
using BackendSiteVendas.Comunication.Requests.User;
using BackendSiteVendas.Domain.Repositories;
using BackendSiteVendas.Domain.Repositories.User;
using BackendSiteVendas.Exceptions;
using BackendSiteVendas.Exceptions.ExceptionsBase;
using System.ComponentModel.DataAnnotations;

namespace BackendSiteVendas.Application.UseCases.User.ChangePassword
{
    public class ChangePasswordUseCase : IChangePasswordUseCase
    {
        private readonly IUserUpdateOnlyRepository _repository;
        private readonly ILoggedUser _loggedUser;
        private readonly PasswordScrambler _passwordScrambler;
        private readonly IUnityOfWork _unityOfWork;

        public ChangePasswordUseCase(IUserUpdateOnlyRepository repository, ILoggedUser loggedUser, PasswordScrambler passwordScrambler, IUnityOfWork unityOfWork)
        {
            _repository = repository;
            _loggedUser = loggedUser;
            _passwordScrambler = passwordScrambler;
            _unityOfWork = unityOfWork;
        }

        public async Task Execute(ChangePasswordRequestJson request)
        {
            var loggedUser = await _loggedUser.RetrieveUser();

            var user = await _repository.RetrieveById(loggedUser.Id);

            Validate(request, user);

            user.Password = _passwordScrambler.Encrypt(request.NewPassword);

            _repository.Update(user);

            await _unityOfWork.Commit();
        }
        private void Validate(ChangePasswordRequestJson request, Domain.Entities.User.User user)
        {
            var validator = new ChangePasswordValidator();
            var result = validator.Validate(request);

            var encryptedCurrentPassword = _passwordScrambler.Encrypt(request.CurrentPassword);

            if (!user.Password.Equals(encryptedCurrentPassword))
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure("currentPassword", ResourceCustomErrorMessages.INVALID_CURRENT_PASSWORD));
            }

            if (!result.IsValid)
            {
                var messages = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationErrorException(messages);
            }
        }
    }

}   
