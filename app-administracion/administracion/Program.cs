using administracion.Persistence.Database;
using administracion.Persistence.Entities;
using administracion.Persistence.DAOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddDbContext<AdminDBContex>( 
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("cnDatabase"))
    );
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IAdminDBContext, AdminDBContex>();
builder.Services.AddTransient<IAseguradoDAO, AseguradoDAO>();
builder.Services.AddTransient<IVehiculoDAO, VehiculoDAO>();
builder.Services.AddTransient<IPolizaDAO, PolizaDAO>();
builder.Services.AddTransient<IIncidenteDAO, IncidenteDAO>();

var app = builder.Build();
app.UseSwaggerUI();
app.UseSwagger( x => x.SerializeAsV2 = true);



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
