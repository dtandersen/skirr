using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.AspNetCore.HttpLogging;
using Skirr;
using Skirr.Repository;
// using WebAll.Components;



// DiscoveryListener.StartListener();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddRazorComponents()
//     .AddInteractiveServerComponents();
// builder.Services.AddRazorPages();
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});
builder.Services.AddControllersWithViews();
builder.Services.AddHttpLogging(o => { });
// builder.Services.AddControllers(options =>
//   {
//       var jsonInputFormatter = options.InputFormatters
//           .OfType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>()
//           .Single();
//       jsonInputFormatter.SupportedMediaTypes.Add("application/json");
//   }
//   );
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = false;
    options.SerializerOptions.PropertyNamingPolicy = null;
    options.SerializerOptions.WriteIndented = true;
});
// builder.Services.AddHostedService<X>();
builder.Services.AddHostedService<ConsumeScopedServiceHostedService>();
builder.Services.AddScoped<IScopedProcessingService, DiscoveryListener2>();
builder.Services.AddSingleton<ConfiguredDevices, ConfiguredDevicesStub>();
builder.Services.AddSingleton<CommandFactory>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// builder.WebHost.UseUrls("http://localhost:5000", "https://localhost:5001");
var app = builder.Build();
// app.UseRequestCulture();
app.UseMiddleware<CustomExceptionMiddleware>();
app.UseMiddleware<RequestResponseLoggerMiddleware>();
app.UseHttpLogging();
// Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
// app.UseExceptionHandler("/Error");
// app.UseHsts();
// }

// app.UseHttpsRedirection();
app.UseStaticFiles();

// app.UseAuthorization();

// app.MapGet("/hi", () => "Hello!");

// app.MapDefaultControllerRoute();
// app.MapRazorPages();

// app.MapRazorComponents<App>()
//     .AddInteractiveServerRenderMode();

// app.UseAntiforgery();
app.MapControllers();
app.Run();
// app.Run("http://localhost:5001");
