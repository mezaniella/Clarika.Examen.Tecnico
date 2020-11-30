using System.Net.Http;
using System.Threading.Tasks;

namespace Clarika.Examen.Tecnico.Helpers
{
    public interface IHttpClientHelper
    {
        Task<T> GetObjects<T>(string endpoint);
        Task<T> GetObjects<T>(string endpoint, string token);
        Task<T> PostObjects<T>(string endpoint, StringContent content, string token);
    }
}