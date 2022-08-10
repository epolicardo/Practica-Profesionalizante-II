using Microsoft.AspNetCore.Mvc.ApiExplorer;
using OrderNow.API.Data;
using OrderNow.API.Filters;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341"));



//https://www.campusmvp.es/recursos/post/como-guardar-secretos-en-nuestras-aplicaciones-de-net-core-sin-peligro-de-enviarlos-a-github-por-error.aspx
IConfiguration config = new ConfigurationBuilder()
        .AddUserSecrets("32ad9ec7-e1d8-4419-8ee0-da8bd840bc0f") //Nombre de la carpeta que hemos creado
            .Build();


builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));
builder.Services.AddHangfire(x => x.UseSqlServerStorage(config.GetConnectionString("Conexion_Hangfire")));
//builder.Services.AddHangfireServer();
//builder.Services.AddCors();
////builder.Services.AddControllers()
////                .AddJsonOptions(x =>
////                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

//builder.Services.AddIdentity<Users, IdentityRole>(options =>
//    options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<DataContext>();

//builder.Services.AddLogging();

//builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddApiVersioning(options =>
//{
//    options.ReportApiVersions = true;
//    options.DefaultApiVersion = new ApiVersion(1, 0);
//    options.AssumeDefaultVersionWhenUnspecified = true;
//});

//builder.Services.AddVersionedApiExplorer(options =>
//{
//    options.GroupNameFormat = "'v'VVV";
//    options.SubstituteApiVersionInUrl = true;
//});

builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<SwaggerDefaultValues>();
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {{
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,Id = "Bearer"
            }
        },new string[] {}
    }
    });
});

builder.Services
    .AddApplicationServices()
    .AddInfrastructure(builder.Configuration)
    .ConfigureOptions<ConfigureSwaggerOptions>();

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer(options =>
//    {
//        //TODO: Activar en produccion
//        options.RequireHttpsMetadata = false;
//        options.SaveToken = true;
//        options.IncludeErrorDetails = true;
//        options.TokenValidationParameters = new TokenValidationParameters()
//        {
//            ValidIssuer = "https://localhost:44322/",
//            ValidAudience = "https://localhost:44322/",
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtBearerTokenSettings.SecretKey))
//        };
//    });

var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

try
{
    await SeedData.SeedInitialData(app);
}
catch (Exception ex)
{
    throw;
}

app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
    });
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

Log.Logger = new LoggerConfiguration()
          .WriteTo.Seq("http://localhost:5341")
          .CreateLogger();

Log.Information("OrderNow Started by user, {Name}!", Environment.UserName);

// Important to call at exit so that batched events are flushed.
Log.CloseAndFlush();

app.Run();