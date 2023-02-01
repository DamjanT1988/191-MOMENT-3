using _191_MOMENT_3_TEST1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//connect to db
builder.Services.AddDbContext<GuestbookContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultDbString")));


var app = builder.Build();


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
    pattern: "{controller=Guestbook}/{action=Index}/{id?}");

app.Run();
