using System.Text.Json;
using taller.BussinesLogic.DTOs;
using taller.Responses;
using taller.Exceptions;

namespace taller.DataAcces.APIs
{
    public class SolicitudReparacionAPI : ISolicitudReparacionAPI
    {
        private string url = "https://localhost:7281/";
        private JsonSerializerOptions options = new JsonSerializerOptions() 
        {
            PropertyNameCaseInsensitive = true
        };

        ///<summary>
        /// Metodo asincrono que solicita la informacion de un Incidente al API de administracion
        ///</summary>
        ///<param name="solicitudId">Id del incidente que se desea obtener</param>
        ///<returns>Respuesta con el incidente solicitado</returns>
        public async Task<SolicitudesReparacionDTO > GetDetailsFromAdmin(Guid solicitudId)
        {
            var localUrl = url + "solicitud/consultar/{0}";
            try
            {
                using(var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(
                        string.Format(localUrl, solicitudId.ToString())
                    );

                    if(response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var solicitud = JsonSerializer.Deserialize<ApplicationResponse<SolicitudesReparacionDTO >>(content, options);

                        return solicitud!.Data!;
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