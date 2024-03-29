using System.Text.Json;
using levantamiento.BussinesLogic.DTOs;
using levantamiento.Responses;
using levantamiento.Exceptions;

namespace levantamiento.DataAccess.APIs
{
    public class TallerAPI : ITallerAPI
    {
        private string url = "https://localhost:7075/";
        private JsonSerializerOptions options = new JsonSerializerOptions() 
        {
            PropertyNameCaseInsensitive = true
        };

        ///<summary>
        /// Metodo asincrono que solicita la informacion de un Incidente al API de administracion
        ///</summary>
        ///<param name="incidenteId">Id del incidente que se desea obtener</param>
        ///<returns>Respuesta con el incidente solicitado</returns>
        public async Task<TallerDTO> GetBestTaller(string marca)
        {
            var localUrl = url + "taller/buscar_mejor/{0}";
            try
            {
                using(var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(
                        string.Format(localUrl, marca)
                    );

                    if(response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var incidente = JsonSerializer.Deserialize<ApplicationResponse<TallerDTO>>(content, options);

                        return incidente!.Data!;
                    }    
                    else
                        throw new HttpRequestException("ocurrio algun problema al conectarse con el API");
                }
            } 
            catch(HttpRequestException ex)
            {
                throw new RCVException(ex.Message, ex);
            }
            catch(Exception ex)
            {
                throw new RCVException("Ocurrio un error desconcido", ex);
            }
        }
    }

}