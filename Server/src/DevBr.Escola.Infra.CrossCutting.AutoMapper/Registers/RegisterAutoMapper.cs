using AutoMapper;
using DevBr.Escola.Aplicacao.AutoMappers;
using Microsoft.Extensions.DependencyInjection;

namespace DevBr.Escola.Infra.CrossCutting.AutoMapper.Registers
{
    public static class InfraAutoMapper
    {
        public static void AutoMapperRegister(this IServiceCollection service)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
            IMapper mapper = config.CreateMapper();
            service.AddSingleton(mapper);

        }
    }


}
