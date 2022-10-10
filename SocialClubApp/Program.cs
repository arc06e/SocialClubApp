using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialClubApp.DAL;
using SocialClubApp.Helpers;
using SocialClubApp.Interfaces;
using SocialClubApp.Models;
using SocialClubApp.Repositories;
using SocialClubApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IClubRepository, ClubRepository>();
builder.Services.AddScoped<IMeetingRepository, MeetingRepository>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.Configure<CloudinarySettings>(
    builder.Configuration.GetSection("CloudinarySettings"));
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

builder.Services.AddAuthorization(options =>
{
    //   Roles are still available for backwards compatibility -
    //   recommend not using Roles as claims, but rather using a claims.
    //options.AddPolicy("RequireAdministratorRole",
    //    policy => policy.RequireRole("Admin"));

    //    A claim is a name value pair that represents what the subject is,
    //    not what the subject can do.  
    options.AddPolicy("AdminPolicy",
        policy => policy.RequireClaim("Admin")
                        .RequireClaim("Mod"));

    options.AddPolicy("ModPolicy",
        policy => policy.RequireClaim("Mod"));

    //options.AddPolicy("DeleteRolePolicy",
    //    policy => policy.RequireClaim("Delete Role"));
    //options.AddPolicy("DeleteClubPolicy",
    //    policy => policy.RequireClaim("Delete Club"));
    //options.AddPolicy("DeleteMeetingPolicy",
    //    policy => policy.RequireClaim("Delete Meeting"));
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
//want to authenticate users before we reach MVC route middleware
//authentication - identify who the user is
app.UseAuthentication();
//authorization - identify what the user can and cannot do - authenticate before authorizing
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
