using Newtonsoft.Json;
using PriceTrackerMobile.Helpers;
using PriceTrackerMobile.Interfaces;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PriceTrackerMobile.Services
{
    public class HttpService : IHttpService
    {
        public HttpClient client;

        public void Init(string baseUrl)
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        async Task<T> IHttpService.PostRequestAsync<T>(IRequest request, string path)
        {
            T response = new T();
            string json = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                string stringResponse = await client.PostAsync(path, content).Result.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<T>(stringResponse);
            }
            catch (Exception)
            {
                response = new T() { status = false, message = "Connection error" };
            }

            return response;
        }

        async Task<T> IHttpService.GetRequestAsync<T>(string path)
        {
            HttpResponseMessage httpRequest = new HttpResponseMessage();
            T resposne = new T();

            try
            {
                httpRequest = await client.GetAsync(path).ConfigureAwait(false);
                string rresponseString = await httpRequest.Content.ReadAsStringAsync();
                resposne = JsonConvert.DeserializeObject<T>(rresponseString);
            }
            catch (Exception)
            {
                resposne = new T() { status = false, message = "Connection error" };
            }

            return resposne;
        }

        async Task<T> IHttpService.DeleteRequestAsync<T>(string path)
        {
            HttpResponseMessage httpRequest = new HttpResponseMessage();
            T resposne = new T();

            try
            {
                httpRequest = await client.DeleteAsync(path);
                string rresponseString = await httpRequest.Content.ReadAsStringAsync();
                resposne = JsonConvert.DeserializeObject<T>(rresponseString);
            }
            catch (Exception)
            {
                resposne = new T() { status = false, message = "Connection error" };
            }

            return resposne;
        }

        void IHttpService.ApplayToken()
        {
            client.DefaultRequestHeaders.Add("authentication", Settings.Token);
        }
    }
}
