using Microsoft.EntityFrameworkCore;
using MyBlazorApp.Server.Data;
using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Server.Services;
using MyBlazorApp.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>
    (options =>
   //    options.UseInMemoryDatabase("Journal"));
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWorkTimeService, WorkTimeService>();
builder.Services.AddScoped<IVacationService,VacationService>();
builder.Services.AddScoped<IHolidayService, HolidayService>();

//builder.Services.AddScoped<UserDto>();
//builder.Services.AddScoped<WorkTimeDto>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
