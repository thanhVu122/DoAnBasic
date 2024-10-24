using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bai_ThucHanh.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Bai_ThucHanhContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Bai_ThucHanhContext") ?? throw new InvalidOperationException("Connection string 'Bai_ThucHanhContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
//->>
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
//<-- Day la su dung cookie de xac thuc
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

//<-- Day la su dung cookie de xac thuc
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
