namespace OrderNow
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionLocal")),
                ServiceLifetime.Transient);

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddDefaultIdentity<Users>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataContext>();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            //To compress messages
            builder.Services.AddResponseCompression(opt =>
            opt.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                new[] { "application/octet-stream" }));

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
            });

            builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<Users>>();
            //Servicios
            builder.Services.AddScoped<IDemoService, DemoService>()
                            .AddScoped<IConfigurationHelper, ConfigurationHelper>()
                            .AddScoped<IDateTimeProvider, DateTimeProvider>()
                            .AddTransient<IBusinessesServices, BusinessesServices>()
                            .AddTransient<IOrdersServices, OrdersServices>()
                            .AddTransient<IProductsServices, ProductsServices>()
                            .AddTransient<IUsersServices, UsersServices>()
                            .AddTransient<IAddressesServices, AddressesServices>();

            //Repositorios
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                            .AddTransient<IBusinessesRepository, BusinessesRepository>()
                            .AddTransient<IOrdersRepository, OrdersRepository>()
                            .AddTransient<IProductsRepository, ProductsRepository>()
                            .AddTransient<IUsersRepository, UsersRepository>()
                            .AddTransient<IAddressesRepository, AddressesRepository>();

            return services;
        }
    }
}