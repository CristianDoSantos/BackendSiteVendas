using BackendSiteVendas.API.Filters;
using BackendSiteVendas.API.Middleware;
using BackendSiteVendas.Application;
using BackendSiteVendas.Application.Services.AutoMapper;
using BackendSiteVendas.Domain.Extension;
using BackendSiteVendas.Infrastructure;
using BackendSiteVendas.Infrastructure.Migrations;
using BackendSiteVendas.Infrastructure.RepositoryAccess;
using HashidsNet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(option => option.LowercaseUrls = true);

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

builder.Services.AddMvc(option => option.Filters.Add(typeof(ExceptionsFilter)));

builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg => {
    cfg.AddProfile(new AutoMapperConfiguration(provider.GetService<IHashids>()));
}).CreateMapper());

builder.Services.AddScoped<AuthenticatedUserAttribute>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

RefreshDataBase();

app.UseMiddleware<CultureMiddleware>();

app.Run();

void RefreshDataBase()
{
    using var serviceScope = app.Services.GetRequiredService< IServiceScopeFactory>().CreateScope();

    using var context = serviceScope.ServiceProvider.GetService<BackendSiteVendasContext>();

    bool? inMemoryDatabase = context?.Database?.ProviderName?.Equals("Microsoft.EntityFrameworkCore.InMemory");

    if (!inMemoryDatabase.HasValue || !inMemoryDatabase.Value)
    {
        var connectionstring = builder.Configuration.GetConnection();
        var databaseName = builder.Configuration.GetDatabaseName();

        Database.CreateDatabase(connectionstring, databaseName);
        app.MigrateDatabase();
    }
}

public partial class Program { }