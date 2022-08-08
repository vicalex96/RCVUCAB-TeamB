using taller.BussinesLogic.DTOs;
using taller.DataAcces.Entities;
using taller.DataAcces.Enums;

namespace taller.BussinesLogic.Mappers
{
    public class ParteMapper
    {
        public static Parte MapToEntity(ParteDTO dto)
        {
            return new Parte 
            {
                
                parteId = dto.Id,
                nombre = dto.nombre,


            };
        }
        public static Parte  MapToEntity(ParteRegisterDTO dto)
        {
            return new Parte  
            {
               
                parteId = dto.Id,
                nombre = dto.nombre,
           
            };
        }
        

        public static ParteDTO MapToDTO (Parte entity)
        {
            return new ParteDTO
            {
                Id = entity.parteId,
                nombre = entity.nombre,
                
                
            };
        }




    }
}