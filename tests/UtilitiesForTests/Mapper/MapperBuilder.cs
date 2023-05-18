using AutoMapper;
using BackendSiteVendas.Application.Services.AutoMapper;

namespace UtilitiesForTests.Mapper;

public class MapperBuilder
{
    public static IMapper Instance()
    {
        var configuration = new MapperConfiguration(cfg => {
            cfg.AddProfile<AutoMapperConfiguration>();
        });

        return configuration.CreateMapper();
    }
}
