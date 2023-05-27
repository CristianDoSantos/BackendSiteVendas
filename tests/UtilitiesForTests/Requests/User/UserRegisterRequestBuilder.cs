using BackendSiteVendas.Comunication.Requests.User;
using Bogus;

namespace UtilitiesForTests.Requests.User;

public class UserRegisterRequestBuilder
{
    public static UserRegisterRequestJson Build(int passwordLength = 10)
    {
        return new Faker<UserRegisterRequestJson>()
           .RuleFor(c => c.Name, f => f.Person.FullName)
           .RuleFor(c => c.Email, f => f.Internet.Email())
           .RuleFor(c => c.Password, f => f.Internet.Password(passwordLength))
           .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber("## ! ####-####").Replace("!", $"{f.Random.Int(min: 1, max: 9)}"));
    }
}