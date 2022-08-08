using System.Text.Json;
using taller.BussinesLogic.DTOs;
using taller.Responses;
using taller.Exceptions;

namespace taller.DataAcces.APIs
{
    public class ParteAPI : IParteAPI
    {
        private string url = "https://localhost:7281/";
        private JsonSerializerOptions options = new JsonSerializerOptions() 
        {
            PropertyNameCaseInsensitive = true
        };

        ///<summary>
        /// Metodo asincrono que solicita la informacion de un Incidente al API de administracion
        ///</summary>
        ///<param name="parteId">Id del incidente que se desea obtener</param>
        ///<returns>Respuesta con el incidente solicitado</returns>
        public async Task<ParteDTO > GetDetailsFromAdmin(Guid parteId)
        {
            var localUrl = url + "parte/consultar/{0}";
            try
            {
                using(var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(
                        string.Format(localUrl, parteId.ToString())
                    );

                    if(response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var parte = JsonSerializer.Deserialize<ApplicationResponse<ParteDTO >>(content, options);

                        return parte!.Data!;
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