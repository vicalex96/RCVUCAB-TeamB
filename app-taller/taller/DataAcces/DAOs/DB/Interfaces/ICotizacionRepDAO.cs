using taller.DataAcces.Entities;
using taller.BussinesLogic.DTOs;
using  taller.DataAcces.Enums;
using System.Collections.Generic;

namespace taller.DataAcces.DAOs
{
    public interface ICotizacionRepDAO
    {
        
        public List<CotizacionRepDTO> GetCotizaciones();
        public CotizacionRepDTO GetCotizacionRep(Guid SolicutdId);
        public bool RegisterCotizacionReparacion(CotizacionRepSimpleDTO cotizacionRep);
        public bool UpdateEstadoCotizacion(Guid cotizacionRepId, EstadoCotRep estado);
        public bool UpdateFechaInicioReparacion(Guid cotizacionRepId,DateTime fechaInicio);
        public bool UpdateFechaFinReparacion(Guid cotizacionRepId,DateTime fechaFin);
        
    }


}