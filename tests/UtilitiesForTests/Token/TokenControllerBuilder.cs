using BackendSiteVendas.Application.Services.Token;

namespace UtilitiesForTests.Token;

public class TokenControllerBuilder
{
    public static TokenController Instance()
    {
        return new TokenController(1000, "M3M1eFdpRWNBTTZmejB1MUxkTFk0SSZ3b0BueE5uAAAAAAAA");
    }

    public static TokenController ExpiredToken()
    {
        return new TokenController(0.0166667, "M3M1eFdpRWNBTTZmejB1MUxkTFk0SSZ3b0BueE5uAAAAAAAA");
    }
}
