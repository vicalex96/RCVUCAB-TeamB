
using  administracion.DataAccess.Entities;
using administracion.BussinesLogic.DTOs;
using  administracion.DataAccess.Enums;

namespace  administracion.DataAccess.DAOs
{
    /// <summary>
    /// Interface para el listado de metodos de DAO de Taller
    /// </summary>
    public interface ITallerDAO
    {
        
        public TallerDTO GetTallerByGuid (Guid tallerId);
        public List<TallerDTO> GetTalleres();

        public Guid RegisterTaller (Taller taller);
        public Guid AddMarca(MarcaTaller Marca);
        public int DeleteMarcasFromTaller(Guid tallerId);
        
        public bool IsMarcaExistsOnTaller(Guid tallerId, MarcaName marca);
    }
}