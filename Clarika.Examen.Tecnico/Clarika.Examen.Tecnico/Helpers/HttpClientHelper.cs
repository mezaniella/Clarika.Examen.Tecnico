using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Clarika.Examen.Tecnico.Helpers
{
    public class HttpClientHelper : IHttpClientHelper
    {
        IHttpClientFactory _httpClientFactory;

        public HttpClientHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetObjects<T>(string endpoint, string token)
        {
           
            var httpClient = _httpClientFactory.CreateClient("Clarika");

            httpClient.MaxResponseContentBufferSize = int.MaxValue;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                var response = await httpClient.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var returnobj = JsonConvert.DeserializeObject<T>(content);

                    return returnobj;
                }

                return default(T);
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        public async Task<T> PostObjects<T>(string endpoint, StringContent content, string token)
        {

            var httpClient = _httpClientFactory.CreateClient("Clarika");
            httpClient.MaxResponseContentBufferSize = int.MaxValue;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                var response = await httpClient.PostAsync(endpoint, content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnobj = JsonConvert.DeserializeObject<T>(result);

                    return returnobj;
                }

                return default(T);
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        public async Task<T> GetObjects<T>(string endpoint)
        {
            var httpClient = _httpClientFactory.CreateClient("Clarika");


            httpClient.MaxResponseContentBufferSize = int.MaxValue;
            try
            {
                var response = await httpClient.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var returnobj = JsonConvert.DeserializeObject<T>(content);

                    return returnobj;
                }

                return default(T);
            }
            catch (HttpRequestException e)
            {
                return default(T);
            }
        }
    }
}
