
using administracion.BussinesLogic.DTOs;
using administracion.DataAccess.DAOs.MQ;
using administracion.DataAccess.Enums;

namespace administracion.BussinesLogic.Commands
{
    public class SendProveedorMQCommand : Command<int>
    {
        private readonly ProveedorDTO _proveedorDTO;
        public SendProveedorMQCommand(ProveedorDTO proveedorDTO)
        {
            _proveedorDTO = proveedorDTO;
        }

        public override void Execute()
        {
            ProviderMQ dao = MQFactory.CreateProviderMQ();
            dao.Producer(_proveedorDTO, ExchangeName.Proveedor);
        }

        public override int GetResult()
        {
            throw new NotImplementedException();
        }
    }
}