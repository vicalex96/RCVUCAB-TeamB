using taller.BussinesLogic.DTOs;
using taller.DataAcces.Entities;
using taller.DataAcces.Enums;

namespace taller.BussinesLogic.Mappers
{
    public class TallerMapper
    {
        public static Taller MapToEntity(TallerDTO dto)
        {
            return new Taller 
            {
                Id = dto.TallerId,
                nombreLocal = dto.nombreLocal,
            };
        }
        

        public static TallerDTO MapToDTO (Taller entity)
        {
            return new TallerDTO
            {
                TallerId = entity.Id,
                nombreLocal = entity.nombreLocal,
            };
        }




    }
}