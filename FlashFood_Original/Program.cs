using FlashFood_Original;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer
    //("Data Source=DESKTOP-DMA7FVO\\SQLBIA;Database = DB_FlashFood;User ID=sa;Password= 91425836"));
("Data Source = DESKTOP-DMA7FVO; Initial Catalog =BD_FlashFood; Persist Security Info=True; User ID =sa; Password =91425836"));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
