using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Application.Facilities;
using Rehab.Application.Insurances;
using Rehab.Application.Users;
using Rehab.EndPoint.AdminPanel.CommonService;
using Rehab.EndPoint.AdminPanel.Components;
using Rehab.EndPoint.AdminPanel.MappingProfile;
using Rehab.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddRazorPages();

#region Connection String
builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
var connection = builder.Configuration["ConnectionString:sqlServer"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(connection));
#endregion


#region IOC
builder.Services.AddAutoMapper(typeof(CommonMappingProfile)); //Mapper
builder.Services.AddAutoMapper(typeof(Rehab.Infrastructure.MappingProfile.CommonMappingProfile)); //Mapper
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IFacilityService, FacilityService>();
builder.Services.AddTransient<IInsuranceService, InsuranceService>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<AlertService>();
builder.Services.AddScoped<IImageUploaderService, ImageUploaderService>();
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UsePathBase("/admin");
app.UseRouting();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
