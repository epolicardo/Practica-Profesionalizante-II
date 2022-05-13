using Hangfire;
using Hangfire.SqlServer;
using Infrastructure.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrderNow;Integrated Security=True"));

builder.Services.AddHttpClient();

//https://www.campusmvp.es/recursos/post/como-guardar-secretos-en-nuestras-aplicaciones-de-net-core-sin-peligro-de-enviarlos-a-github-por-error.aspx
IConfiguration config = new ConfigurationBuilder()
        .AddUserSecrets("32ad9ec7-e1d8-4419-8ee0-da8bd840bc0f") //Nombre de la carpeta que hemos creado
            .Build();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(config.GetConnectionString("Conexion")));



//builder.Services.AddHangfire(configuration =>
//{
//    configuration.UseLiteDbStorage("./hf.db");

//});
//builder.Services.AddHangfireServer();

//builder.Services.AddHangfire(config =>
//{
//    var options = new SqlServerStorageOptions
//    {
//        PrepareSchemaIfNecessary = true,
//        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
//        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
//        UseRecommendedIsolationLevel = true,
//        UsePageLocksOnDequeue = true,
//        DisableGlobalLocks = true
//    };
//    config.UseSqlServerStorage(Configuration.ConfigurationHelper.GetConnectionString("Conexion_Hangfire"), options).WithJobExpirationTimeout(TimeSpan.FromHours(6));
//}

builder.Services.AddHangfire(x => x.UseSqlServerStorage(config.GetConnectionString("Conexion_Hangfire")));






builder.Services.AddHangfireServer();
builder.Services.AddCors();
builder.Services.AddControllers();

//builder.Services.AddHttpClient("WebApi", c =>
//{
//    c.BaseAddress = new Uri("http://localhost:44365/api/");
//});


//// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-5.0#named-clients
//services.AddHttpClient("github", c =>
//{
//    c.BaseAddress = new Uri("https://api.github.com/");
//    // Github API versioning
//    c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
//    // Github requires a user-agent
//    c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
//});

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
    // add a custom operation filter which sets default values
    options.OperationFilter<SwaggerDefaultValues>();
});


//https://dev.to/moesmp/what-every-asp-net-core-web-api-project-needs-part-2-api-versioning-and-swagger-3nfm
builder.Services.AddApiVersioning(options =>
{
    // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
    // note: the specified format code will format the version as "'v'major[.minor][-status]"
    options.GroupNameFormat = "'v'VVV";

    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
    // can also be used to control the format of the API version in route templates
    options.SubstituteApiVersionInUrl = true;
});










builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IDemoService, DemoService>();
builder.Services.AddScoped<IConfigurationHelper, ConfigurationHelper>();


//  services.AddApiVersioning(o => o.ApiVersionReader = new UrlSegmentApiVersionReader());

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
.AddEntityFrameworkStores<DataContext>();

// configure strongly typed settings objects
var jwtSection = config.GetSection("JwtBearerTokenSettings");
jwtSection = config.GetSection("JwtBearerTokenSettings");
builder.Services.Configure<JwtBearerTokenSettings>(jwtSection);
var jwtBearerTokenSettings = jwtSection.Get<JwtBearerTokenSettings>();
var key = Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = jwtBearerTokenSettings.Issuer,
        ValidAudience = jwtBearerTokenSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(key),
    };
});




























var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard("/jobs");
//BackgroundJob.Enqueue(() => Console.WriteLine("Tarea generada en Startup"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
