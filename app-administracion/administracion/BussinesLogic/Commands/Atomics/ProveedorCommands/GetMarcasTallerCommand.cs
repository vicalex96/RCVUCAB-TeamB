using administracion.BussinesLogic.DTOs;
using administracion.DataAccess.DAOs;
using administracion.DataAccess.Enums;
using administracion.Exceptions;

namespace administracion.BussinesLogic.Commands
{
    public class GetProveedoresByMarcaCommand: Command<List<ProveedorDTO>>
    {
        private List<ProveedorDTO>? _result;
        private readonly string _marca;

        public GetProveedoresByMarcaCommand(string marca)
        {
            _marca = marca;
        }
        public override void Execute()
        {
            try
            {
                //revisa que la marca existe
                MarcaName marcaName = (MarcaName)Enum.Parse(typeof(MarcaName), _marca);

                //buscar las marcasTaller de la marca indicada
                ProveedorDAO dao = DAOFactory.createProveedorDAO();
                _result = dao.GetProveedoresByMarca(marcaName);

            }
            catch(ArgumentException  ex)
            {
                throw new RCVInvalidFieldException("La marca introducida no existe o no no esta registrada en el sistema",ex);
            }
            catch(Exception ex)
            {
                throw new RCVException("Error al registrar el proveedor", ex);
            }
        }

        public override List<ProveedorDTO> GetResult()
        {
            return _result!;
        }
    }
}