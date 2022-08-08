using taller.DataAcces.Entities;
using taller.BussinesLogic.DTOs;
using System.Collections.Generic;

namespace taller.DataAcces.DAOs
{

    public interface IParteDAO
    {
        public Guid RegisterParte(Parte parte);
        public ParteDTO GetParteByGuid(Guid parteId);
        public ICollection<ParteToShowDTO> GetAll();

        //public TallerDTO GetTallerByGuid (Guid tallerId);
       // public List<TallerDTO> GetTalleres();

        //public Guid RegisterTaller (TallerDTO taller);
       // public Guid AddMarca(MarcaTaller Marca);
        //public int DeleteMarcasFromTaller(Guid tallerId);
        
       // public bool IsMarcaExistsOnTaller(Guid tallerId, MarcaName marca);
    }
}