
using Ateliware.WebApp.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region DataBase

    //defaultConnection
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("defaultConnection")));

    ////Postgresql
    //builder.Services.AddDbContext<AppDbContext>(options =>
    //    options.UseNpgsql(
    //        builder.Configuration.GetConnectionString("NpgsqlConnection")));
    ////Somente se a vers�o do Npgsql for 6.0
    //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

#endregion// DataBase

#region HttpClient

builder.Services.AddHttpClient();

#endregion //HttpClient

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
