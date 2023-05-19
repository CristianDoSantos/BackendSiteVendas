using BackendSiteVendas.Application.Services.Cryptography;

namespace UtilitiesForTests.Cryptography;

public class PasswordScramblerBuilder
{
    public static PasswordScrambler Instance()
    {
        return new PasswordScrambler("ABCD123");
    }
}
