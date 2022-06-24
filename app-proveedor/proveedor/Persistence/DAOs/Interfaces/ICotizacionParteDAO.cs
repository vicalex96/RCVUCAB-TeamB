using proveedor.Persistence.Entities;
using proveedor.BussinesLogic.DTOs;
using System.Collections.Generic;

namespace administracion.Persistence.DAOs
{
    public interface ICotizacionParteDAO
    {
        public string actualizarCotizacionParte(Guid CotizacionParteID, EstadoCotPt estado);
       // public List<AseguradoDTO> GetAsegurados();
        public string createCotizacionParte(CotizacionParteDTO ase);
        //public string updateAsegurado(AseguradoDTO ase);
       // public List<AseguradoDTO> GetAseguradosPorNombreCompleto(string nombre, string apellido);
    }
}