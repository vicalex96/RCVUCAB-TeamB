using taller.DataAcces.Entities;
using taller.BussinesLogic.DTOs;
using System.Collections.Generic;

namespace taller.DataAcces.DAOs
{
    public interface IRequerimientoDAO
    {
        
        public List<RequerimientoDTO> GetRequerimientos(Guid solicitudId);
        public bool UpdateTipoRequerimiento(Guid requerimientoId,TipoRequerimiento tipo);
        public bool UpdateQuantityPiecesRequerimiento(Guid requerimientoId,int quantity);
        public bool RegisterRequerimiento(RequerimientoDTO requerimiento);
    }


}