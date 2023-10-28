namespace DevBr.Escola.WebAPI.Configuration
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            //TODO: COncluir - ou verificar necessidade;
            //services.AddAutoMapper(Assembly.Load("DevBr.Escola.Dominio"));
            //AutoMapperConfig.RegisterMappings();
        }
    }
}
