using levantamiento.BussinesLogic.DTOs;
using levantamiento.Conections.rabbit;
using levantamiento.Persistence.DAOs;
using levantamiento.Exceptions;
using levantamiento.Persistence.Entities;

namespace levantamiento.BussinesLogic.Logic
{
    public class ParteLogic: IParteLogic
    {

        private readonly IParteDAO _parteDAO;

        public ParteLogic( IParteDAO parteDAO)
        {
            _parteDAO = parteDAO;
        }
        
        public bool RegisterParte(ParteDTO parteDTO)
        {
            try
            {
                if(parteDTO.nombre == "string" || parteDTO.nombre == "")
                {
                    throw new RCVInvalidFieldException("El nombre de la parte no puede ser vacio");
                }
                _parteDAO.RegisterParte(
                    ParteDTOToEntity.ConvertParteDTOToEntity(parteDTO)
                );
                return true;
            }
            catch (RCVInvalidFieldException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new RCVException("no se logró registrar la piesa", ex);
            }
        }

    }
}