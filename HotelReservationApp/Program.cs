using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.Managers;
using HotelReservationApp.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyDbContextConnection") ?? throw new InvalidOperationException("Connection string 'MyDbContextConnection' not found.");

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<MyDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<HotelService>();
builder.Services.AddScoped<CityService>();
builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IHotelService, HotelService>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
