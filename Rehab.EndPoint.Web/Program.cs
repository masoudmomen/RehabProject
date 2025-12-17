using Microsoft.EntityFrameworkCore;
using Rehab.Application.Accreditations;
using Rehab.Application.Amenities;
using Rehab.Application.Conditions;
using Rehab.Application.Contexts;
using Rehab.Application.Facilities;
using Rehab.Application.Highlights;
using Rehab.Application.Insurances;
using Rehab.Application.LevelsOfCare;
using Rehab.Application.SubstancesWeTreat;
using Rehab.Application.Tags;
using Rehab.Application.Treatments;
using Rehab.Application.WhoWeTreat;
using Rehab.EndPoint.Web.Components;
using Rehab.EndPoint.Web.MappingProfile;
using Rehab.Persistence.Contexts;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

#region Connection String
builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
var connection = builder.Configuration["ConnectionString:sqlServer"];
builder.Services.AddDbContext<DatabaseContext>(option=>option.UseSqlServer(connection));
#endregion

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(connection).EnableSensitiveDataLogging().LogTo(Console.WriteLine));

#region IOC
builder.Services.AddAutoMapper(typeof(CommonMappingProfile)); //Mapper
builder.Services.AddAutoMapper(typeof(Rehab.EndPoint.Web.MappingProfile.CommonMappingProfile)); //Mapper
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
builder.Services.AddTransient<ITagService, TagService>();
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

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
