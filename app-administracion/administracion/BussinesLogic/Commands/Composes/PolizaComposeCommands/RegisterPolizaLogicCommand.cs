using administracion.BussinesLogic.DTOs;
using administracion.BussinesLogic.Mappers;
using administracion.DataAccess.DAOs;
using administracion.DataAccess.Entities;
using administracion.Exceptions;

namespace administracion.BussinesLogic.Commands
{
    public class RegisterPolizaLogicCommand: Command<Guid>
    {
        private Guid _result;
        private readonly PolizaRegisterDTO _polizaDTO;

        public RegisterPolizaLogicCommand(PolizaRegisterDTO polizaDTO)
        {
            _polizaDTO = polizaDTO;
        }

        
        public override void Execute()
        {
            try
            {
                // el vehiculo tiene que estar asignado a un asegurado
                GetVehiculoByIdCommand getVehiculoCommand = VehiculoCommandFactory.createGetVehiculoByIdCommand(_polizaDTO.vehiculoId);
                getVehiculoCommand.Execute();

                if(getVehiculoCommand.GetResult().asegurado == null)
                {
                    throw new RCVAsociationException("El vehiculo no tiene un asegurado asignado", new Exception());
                }

                // vehiculo no puede tener polizas activas
                GetPolizaByVehiculoIdCommand getPolizaCommand = VehiculoCommandFactory.createGetPolizaByVehiculoIdCommand(_polizaDTO.vehiculoId);
                getPolizaCommand.Execute();
                
                if(getPolizaCommand.GetResult() != null)
                {
                    throw new RCVAsociationException("El vehiculo ya tiene una poliza registrada y activa", new Exception());
                }



                // El rango de fechas de la poliza debe ser correcto
                if(_polizaDTO.fechaVencimiento < _polizaDTO.fechaRegistro)
                {
                    throw new RCVDateOrderException("La fecha de vencimiento debe ser mayor a la fecha de registro", new Exception());
                }

                RegisterPolizaCommand registerPolizaCommand = PolizaCommandFactory.createRegisterPolizaCommand( _polizaDTO );
                registerPolizaCommand.Execute();
                _result = registerPolizaCommand.GetResult();
            }   
            catch(RCVNullException ex)
            {
                throw ex;
            }
            catch(RCVAsociationException ex)
            {
                throw ex;
            }
            catch(RCVDateOrderException ex)
            {
                throw ex;
            }
            catch(ArgumentException ex)
            {
                throw new RCVInvalidFieldException("El tipo de póliza no es valido", ex);
            }
            catch(Exception ex)
            {
                throw new RCVException("Ocurrio un problema al Guidentar registrar",ex);
            }

        }
        
        public override Guid GetResult()
        {
            return _result!;
        }
    }
}