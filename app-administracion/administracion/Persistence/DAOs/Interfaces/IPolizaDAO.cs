
using administracion.Persistence.Entities;
using administracion.BussinesLogic.DTOs;
using System.Collections.Generic;

namespace administracion.Persistence.DAOs
{
    public interface IPolizaDAO
    {
        public string registrarPoliza (PolizaSimpleDTO poliza);
        public PolizaDTO consultarPolizaDeVehiculo(Guid vehiculoID);
    }
}