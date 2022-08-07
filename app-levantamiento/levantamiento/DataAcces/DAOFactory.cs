using levantamiento.DataAccess.APIs;
using levantamiento.DataAccess.DAOs;

namespace levantamiento.DataAccess.DAOs
{
    public class DAOFactory
    {
        public static IncidenteDAO createIncidenteDAO()
        {
            return new IncidenteDAO();
        }
        
        public static IncidenteAPI createIncidenteAPI()
        {
            return new IncidenteAPI();
        }

        public static ParteDAO createParteDAO()
        {
            return new ParteDAO();
        }

        public static RequerimientoDAO createRequerimientoDAO()
        {
            return new RequerimientoDAO();
        }

        public static SolicitudReparacionDAO createSolicitudReparacionDAO()
        {
            return new SolicitudReparacionDAO();
        }

        public static VehiculoAPI createVehiculoAPI()
        {
            return new VehiculoAPI();
        }

        public static TallerAPI createTallerAPI()
        {
            return new TallerAPI();
        }

    }
}