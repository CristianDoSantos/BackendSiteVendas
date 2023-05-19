using BackendSiteVendas.Domain.Entities;
using Bogus;
using UtilitiesForTests.Cryptography;

namespace UtilitiesForTests.Entities;

public class UserBuilder
{
    public static (User user, string password) Build()
    {
        string password = string.Empty;

        var createdUser = new Faker<User>()
            .RuleFor(u => u.Id, _ => 1)
            .RuleFor(u => u.Name, f => f.Person.FullName)
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Password, f => {
                password = f.Internet.Password();

                return PasswordScramblerBuilder.Instance().Encrypt(password);
            })
            .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber("## ! ####-####").Replace("!", $"{f.Random.Int(min: 1, max: 9)}"));

        return (createdUser, password);
    }
}
