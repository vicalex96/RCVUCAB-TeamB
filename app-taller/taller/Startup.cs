using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using taller.DataAcces.Database;
using System.Threading;
using taller.Conections.rabbit;
using taller.DataAcces.DAOs;
using taller.DataAcces.APIs;

namespace taller
{
    public class Startup
    {
        private readonly string  _MyCors ="Mycors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            
            services.AddControllers();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<TallerDBContext>( 
                o => o.UseNpgsql(Configuration.GetConnectionString("cnDatabase"))
                );

            services.AddTransient<ITallerDBContext, TallerDBContext>();
            services.AddTransient<IConsumerRabbit, ConsumerRabbit>();
            services.AddTransient<IProductorRabbit, ProductorRabbit>();

            services.AddTransient<ITallerDAO, TallerDAO>();
            services.AddTransient<ICotizacionRepDAO, CotizacionRepDAO>();
            services.AddTransient<IParteDAO, ParteDAO>();
            services.AddTransient<IRequerimientoDAO, RequerimientoDAO>();
            //services.AddTransient<ISolicitudDAO, SolicitudDAO>();
            
            services.AddTransient<ITallerAPI, TallerAPI>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "talleres", Version = "v1" });
            });

            //Habilitando politicas del CORS para el consumo del Backend como API
            services.AddRouting(routing => routing.LowercaseUrls = true);
            services.AddCors(options =>
            {
                options.AddPolicy(name: _MyCors, builder => 
                {
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyHeader().AllowAnyMethod();
                });
            });

            /*services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<TallerConsumer>();

                cfg.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(new Uri("rabbitmq://localhost"), h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });
                    cfg.ReceiveEndpoint("Taller", c =>{
                        c.ConfigureConsumer<TallerConsumer>(ctx);
                        c.ClearSerialization();
                        c.UseRawJsonSerializer();
                    });
                });
            });*/


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            //agregamos las politicas del CORS al app
            //app.UseCors(_MyCors);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI( c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","My API V1");
            });
        }
        /*public void Comunicador(object routing)
        {   
            ClienteRabbit server = new ClienteRabbit();
            server.startReceiverAdmin((string) routing);
        }*/
    }
}
