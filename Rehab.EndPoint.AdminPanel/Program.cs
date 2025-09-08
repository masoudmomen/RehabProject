using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Rehab.Application.Accreditations;
using Rehab.Application.Amenities;
using Rehab.Application.Common;
using Rehab.Application.Conditions;
using Rehab.Application.Contexts;
using Rehab.Application.Facilities;
using Rehab.Application.Highlights;
using Rehab.Application.Insurances;
using Rehab.Application.LevelsOfCare;
using Rehab.Application.SubstancesWeTreat;
using Rehab.Application.Tags;
using Rehab.Application.Treatments;
using Rehab.Application.Users;
using Rehab.Application.WhoWeTreat;
using Rehab.EndPoint.AdminPanel.CommonService;
using Rehab.EndPoint.AdminPanel.Components;
using Rehab.EndPoint.AdminPanel.MappingProfile;
using Rehab.Persistence.Contexts;
using Cropper.Blazor.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; })
    .AddHubOptions(options =>
     {
         options.MaximumReceiveMessageSize = 32 * 1024 * 100;
     });
#region Connection String
builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
var connection = builder.Configuration["ConnectionString:sqlServer"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(connection));
#endregion


#region IOC
builder.Services.AddAutoMapper(typeof(CommonMappingProfile)); //Mapper
builder.Services.AddAutoMapper(typeof(Rehab.Infrastructure.MappingProfile.CommonMappingProfile)); //Mapper
builder.Services.AddScoped<SearchService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IFacilityService, FacilityService>();
builder.Services.AddTransient<IInsuranceService, InsuranceService>();
builder.Services.AddTransient<IAccreditationService, AccreditationService>();
builder.Services.AddTransient<IAmenityService, AmenityService>();
builder.Services.AddTransient<IHighlightService, HighlightService>();
builder.Services.AddTransient<IWwtService, WwtService>();
builder.Services.AddTransient<ILevelsOfCareService, LevelsOfCareService>();
builder.Services.AddTransient<ITreatmentService, TreatmentService>();
builder.Services.AddTransient<IConditionService, ConditionService>();
builder.Services.AddTransient<ISubstancesWeTreatService, SwtService>();
builder.Services.AddTransient<ITagService,TagService>();
builder.Services.AddHttpClient<LocationService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<AlertService>();
builder.Services.AddScoped<IImageUploaderService, ImageUploaderService>();
#endregion
builder.Services.AddSingleton<HeadOutlet>();

builder.Services.AddCropper();






var app = builder.Build();

//app.MapBlazorHub();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.UsePathBase("/admin"); //for publish
app.UseRouting();
app.UseStaticFiles();
//app.MapBlazorHub();
//app.MapFallbackToPage("/App");

app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
