using taller.BussinesLogic.DTOs;
using taller.DataAcces.Entities;
using taller.DataAcces.Enums;

namespace taller.BussinesLogic.Mappers
{
    public class SolicitudReparacionMapper
    {
        public static SolicitudReparacion MapToEntity(SolicitudesReparacionDTO dto)
        {
            return new SolicitudReparacion 
            {
                Id = dto.Id,
                tallerId = dto.tallerId,
                
                


            };
        }
        public static SolicitudReparacion MapToEntity(SolicitudRepacionRegisterDTO dto)
        {
            return new SolicitudReparacion 
            {
                RequerimientoId = dto.requerimientoId,
                tallerId = dto.tallerId
           
            };
        }
        

        public static SolicitudesReparacionDTO MapToDTO (SolicitudReparacion entity)
        {
            return new SolicitudesReparacionDTO
            {
                Id = entity.Id,
                tallerId = entity.tallerId,
                
            };
        }




    }
}