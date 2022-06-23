
using administracion.Persistence.Entities;
using administracion.BussinesLogic.DTOs;
using System.Collections.Generic;

namespace administracion.Persistence.DAOs
{
    public interface IVehiculoDAO
    {
        public List<VehiculoDTO> GetAllVehiculos();
        public VehiculoDTO GetVehiculoByGuid(Guid Id);
        public List<VehiculoDTO> GetVehiculosByAsegurado(Guid aseguradoId);
        public string createVehiculo(VehiculoSimpleDTO auto);
        public string addAsegurado(Guid aseguradoId, Guid vehiculoId);
        public string updateVehiculo(VehiculoSimpleDTO auto);
        
    }
}