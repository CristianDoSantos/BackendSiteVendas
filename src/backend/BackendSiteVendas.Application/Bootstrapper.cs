using BackendSiteVendas.Application.Services.Cryptography;
using BackendSiteVendas.Application.Services.LoggedUser;
using BackendSiteVendas.Application.Services.Token;
using BackendSiteVendas.Application.UseCases.Login.DoLogin;
using BackendSiteVendas.Application.UseCases.User.ChangePassword;
using BackendSiteVendas.Application.UseCases.User.Register;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackendSiteVendas.Application;

public static class Bootstrapper
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddPasswordAdditionalkey(services, configuration);
        AddTokenJWT(services, configuration);
        AddUseCases(services);
        AddLoggedUser(services);
    }

    private static void AddLoggedUser(IServiceCollection services)
    {
        services.AddScoped<ILoggedUser, LoggedUser>();
    }

    private static void AddPasswordAdditionalkey(IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetRequiredSection("Configurations:Password:PasswordAdditionalkey");

        services.AddScoped(option => new PasswordScrambler(section.Value));
    }

    private static void AddTokenJWT(IServiceCollection services, IConfiguration configuration)
    {
        var sectionTokenLifetime = configuration.GetRequiredSection("Configurations:Jwt:TokenLifetime");
        var sectionTokenKey = configuration.GetRequiredSection("Configurations:Jwt:TokenKey");

        services.AddScoped(option => new TokenController(int.Parse(sectionTokenLifetime.Value), sectionTokenKey.Value));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<ILoginUseCase, LoginUseCase>();
        services.AddScoped<IChangePasswordUseCase, ChangePasswordUseCase>();

    }
}
