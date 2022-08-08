using System.Text.Json;
using taller.BussinesLogic.DTOs;
using taller.Responses;
using taller.Exceptions;

namespace taller.DataAcces.APIs
{
    public class RequerimientoAPI : IRequerimientoAPI
    {
        private string url = "https://localhost:7281/";
        private JsonSerializerOptions options = new JsonSerializerOptions() 
        {
            PropertyNameCaseInsensitive = true
        };

        ///<summary>
        /// Metodo asincrono que solicita la informacion de un Incidente al API de administracion
        ///</summary>
        ///<param name="requerimientoId">Id del incidente que se desea obtener</param>
        ///<returns>Respuesta con el incidente solicitado</returns>
        public async Task<RequerimientoDTO > GetDetailsFromAdmin(Guid requqerimientoId)
        {
            var localUrl = url + "requerimiento/consultar/{0}";
            try
            {
                using(var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(
                        string.Format(localUrl, requqerimientoId.ToString())
                    );

                    if(response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var requerimiento = JsonSerializer.Deserialize<ApplicationResponse<RequerimientoDTO >>(content, options);

                        return requerimiento!.Data!;
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