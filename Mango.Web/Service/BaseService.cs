using Mango.Web.Models;
using Mango.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Mango.Web.Utilities.SD;

namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
                _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDTO requestDTO)
        {
            HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
            HttpRequestMessage httpRequestMessage = new();

            httpRequestMessage.Headers.Add("Accept", "application/json");

            httpRequestMessage.RequestUri = new Uri(requestDTO.Url);
            if (requestDTO.Data != null)
            {
                httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(requestDTO.Data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage? apiResponse = null;

            httpRequestMessage.Method = requestDTO.ApiType switch
            {
                ApiType.POST => httpRequestMessage.Method = HttpMethod.Post,
                ApiType.PUT => httpRequestMessage.Method = HttpMethod.Put,
                ApiType.DELETE => httpRequestMessage.Method= HttpMethod.Delete,
                _ => httpRequestMessage.Method = HttpMethod.Get
            };

            apiResponse = await client.SendAsync(httpRequestMessage);

            try
            {
                switch(apiResponse.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    return new ResponseDto { IsSuccess = false, Message = "Unauthorized", Result = null };
                case HttpStatusCode.Forbidden:
                    return new ResponseDto { IsSuccess = false, Message = "Forbidden", Result=null };
                case HttpStatusCode.NotFound:
                    return new ResponseDto { IsSuccess = false, Message = "Not Found", Result = null };
                case HttpStatusCode.InternalServerError:
                    return new ResponseDto { IsSuccess = false, Message = "Internal Server Error", Result = null };
                default:
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                    return apiResponseDto;
            }

            } catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    Message = ex.Message,
                    IsSuccess = false,
                };

                return dto;
            }

        }
    }
}
