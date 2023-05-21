using BackendSiteVendas.Application.Services.Cryptography;

namespace UtilitiesForTests.Cryptography;

public class PasswordScramblerBuilder
{
    public static PasswordScrambler Instance()
    {
        return new PasswordScrambler("4sC@LQ8KMT9iAbc413O");
    }
}
