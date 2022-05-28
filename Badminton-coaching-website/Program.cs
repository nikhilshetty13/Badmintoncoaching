using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Badminton_coaching_website.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Badminton_coaching_websiteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Badminton_coaching_websiteContext") ?? throw new InvalidOperationException("Connection string 'Badminton_coaching_websiteContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
