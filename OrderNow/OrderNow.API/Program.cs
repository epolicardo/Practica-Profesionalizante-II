using Hangfire;
using Infrastructure.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

//https://www.campusmvp.es/recursos/post/como-guardar-secretos-en-nuestras-aplicaciones-de-net-core-sin-peligro-de-enviarlos-a-github-por-error.aspx
IConfiguration config = new ConfigurationBuilder()
        .AddUserSecrets("32ad9ec7-e1d8-4419-8ee0-da8bd840bc0f") //Nombre de la carpeta que hemos creado
            .Build();

builder.Services.AddHangfire(x => x.UseSqlServerStorage(config.GetConnectionString("Conexion_Hangfire")));
builder.Services.AddHangfireServer();
builder.Services.AddCors();
builder.Services.AddControllers();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IDemoService, DemoService>();
builder.Services.AddScoped<IConfigurationHelper, ConfigurationHelper>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DataContext>();



builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<SwaggerDefaultValues>();
    //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    //{
    //    Name = "Authorization",
    //    Type = SecuritySchemeType.ApiKey,
    //    Scheme = "Bearer",
    //    BearerFormat = "JWT",
    //    In = ParameterLocation.Header,
    //    Description = "JWT Authorization header using the Bearer scheme."
    //});
    //options.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{{
    //    new OpenApiSecurityScheme
    //    {
    //        Reference = new OpenApiReference
    //        {
    //            Type = ReferenceType.SecurityScheme,Id = "Bearer"
    //        }
    //    },new string[] {}
    //}
    //});
});

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});


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
    //TODO: Activar en produccion
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.IncludeErrorDetails = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = jwtBearerTokenSettings.Issuer,
        ValidAudience = jwtBearerTokenSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(key),
    };
});

var app = builder.Build();

await SeedData();

app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard("/jobs");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});




app.Run();


async Task SeedData()
{
    //var scopeFactory = app!.Services.GetRequiredService<IServiceScopeFactory>();
    //using var scope = scopeFactory.CreateScope();

    //var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    ////var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    //var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    //var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    //context.Database.EnsureCreated();

    //if (!userManager.Users.Any())
    //{
    //    logger.LogInformation("Creando usuario de prueba");

    //    var newUser = new User
    //    {
    //        Email = "test@demo.com",
    //        UserName = "test.demo"
    //    };

    //    await userManager.CreateAsync(newUser, "P@ss.W0rd");
    //    await roleManager.CreateAsync(new IdentityRole
    //    {
    //        Name = "Admin"
    //    });
    //    await roleManager.CreateAsync(new IdentityRole
    //    {
    //        Name = "AnotherRole"
    //    });

    //    await userManager.AddToRoleAsync(newUser, "Admin");
    //    await userManager.AddToRoleAsync(newUser, "AnotherRole");
    //}
}