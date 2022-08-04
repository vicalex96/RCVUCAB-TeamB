using administracion.BussinesLogic.DTOs;
using administracion.BussinesLogic.Commands;
using administracion.DataAccess.Entities;
using administracion.DataAccess.Enums;

namespace administracion.BussinesLogic.Commands
{
    public class MQCommandFactory
    {
        public static SendIncincenteMQCommand createSendIncincenteMQCommand(IncidenteDTO  incidente)
        {
            return new SendIncincenteMQCommand(incidente);
        }

        public static SendTallerMQCommand createSendTallerMQCommand(TallerDTO  taller)
        {
            return new SendTallerMQCommand(taller);
        }
        
        public static SendProveedorMQCommand createSendProveedorMQCommand(ProveedorDTO  proveedor)
        {
            return new SendProveedorMQCommand(proveedor);
        }
        
    }
}