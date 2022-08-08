using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using levantamiento.DataAccess.DAOs;
using levantamiento.DataAccess.Database;
using levantamiento.DataAccess.APIs;
using MassTransit;
using levantamiento.DataAccess.DAOs.MQ;

namespace levantamiento
{
    public class Startup
    {
        private readonly string  _MyCors ="Mycors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            
                
            services.AddTransient<ILevantamientoDBContext, LevantamientoDBContext>();


            services.AddTransient<IIncidenteDAO, IncidenteDAO>();
            services.AddTransient<ISolicitudReparacionDAO, SolicitudReparacionDAO>();
            services.AddTransient<IRequerimientoDAO, RequerimientoDAO>();
            services.AddTransient<IParteDAO, ParteDAO>();
            

            services.AddTransient<IVehiculoAPI, VehiculoAPI>();
            services.AddTransient<IIncidenteAPI, IncidenteAPI>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "levantamiento", 
                    Version = "v1" 
                });
                
            });
            services.AddRouting(routing => routing.LowercaseUrls = true);

            services.AddCors(options =>
            {
                options.AddPolicy(name: _MyCors, builder => 
                {
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyHeader().AllowAnyMethod();
                });

            });

            
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<IncidenteConsumer>();

                cfg.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(new Uri("rabbitmq://localhost"), h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });
                    cfg.ReceiveEndpoint("Incidente", c =>{
                        c.ConfigureConsumer<IncidenteConsumer>(ctx);
                        c.ClearSerialization();
                        c.UseRawJsonSerializer();
                    });
                });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI( c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","My API V1");
                c.RoutePrefix = "";
            });
        }
    }
}