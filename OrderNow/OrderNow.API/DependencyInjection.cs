using OrderNow.API.Services;
using OrderNow.API.Services.Authentication;

namespace OrderNow.API
{
    public static class DependencyInjection
    {

        
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Repositorios
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IConfigurationHelper, ConfigurationHelper>();
            services.AddScoped<IBusinessesRepository, BusinessesRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            //Servicios
            services.AddScoped<IBusinessesServices, BusinessesServices>();
            services.AddScoped<IDemoService, DemoService>();
            services.AddScoped<IOrdersServices, OrdersServices>();
            services.AddScoped<IProductsServices, ProductsServices>();
            services.AddScoped<IUsersServices, UsersServices>();

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>()
            .AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.Configure<JwtBearerTokenSettings>(configuration.GetSection(JwtBearerTokenSettings.SectionName));
           
            return services;
        }
    }
}