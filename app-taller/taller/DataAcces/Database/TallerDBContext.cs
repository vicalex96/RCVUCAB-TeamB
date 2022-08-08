using Microsoft.EntityFrameworkCore;
using taller.DataAcces.Entities;

namespace taller.DataAcces.Database
{
    public class TallerDBContext: DbContext, ITallerDBContext
    {
        public TallerDBContext(){}

        public TallerDBContext(DbContextOptions<TallerDBContext> options) : base(options)
        {
        }
        
        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }
        public virtual DbSet<Taller> Talleres{get; set;}
        public virtual DbSet<MarcaTaller> Marcas {get; set;}
        public virtual DbSet<SolicitudReparacion> SolicitudReparacions  {get; set;}

        public virtual DbSet<Requerimiento> Requerimientos {get; set;}
        public virtual DbSet<Parte> partes {get; set;}
        public virtual DbSet<CotizacionReparacion> CotizacionReparaciones {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            DataProve data = new DataProve();
            

            modelBuilder.Entity<MarcaTaller>( marca => {
                marca.HasKey(p => p.Id);
                marca.HasData(data.marcaInit);
            });


            modelBuilder.Entity<CotizacionReparacion>(cot => {
                cot.HasKey(p => p.cotizacionRepId);

            });

            modelBuilder.Entity<SolicitudReparacion>(s =>
            {
                s.HasData(data.solicitudRepInit);
            });

            modelBuilder.Entity<Taller>(r =>
            {
                r.HasData(data.tallerInit);
            });
            modelBuilder.Entity<MarcaTaller>(r =>
            {
                r.HasData(data.marcaInit);
            });
            
            modelBuilder.Entity<Requerimiento>(r =>
            {
                r.HasData(data.requerimientoInit);
            });
            
            modelBuilder.Entity<Parte>(p =>
            {
                p.HasData(data.parteInit);
            });
            
            
            

        }
    }
}