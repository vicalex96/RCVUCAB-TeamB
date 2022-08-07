using taller.DataAcces.DAOs;


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

    }
}