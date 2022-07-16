using OrderNow.API.Services;
using OrderNow.API.Services.Authentication;


namespace OrderNow.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddHangfireServer();
            services.AddCors();
            //services.AddControllers()
            //        .AddJsonOptions(x =>
            //        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddIdentity<Users, IdentityRole>(options =>
                options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataContext>();

            services.AddLogging();

            services.AddEndpointsApiExplorer();

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            //Repositorios
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                    .AddScoped<IConfigurationHelper, ConfigurationHelper>()
                    .AddScoped<IBusinessesRepository, BusinessesRepository>()
                    .AddScoped<IProductsRepository, ProductsRepository>()
                    .AddScoped<IOrdersRepository, OrdersRepository>()
                    .AddScoped<IUsersRepository, UsersRepository>();

            //Servicios
            services.AddScoped<IBusinessesServices, BusinessesServices>()
                    .AddScoped<IDemoService, DemoService>()
                    .AddScoped<IOrdersServices, OrdersServices>()
                    .AddScoped<IProductsServices, ProductsServices>()
                    .AddScoped<IUsersServices, UsersServices>();

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services
                .AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>()
                .AddSingleton<IDateTimeProvider, DateTimeProvider>()
                .AddAuthentication(options =>
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
                        ValidIssuer = configuration.GetSection("JwtBearerTokenSettings").GetValue<string>("Issuer"),
                        ValidAudience = configuration.GetSection("JwtBearerTokenSettings").GetValue<string>("Audience"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                            configuration.GetSection("JwtBearerTokenSettings").GetValue<string>("SecretKey")))
                    };
                });


            services.Configure<JwtBearerTokenSettings>(configuration.GetSection(JwtBearerTokenSettings.SectionName));

            return services;
        }
    }
}