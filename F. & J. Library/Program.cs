using F.___J._Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// RZECZY BAZODANOWE -- START
builder.Services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddDefaultIdentity<DefaultUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LibraryDbContext>();
// RZECZY BAZODANOWE ---- END

//builder.Services.AddDefaultIdentity<DefaultUser>().AddEntityFrameworkStores<LibraryDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapStaticAssets();

// glowne
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// dla ksiazek
app.MapControllerRoute(
    name: "book",
    pattern: "Books/{action=Index}/{id?}")
    .WithStaticAssets();

// dla dla wypozyczonych
app.MapControllerRoute(
    name: "borrowedBook",
    pattern: "BorrowedBook/{action=Index}/{id?}")
    .WithStaticAssets();

// dla kategorii
app.MapControllerRoute(
    name: "category",
    pattern: "Cattegory/{action=Index}/{id?}")
    .WithStaticAssets();

// dla wydawcy
app.MapControllerRoute(
    name: "publisher",
    pattern: "Publisher/{action=Index}/{id?}")
    .WithStaticAssets();



app.Run();
