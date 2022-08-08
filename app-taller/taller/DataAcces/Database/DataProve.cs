using taller.DataAcces.Entities;
using  taller.DataAcces.Enums;
namespace taller.DataAcces.Database
{
    public class DataProve
    {
        public List<Taller> tallerInit = new List<Taller>();
        //public List<Vehiculo> vehiculoInit = new List<Vehiculo>();
        public List<SolicitudReparacion> solicitudRepInit = new List<SolicitudReparacion>();
        public List<Requerimiento> requerimientoInit = new List<Requerimiento>();
        public List<Parte> parteInit = new List<Parte>();
        public List<CotizacionReparacion> cotizacionInit = new List<CotizacionReparacion>();
        public List<MarcaTaller> marcaInit = new List<MarcaTaller>();

        public DataProve()
        {
            getTallerData();
            //getVehiculoData();
            getSolicitudRepData();
            getPartesData();
            getRequerimientosData();
            getMarcaTallerData();
            getCotizacionReparacionData();
        }
        public void getTallerData()
        {
            this.tallerInit.Add( new Taller{
                    Id = Guid.Parse("10003262-d5ef-46c7-bc0e-97530823c05b"),
                    nombreLocal = "Taller de Pepito"
                }
            );
            this.tallerInit.Add( new Taller{
                    Id = Guid.Parse("20003262-d5ef-46c7-bc0e-97530823c05b"),
                    nombreLocal = "MadMonkey"
                }
            );
            this.tallerInit.Add( new Taller{
                    Id = Guid.Parse("30003262-d5ef-46c7-bc0e-97530823c05b"),
                    nombreLocal = "Locos Por los Autos"
                }
            );
            this.tallerInit.Add( new Taller{
                    Id = Guid.Parse("40003262-d5ef-46c7-bc0e-97530823c05b"),
                    nombreLocal = "Roller Customs"
                }
            );
        }
    /*    public void getVehiculoData()
        {
            this.vehiculoInit.Add( new Vehiculo
            {
                vehiculoId=Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                aseguradoId= Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c03b"),
                anioModelo = 2004,
                fechaCompra = DateTime.ParseExact("20-06-2018", "dd-MM-yyyy",null),
                color = Color.Verde,
                placa = "AB320AM",
                //marcaName = marcaName.Toyota,
            });
            vehiculoInit.Add(new Vehiculo(){
                vehiculoId=Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c05b"),
                aseguradoId= Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c03f"),
                anioModelo = 2006,
                fechaCompra = DateTime.ParseExact("15-06-2010", "dd-MM-yyyy",null),
                color = Color.Naranja,
                placa = "AB322AM",
                //marcaName = marcaName.Hyundai

            });
            
        }*/
        public void getMarcaTallerData()
        {
            this.marcaInit.Add(new MarcaTaller(){
                Id = Guid.Parse("0c5c3262-15ef-46c7-bc0e-97530821c04b"),
                tallerId = Guid.Parse("10003262-d5ef-46c7-bc0e-97530823c05b"),
                marcaName = MarcaName.Toyota,
            });
            this.marcaInit.Add(new MarcaTaller(){
                Id = Guid.Parse("0c5c3262-25ef-46c7-bc0e-97530821c04b"),
                tallerId=Guid.Parse("10003262-d5ef-46c7-bc0e-97530823c05b"),
                marcaName = MarcaName.Honda,
            });
            this.marcaInit.Add(new MarcaTaller(){
                Id = Guid.Parse("0c5c3262-35ef-46c7-bc0e-97530821c04b"),
                tallerId=Guid.Parse("20003262-d5ef-46c7-bc0e-97530823c05b"),
                marcaName = MarcaName.Hyundai,
            });
            this.marcaInit.Add(new MarcaTaller(){
                Id = Guid.Parse("0c5c3262-45ef-46c7-bc0e-97530821c04b"),
                tallerId=Guid.Parse("20003262-d5ef-46c7-bc0e-97530823c05b"),
                marcaName = MarcaName.Volkswagen,
            });
            this.marcaInit.Add(new MarcaTaller(){
                Id = Guid.Parse("0c5c3262-55ef-46c7-bc0e-97530821c04b"),
                tallerId=Guid.Parse("30003262-d5ef-46c7-bc0e-97530823c05b"),
                marcaName = MarcaName.Ford,
            });
            this.marcaInit.Add(new MarcaTaller(){
                Id = Guid.Parse("0c5c3262-65ef-46c7-bc0e-97530821c04b"),
                tallerId=Guid.Parse("30003262-d5ef-46c7-bc0e-97530823c05b"),
                marcaName = MarcaName.Ferrari,
            });
        }
       public void getCotizacionReparacionData()
        {
            this.cotizacionInit.Add(new CotizacionReparacion()
            {
                cotizacionRepId = Guid.Parse("1c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                solicitudRepId = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                tallerId = Guid.Parse("10003262-d5ef-46c7-bc0e-97530823c05b"),
                costoManoObra = 200,
                estado = EstadoCotRep.Facturado,
                fechaInicioReparacion = new DateTime(2022, 1, 06),
                fechaFinReparacion = new DateTime(2022, 1, 20),
            });
            this.cotizacionInit.Add(new CotizacionReparacion()
            {
                cotizacionRepId = Guid.Parse("1c5c3262-d5ef-46c7-bc0e-97530821c02b"),
                solicitudRepId = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c01b"),
                tallerId = Guid.Parse("10003262-d5ef-46c7-bc0e-97530823c05b"),
                costoManoObra = 250,
                estado = EstadoCotRep.Facturado,
                fechaInicioReparacion = new DateTime(2022, 02, 08),
                fechaFinReparacion = new DateTime(2022, 02, 20),
            });
            this.cotizacionInit.Add(new CotizacionReparacion()
            {
                cotizacionRepId = Guid.Parse("1c5c3262-d5ef-46c7-bc0e-97530821c03b"),
                solicitudRepId = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c02b"),
                tallerId = Guid.Parse("10003262-d5ef-46c7-bc0e-97530823c05b"),
                costoManoObra = 150,
                estado = EstadoCotRep.Facturado,
                fechaInicioReparacion = new DateTime(2022, 03, 06),
                fechaFinReparacion = new DateTime(2022, 03, 20),
            });
            this.cotizacionInit.Add(new CotizacionReparacion()
            {
                cotizacionRepId = Guid.Parse("1c5c3262-d5ef-46c7-bc0e-97530821c01b"),
                solicitudRepId = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c06b"),
                tallerId = Guid.Parse("30003262-d5ef-46c7-bc0e-97530823c05b"),
                costoManoObra = 200,
                estado = EstadoCotRep.Facturado,
                fechaInicioReparacion = new DateTime(2022, 01, 06),
                fechaFinReparacion = new DateTime(2022, 01, 25),
            });
            this.cotizacionInit.Add(new CotizacionReparacion()
            {
                cotizacionRepId = Guid.Parse("1c5c3262-d5ef-46c7-bc0e-97530821c05b"),
                solicitudRepId = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c11b"),
                tallerId = Guid.Parse("30003262-d5ef-46c7-bc0e-97530823c05b"),
                costoManoObra = 200,
                estado = EstadoCotRep.Facturado,
                fechaInicioReparacion = new DateTime(2022, 04, 06),
                fechaFinReparacion = new DateTime(2022, 04, 25),
            });
            this.cotizacionInit.Add(new CotizacionReparacion()
            {
                cotizacionRepId = Guid.Parse("1c5c3262-d5ef-46c7-bc0e-97530821c06b"),
                solicitudRepId = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c12b"),
                tallerId = Guid.Parse("20003262-d5ef-46c7-bc0e-97530823c05b"),
                costoManoObra = 200,
                estado = EstadoCotRep.Facturado,
                fechaInicioReparacion = new DateTime(2022, 05, 05),
                fechaFinReparacion = new DateTime(2022, 05, 10),
            });
        }    
        public void getSolicitudRepData()
        {
            this.solicitudRepInit.Add(new SolicitudReparacion()
            {
                Id = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                //incidenteId = Guid.Parse("10000000-d5ef-46c7-bc0e-97530823c05b"),
               // vehiculoId = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                tallerId = Guid.Parse("10003262-d5ef-46c7-bc0e-97530823c05b"),
                fechaSolicitud = new DateTime(2022, 01, 06),
            });
            this.solicitudRepInit.Add(new SolicitudReparacion()
            {
                Id = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c01b"),
                //incidenteId = Guid.Parse("10000000-d5ef-46c7-bc0e-97530823c04b"),
               // vehiculoId = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                tallerId = Guid.Parse("10003262-d5ef-46c7-bc0e-97530823c05b"),
                fechaSolicitud = new DateTime(2022, 02, 06),
            });


            this.solicitudRepInit.Add(new SolicitudReparacion()
            {
                Id = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c02b"),
                //incidenteId = Guid.Parse("10000000-d5ef-46c7-bc0e-97530823c03b"),
               // vehiculoId = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                tallerId = Guid.Parse("10003262-d5ef-46c7-bc0e-97530823c05b"),
                fechaSolicitud = new DateTime(2022, 02, 08),
            });

            this.solicitudRepInit.Add(new SolicitudReparacion()
            {
                Id = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c06b"),
                //incidenteId = Guid.Parse("10000000-d5ef-46c7-bc0e-97530823c06b"),
                //vehiculoId = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                tallerId = Guid.Parse("30003262-d5ef-46c7-bc0e-97530823c05b"),
                fechaSolicitud = new DateTime(2022, 01, 10),
            });

            this.solicitudRepInit.Add(new SolicitudReparacion()
            {
                Id = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c11b"),
                //incidenteId = Guid.Parse("10000000-d5ef-46c7-bc0e-97530823c11b"),
                //vehiculoId = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                tallerId = Guid.Parse("30003262-d5ef-46c7-bc0e-97530823c05b"),
                fechaSolicitud = new DateTime(2022, 03, 06),
            });
             this.solicitudRepInit.Add(new SolicitudReparacion()
            {
                Id = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c12b"),
                //incidenteId = Guid.Parse("10000000-d5ef-46c7-bc0e-97530823c12b"),
                //vehiculoId = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                tallerId = Guid.Parse("20003262-d5ef-46c7-bc0e-97530823c05b"),
                fechaSolicitud = new DateTime(2022, 02, 06),
            });
        }
        public void getPartesData()
        {
            parteInit.Add( new Parte{
                parteId = Guid.Parse( "0c5c3262-d5ef-46c7-1000-97530821c04b"),
                nombre = "puerta izquierda delantera",
            });
            parteInit.Add( new Parte{
                parteId = Guid.Parse( "0c5c3262-d5ef-46c7-2000-97530821c04b"),
                nombre = "puerta derecha delantera", 
            });
            parteInit.Add( new Parte{
                parteId = Guid.Parse( "0c5c3262-d5ef-46c7-3000-97530821c04b"),
                nombre = "rueda", 
            });
            parteInit.Add( new Parte{
                parteId = Guid.Parse( "0c5c3262-d5ef-46c7-4000-97530821c04b"),
                nombre = "capó de motor", 
            });
            parteInit.Add( new Parte{
                parteId = Guid.Parse( "0c5c3262-d5ef-46c7-5000-97530821c04b"),
                nombre = "capó de maleta", 
            });
            parteInit.Add( new Parte{
                parteId = Guid.Parse( "0c5c3262-d5ef-46c7-7000-97530821c04b"),
                nombre = "rin", 
            });
        }
        public void getRequerimientosData()
        {
            requerimientoInit.Add( new Requerimiento{
                requerimientoId = Guid.Parse("0c5c3262-d5ef-1000-bc0e-97530821c04b"),
                solicitudRepId = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                parteId = Guid.Parse( "0c5c3262-d5ef-46c7-2000-97530821c04b"),
                //descripcion = "puerta detrozada parcialmente",
                tipoRequerimiento = TipoRequerimiento.Reparacion,
                cantidad = 1,
                estado = EstadoRequerimiento.PorEntregar, 
            });
            requerimientoInit.Add( new Requerimiento{
                requerimientoId = Guid.Parse("0c5c3262-d5ef-2000-bc0e-97530821c04b"),
                solicitudRepId = Guid.Parse("0c5c3262-d5ef-46c7-bc0e-97530821c04b"),
                parteId = Guid.Parse( "0c5c3262-d5ef-46c7-5000-97530821c04b"),
                //descripcion = "cambio capó de la maleta",
                tipoRequerimiento = TipoRequerimiento.ComprarPieza,
                cantidad = 1,
                estado = EstadoRequerimiento.PorEntregar, 
            });
        }
    }
}
