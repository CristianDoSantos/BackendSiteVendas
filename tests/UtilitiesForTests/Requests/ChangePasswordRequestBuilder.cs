using BackendSiteVendas.Comunication.Requests;
using Bogus;

namespace UtilitiesForTests.Requests;

public class ChangePasswordRequestBuilder
{
    public static ChangePasswordRequestJson Build(int passwordLength = 10)
    {
        return new Faker<ChangePasswordRequestJson>()
            .RuleFor(request => request.CurrentPassword, f => f.Internet.Password(10))
            .RuleFor(request => request.NewPassword, f => f.Internet.Password(passwordLength));
    }
}
