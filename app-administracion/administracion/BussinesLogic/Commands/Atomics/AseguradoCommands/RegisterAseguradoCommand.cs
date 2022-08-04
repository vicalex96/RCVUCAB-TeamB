using administracion.BussinesLogic.DTOs;
using administracion.BussinesLogic.Mappers;
using administracion.DataAccess.DAOs;
using administracion.Exceptions;

namespace administracion.BussinesLogic.Commands
{
    public class RegisterAseguradoCommand: Command<Guid>
    {
        private Guid _result;
        private readonly AseguradoRegisterDTO _aseguradoDTO;

        public RegisterAseguradoCommand(AseguradoRegisterDTO aseguradoDTO)
        {
            _aseguradoDTO = aseguradoDTO;
        }
        
        /// <summary>
        /// verifica que si el nombre o apellido estan vacios
        /// </summary>
        /// <param name="name">campo nombre a revisar</param>
        /// <returns>booleano true si es invalido, false si es valido</returns>
        private bool IsNotValidName( string name)
        {
            if(name.ToLower() == "string" || name.Count() == 0)
            {
                return true;
            }
            return false;
        }

        public override void Execute()
        {
                        try
            {
                //El nombre y el apellido no pueden estar vacios
                if(IsNotValidName(_aseguradoDTO.nombre) )
                {
                    throw new RCVInvalidFieldException("El campo nombre no es valido, debe ser diferente de vacio y no por defecto");
                }
                if(IsNotValidName(_aseguradoDTO.apellido))
                {
                    throw new RCVInvalidFieldException("El campo apellido no es valido, debe ser diferente de vacio y no por defecto");
                }

                AseguradoDAO dao = DAOFactory.createAseguradoDAO();
                _result = dao.RegisterAsegurado(
                        AseguradoMapper.MapToEntity(_aseguradoDTO)
                    );
            }
            catch(RCVInvalidFieldException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw new RCVException("Error al registrar asegurado", ex);
            }
        }

        public override Guid GetResult()
        {
            return _result!;
        }
    }
}