
using administracion.Persistence.Entities;
using administracion.BussinesLogic.DTOs;
using System.Collections.Generic;

namespace administracion.Persistence.DAOs
{
    public interface IAseguradoDAO
    {
        public AseguradoDTO GetAseguradoByGuid(Guid Id);
        public List<AseguradoDTO> GetAsegurados();
        public string createAsegurado(AseguradoDTO ase);
        public string updateAsegurado(AseguradoDTO ase);
        public List<AseguradoDTO> GetAseguradosPorNombreCompleto(string nombre, string apellido);
    }
}