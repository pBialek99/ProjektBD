using F.___J._Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// RZECZY BAZODANOWE -- START
builder.Services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddDefaultIdentity<DefaultUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<LibraryDbContext>();
// RZECZY BAZODANOWE ---- END

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedData(services);
}

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

static async Task SeedData(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<DefaultUser>>();

    string[] roles = { "Admin", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    var adminEmail = "admin@mail.com";
    var adminPassword = "qwertY1#";
    var firstName = "Gary";
    var lastName = "Gray";
    var street = "Normal st. 8";
    var city = "Krakow";
    var phoneNumber = "123456789";


    if (await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var adminUser = new DefaultUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            FirstName = firstName,
            LastName = lastName,
            Street = street,
            City = city,
            PhoneNumber = phoneNumber,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(adminUser, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}