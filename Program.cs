using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Host.UseWindowsService();
builder.Services.AddWindowsService();
builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.ListenAnyIP(5001);
    options.ConfigureEndpointDefaults(endpointOptions =>
    {
        endpointOptions.UseHttps("path-to-certificate.pfx", "certificate-password");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
