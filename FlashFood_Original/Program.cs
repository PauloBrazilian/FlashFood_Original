using FlashFood_Original;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Home/Login/";
        options.LoginPath = "/Home/Login/";
    });
builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer("Server=201.55.32.20;Database=FLASH;User Id=pw_tarde;Password=aluno123;trustServerCertificate=true") );
//("Data Source=DESKTOP-DMA7FVO\\SQLBIA;Database = DB_FlashFood;User ID=sa;Password= 91425836"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
