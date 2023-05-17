using BackendSiteVendas.Application.UseCases.User.Register;
using Microsoft.Extensions.DependencyInjection;

namespace BackendSiteVendas.Application;

public static class Bootstrapper
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }
}
