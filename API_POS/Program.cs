using Shelly.GraphQLShared.Options;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#region Configuration.
builder.Services
.AddEndpointsApiExplorer()
.AddSwaggerGen(options =>
{
     options.SwaggerDoc("v1", new OpenApiInfo
     {
          Version = "v3.0.4",
          Title = "Shelly API",
          Description = "An ASP.NET Core Web API for managing Shelly services",
          TermsOfService = new Uri("https://example.com/terms"),
          Contact = new OpenApiContact
          {
               Name = "Contact",
               Url = new Uri("https://example.com/contact")
          },
          License = new OpenApiLicense
          {
               Name = "License",
               Url = new Uri("https://example.com/license")
          }
     });
})
.AddCors(opt =>
     {
          opt.AddPolicy("AllowAnyOrigin", pol =>
          {
               pol.AllowAnyHeader();
               pol.AllowAnyMethod();
               pol.AllowAnyOrigin();
          });
     })
.AddProviderDataService(options => builder.Configuration.GetSection(DataAccess.SectionKey).Bind(options))
.AddProviderCacheService(options => builder.Configuration.GetSection(Cache.SectionKey).Bind(options))
.AddGraphQLSharedServices(options => builder.Configuration.GetSection(AppSettings.SectionKey).Bind(options))
.AddProviderBlobStorageService(options => builder.Configuration.GetSection(BlobStorages.SectionKey).Bind(options))

//.AddProviderHttpService()
.AddPosCoreServices()
.AddHttpContextAccessor()
.AddMessageLocalizer();
#endregion

var app = builder.Build();
//Added Management Exceptions
app.UseShellyExceptionHandler();
app.UseCors("AllowAnyOrigin");
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UsePOSCoreEndpoints(builder.Configuration.GetSection("API"));
app.Run();
