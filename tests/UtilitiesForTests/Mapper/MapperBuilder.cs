using AutoMapper;
using BackendSiteVendas.Application.Services.AutoMapper;
using UtilitiesForTests.Hashids;

namespace UtilitiesForTests.Mapper;

public class MapperBuilder
{
    public static IMapper Instance()
    {
        var hashids = HashidsBuilder.Instance().Build();

        var mockMapper = new MapperConfiguration(cfg => 
        {
            cfg.AddProfile(new AutoMapperConfiguration(hashids));
        });

        return mockMapper.CreateMapper();
    }
}
