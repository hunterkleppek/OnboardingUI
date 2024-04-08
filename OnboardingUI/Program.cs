using Autofac;
using Autofac.Extensions.DependencyInjection;
using Fluxor;
using Microsoft.AspNetCore.Server.IISIntegration;
using MudBlazor;
using MudBlazor.Services;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using OnboardingUI.Data.Services;
using OnboardingUI.Domain;
using OnboardingUI.Domain.Entities;
using Secura.Infrastructure.Autofac;
using Secura.Infrastructure.Logging.NLog;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
using NLogLoggerFactory = Secura.Infrastructure.Logging.NLog.NLogLoggerFactory;

#region Environement and Logging Configuration
var builder = WebApplication.CreateBuilder(args);
IWebHostBuilder webHostBuilder = builder.WebHost;

webHostBuilder.ConfigureLogging(x =>
{
    x.ClearProviders();
    x.SetMinimumLevel(LogLevel.Trace);
}).UseNLog();

var environment = builder.Environment;
var environmentConfiguration = new ConfigurationBuilder()
    .SetBasePath(environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true)
    .AddEnvironmentVariables();

IConfiguration configuration = environmentConfiguration.Build();
LogManager.Configuration = new NLogLoggingConfiguration(configuration.GetSection("NLog"));
#endregion

#region Authentication Registration
builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme);
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(typeof(Program).Assembly);
#if DEBUG
    options.UseReduxDevTools(rdt =>
    {
        rdt.Name = "OnboardingUI";
    });
#endif
});
builder.Services.AddScoped<StateFacade>();
#endregion

#region MudBlazor Registration
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});
#endregion

#region Dependency Injection Registration
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule<LoggingModule<NLogLoggerFactory, NLogRetrieveLogs>>();
    containerBuilder.RegisterModule<OnboardingUiDomainModule>();
    containerBuilder.RegisterType<EnterpriseSoftwareList>().AsSelf().SingleInstance();
});
#endregion

#region Application Build
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

#endregion
