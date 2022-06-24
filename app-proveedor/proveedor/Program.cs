var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
//builder.Services.AddDbContext<ProveedorDbContext>( 
 //   o => o.UseNpgsql(builder.Configuration.GetConnectionString("cnDatabase"))
  //  );
builder.Services.AddSwaggerGen();

//builder.Services.AddTransient<IProveedorDbContext, ProveedorDbContext>();
//builder.Services.AddTransient<IAseguradoDAO, AseguradoDAO>();
//builder.Services.AddTransient<IVehiculoDAO, VehiculoDAO>();
//builder.Services.AddTransient<IPolizaDAO, PolizaDAO>();
//builder.Services.AddTransient<IIncidenteDAO, IncidenteDAO>();

var app1 = builder.Build();
app1.UseSwaggerUI();
app1.UseSwagger( x => x.SerializeAsV2 = true);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
