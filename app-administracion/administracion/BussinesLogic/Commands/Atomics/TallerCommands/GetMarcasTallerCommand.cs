using administracion.BussinesLogic.DTOs;
using administracion.DataAccess.DAOs;
using administracion.DataAccess.Enums;
using administracion.Exceptions;

namespace administracion.BussinesLogic.Commands
{
    public class GetTalleresByMarcaCommand: Command<List<TallerDTO>>
    {
        private List<TallerDTO>? _result;
        private readonly string _marca;

        public GetTalleresByMarcaCommand(string marca)
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
                TallerDAO dao = DAOFactory.createTallerDAO();
                _result = dao.GetTalleresByMarca(marcaName);

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

        public override List<TallerDTO> GetResult()
        {
            return _result!;
        }
    }
}