using taller.DataAcces.DAOs;
using taller.DataAcces.APIs;


namespace taller.DataAcces.DAOs
{
    public class DAOFactory
    {
        
        public static CotizacionRepDAO createCotizacionRepDAO()
        {
            return new CotizacionRepDAO();
        }
        

        public static TallerDAO createTallerDAO()
        {
            return new TallerDAO();
        }
        public static TallerAPI createTallerAPI()
        {
            return new TallerAPI();
        }

        public static SolcitudReparacionDAO createSolcitudReparacionDAO()
        {
            return new SolcitudReparacionDAO();
        }
        public static SolicitudReparacionAPI createSolcitudReparacionAPI()
        {
            return new SolicitudReparacionAPI();
        }

        public static RequerimientoDAO createRequerimientoDAO()
        {
            return new RequerimientoDAO();
        }
        public static RequerimientoAPI createRequerimientoAPI()
        {
            return new RequerimientoAPI();
        }

        public static ParteDAO createParteDAO()
        {
            return new ParteDAO();
        }
        public static ParteAPI createParteAPI()
        {
            return new ParteAPI();
        }
    }
}