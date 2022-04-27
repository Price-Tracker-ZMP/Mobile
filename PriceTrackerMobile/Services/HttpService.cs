using Newtonsoft.Json;
using PriceTrackerMobile.Helpers;
using PriceTrackerMobile.Interfaces;
using PriceTrackerMobile.Response;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PriceTrackerMobile.Services
{
    public class HttpService<T> : IHttpService<T> where T : ApiResponse, new()
    {
        public HttpClient client;

        public void Init(string baseUrl)
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        async Task<T2> IHttpService<T>.PostRequestAsync<T2>(IRequest request, string path)
        {
            T2 response = new T2();
            string json = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                string stringResponse = await client.PostAsync(path, content).Result.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<T2>(stringResponse);
            }
            catch (Exception)
            {
                response = new T2() { status = false, message = "Connection error" };
            }

            return response;
        }

        async Task<T2> IHttpService<T>.GetRequestAsync<T2>(string path)
        {
            HttpResponseMessage httpRequest = new HttpResponseMessage();
            T2 resposne = new T2();

            try
            {
                httpRequest = await client.GetAsync(path).ConfigureAwait(false);
                string rresponseString = await httpRequest.Content.ReadAsStringAsync();
                resposne = JsonConvert.DeserializeObject<T2>(rresponseString);
            }
            catch (Exception)
            {
                resposne = new T2() { status = false, message = "Connection error" };
            }

            return resposne;
        }

        async Task<T2> IHttpService<T>.DeleteRequestAsync<T2>(string path)
        {
            HttpResponseMessage httpRequest = new HttpResponseMessage();
            T2 resposne = new T2();

            try
            {
                httpRequest = await client.DeleteAsync(path);
                string rresponseString = await httpRequest.Content.ReadAsStringAsync();
                resposne = JsonConvert.DeserializeObject<T2>(rresponseString);
            }
            catch (Exception)
            {
                resposne = new T2() { status = false, message = "Connection error" };
            }

            return resposne;
        }

        void IHttpService<T>.ApplayToken()
        {
            client.DefaultRequestHeaders.Add("authentication", Settings.Token);
        }
    }
}
