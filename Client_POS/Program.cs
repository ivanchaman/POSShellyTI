


using Shelly.GraphQLShared.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents().AddHubOptions(options => options.MaximumReceiveMessageSize = 10 * 1024 * 1024);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddHubOptions(o => { o.MaximumReceiveMessageSize = 10 * 1024 * 1024; });
// Add authentication services
builder.Services.AddAuthentication("Cookies")
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AuthenticatedUser", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});
builder.Services.AddControllers();
builder.Services.AddRadzenComponents();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddRadzenServices();
builder.Services.AddGraphQLSharedServices(options => builder.Configuration.GetSection(AppSettings.SectionKey).Bind(options));
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped(x => {
    var appSettings =  builder.Configuration.GetSection("AppSettings");    
    return new HttpClient() { BaseAddress = new Uri(appSettings["APIUrl"]) };
});
builder.Services.AddSingleton<PageHistoryState>();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddLocalization();
var supportedCultures = new[]{new System.Globalization.CultureInfo("es-MX"),};
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("es-MX");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("es-MX"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");
app.Run();