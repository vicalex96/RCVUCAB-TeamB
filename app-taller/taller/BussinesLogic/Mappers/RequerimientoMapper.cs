using taller.BussinesLogic.DTOs;
using taller.DataAcces.Entities;
using taller.DataAcces.Enums;

namespace taller.BussinesLogic.Mappers
{
    public class RequerimientoMapper
    {
        public static Requerimiento MapToEntity(RequerimientoDTO dto)
        {
            return new Requerimiento 
            {
                requerimientoId = dto.Id,
                parteId = dto.parteId,


            };
        }
        public static Requerimiento  MapToEntity(RequerimientoRegisterDTO dto)
        {
            return new Requerimiento  
            {
               
                parteId = dto.parteId,
           
            };
        }
        

        public static RequerimientoDTO MapToDTO (Requerimiento entity)
        {
            return new RequerimientoDTO
            {
                Id = entity.requerimientoId,
                parteId = entity.parteId,
                
                
            };
        }




    }
}