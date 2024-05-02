using AutoMapper;

namespace CkmWhatsAppMiddleware.APIs.AutoMapper;

public class AutoMapperConfiguration
{
    public static MapperConfiguration RegisterMappings()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ApplicationMappingProfile());
        });
    }
}
