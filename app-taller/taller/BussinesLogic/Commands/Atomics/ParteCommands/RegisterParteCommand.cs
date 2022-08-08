using taller.BussinesLogic.DTOs;
using taller.BussinesLogic.Mappers;
using taller.DataAcces.DAOs;
using taller.Exceptions;

namespace taller.BussinesLogic.Commands
{
    public class RegisterParteCommand: Command<Guid>
    {
        private Guid _result;
        private readonly ParteRegisterDTO _parteDTO;

        /// <summary>
        /// Ejecuta la logica para registrar una parte en el sistema
        /// </summary>
        /// <param name="parte">Parte a registrar</param>
        /// <returns>Tretorna el identificador de la parte</returns>
        public RegisterParteCommand(ParteRegisterDTO parteDTO)
        {
            _parteDTO = parteDTO;
        }

        /// <summary>
        /// Verifica si un nombre no es valido
        /// </summary>
        /// <param name="nombre">Nombre a verificar</param>
        /// <returns>True si no es valido, false si lo es</returns>
        private bool IsNotValidName(string nombre)
        {
            if(nombre == "string" || nombre == "")
            {
                return true;
            }
            return false;
        }

        public override void Execute()
        {
            ParteDAO dao = DAOFactory.createParteDAO();
            try
            {
                if(IsNotValidName(_parteDTO.nombre))
                {
                    throw new RCVInvalidFieldException("El nombre de la parte no puede ser vacio");
                }
                _result = dao.RegisterParte(
                        ParteMapper.MapToEntity(_parteDTO)
                    );
            }
            catch (RCVInvalidFieldException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new RCVException("no se logró registrar la pieza", ex);
            }
        }

        public override Guid GetResult()
        {
            return _result!;
        }
    }
}
