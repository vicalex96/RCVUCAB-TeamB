using taller.BussinesLogic.DTOs;
using taller.DataAcces.Entities;
using taller.DataAcces.Enums;

namespace taller.BussinesLogic.Mappers
{
    public class CotizacionReparacionMapper
    {
        public static CotizacionReparacion MapToEntity(CotizacionRepDTO dto)
        {
            return new CotizacionReparacion
            {
                cotizacionRepId = dto.CotizacionRepId,
                tallerId = dto.tallerId,
                costoManoObra = dto.costoManoObra,
                estado = (EstadoCotRep)Enum.Parse(typeof(EstadoCotRep), dto.estado),
                fechaInicioReparacion = dto.fechaInicioReparacion,
                fechaFinReparacion = dto.fechaFinReparacion,
                solicitudRepId = dto.solicitudRepId,

                
            };
        }
        
        public static CotizacionReparacion MapToEntity ( CotizacionRepRegisterDTO dto)
        {
            CotizacionReparacion cotizacionReparacion = new CotizacionReparacion();
            cotizacionReparacion.tallerId = dto.tallerId;
            cotizacionReparacion.estado= EstadoCotRep.Pendiente;
            cotizacionReparacion.fechaInicioReparacion = DateTime.Today;
            return cotizacionReparacion;
            
        }

        public static CotizacionRepDTO MapToDTO (CotizacionReparacion entity)
        {
            return new CotizacionRepDTO
            {
                CotizacionRepId = entity.cotizacionRepId,
                tallerId = entity.tallerId,
                costoManoObra = entity.costoManoObra,
                estado = entity.estado.ToString(),
                fechaInicioReparacion = entity.fechaInicioReparacion,
                fechaFinReparacion = entity.fechaFinReparacion,
                solicitudRepId = entity.solicitudRepId,
                
            };
        } 
            
        public static CotizacionRepDTO MapToDTO (CotizacionRepRegisterDTO  registerDTO, Guid CotizacionRepId)
        {
            return new CotizacionRepDTO
            {
                CotizacionRepId = CotizacionRepId,
                tallerId = registerDTO.tallerId,
                estado = EstadoCotRep.Pendiente.ToString(),
            };
        }
       




    }
}