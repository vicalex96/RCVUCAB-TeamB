using taller.DataAcces.Enums;

namespace taller.DataAcces.Entities
{
    public class MarcaFactory 
    {
        private static MarcaName ConvertToMarca (string marca)
        {
            return (MarcaName)Enum.Parse(typeof(MarcaName), marca);
        }

        public static MarcaTaller createMarcaTaller(Guid tallerId, string marcaName)
        {
            MarcaTaller marca = new MarcaTaller();
            marca.tallerId = tallerId;
            marca.manejaTodas = false;
            marca.marcaName = ConvertToMarca(marcaName);
            return marca;

        }
        public static MarcaTaller createMarcaTallerTodasLasMarcas(Guid tallerId)
        {
            MarcaTaller marca = new MarcaTaller();
            marca.tallerId = tallerId;
            marca.manejaTodas = true;
            return marca;
        }



    }
}