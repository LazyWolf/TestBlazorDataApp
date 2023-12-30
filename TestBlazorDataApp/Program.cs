using Microsoft.EntityFrameworkCore;
using Serilog;
using TestBlazorDataApp.Components;
using TestBlazorDataApp.Data;
using TestBlazorDataApp.Middleware;
using TestBlazorDataApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Services
builder.Services.AddScoped<TestService>();

// Add DbContext Factory
builder.Services.AddDbContextFactory<DataContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Options
builder.Services.Configure<ApplicationOptions>(builder.Configuration.GetSection(nameof(ApplicationOptions)));

// Add logging with Serilog
builder.Host.UseSerilog((context, configuration) => 
    configuration.ConfigureLogging(context));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseAntiforgery();
app.UseSerilogRequestLogging();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
