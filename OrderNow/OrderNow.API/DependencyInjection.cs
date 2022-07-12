using OrderNow.API.Services;
using OrderNow.API.Services.Authentication;
using System.Text.Json;

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
            services
                .AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>()
                .AddSingleton<IDateTimeProvider, DateTimeProvider>();

    

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.IncludeErrorDetails = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = "https://localhost:44322/",
                        ValidAudience = "https://localhost:44322/",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                            configuration.GetSection("JwtBearerTokenSettings").GetValue<string>("SecretKey")))
                    };
                });


            services.Configure<JwtBearerTokenSettings>(configuration.GetSection(JwtBearerTokenSettings.SectionName));

            return services;
        }
    }
}