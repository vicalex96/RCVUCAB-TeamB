
using  administracion.DataAccess.Entities;
using administracion.BussinesLogic.DTOs;
using  administracion.DataAccess.Enums;


namespace  administracion.DataAccess.DAOs
{
    /// <summary>
    /// Interface para el listado de metodos de DAO de Proveedor
    /// </summary>
    public interface IProveedorDAO
    {
        public List<ProveedorDTO> GetProveedores();
        public ProveedorDTO GetProveedorByGuid (Guid proveedorId);
        public Guid RegisterProveedor (Proveedor proveedor);
        public Guid AddMarca(MarcaProveedor Marca);
        public int DeleteMarcasFromProveedor(Guid proveedorId);
        public List<ProveedorDTO> GetProveedoresByMarca(MarcaName marca);
        public bool IsMarcaExistsOnProveedor(Guid proveedorId, MarcaName marca);
    }
}