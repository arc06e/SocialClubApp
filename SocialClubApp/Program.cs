using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialClubApp.DAL;
using SocialClubApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//registers dependency with dependency injection container
builder.Services.AddDbContext<ApplicationDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});                          //inherits from IdentityUser
builder.Services.AddIdentity<AppUser, IdentityRole>()
    //uses EFCore to retrieve user and role info from underlying SQL server db
    .AddEntityFrameworkStores<ApplicationDbContext>();
    //figure out if you need this
    //.AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);
builder.Services.AddAuthentication();

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
//want to authenticate users before we reach MVC route middleware
//authentication - identify who the user is
app.UseAuthentication();
//authorization - identify what the user can and cannot do - authenticate before authorizing
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
