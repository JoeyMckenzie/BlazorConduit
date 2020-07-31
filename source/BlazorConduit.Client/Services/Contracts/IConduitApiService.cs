using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Services.Contracts
{
    public interface IConduitApiService
    {
        Task<TResponse> GetAsync<TResponse>(string path, string? token = null)
            where TResponse : class;


        Task<HttpResponseMessage> PostAsync<TBody>(string path, TBody body, string? token = null)
            where TBody : class;


        Task<HttpResponseMessage> PostNoContentAsync(string path, string? token);


        Task<HttpResponseMessage> DeleteNoContentAsync(string path, string? token);


        Task<HttpResponseMessage> PutAsync<TBody>(string path, TBody body, string? token = null)
            where TBody : class;
    }
}
