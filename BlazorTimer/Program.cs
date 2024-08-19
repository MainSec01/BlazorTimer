using ActualLab.Fusion;
using ActualLab.Fusion.Extensions;
using ActualLab.Fusion.Blazor;
using BlazorTimer.Services;
using BlazorTimer.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Data;
using BlazorTimer.Data.IRepositories;
using BlazorTimer.Data.Repositories;
using BlazorTimer.Modals;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddOptions();

builder.Services.AddDbContext<BlazerTimerAppDbContext>(options => options.
    UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var fusion = builder.Services.AddFusion();
fusion.AddBlazor();
fusion.AddFusionTime();
builder.Services.AddScoped<IRepository<TimerInfo>, Repository<TimerInfo>>();
builder.Services.AddScoped<ITimerService, TimerService>();

builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
