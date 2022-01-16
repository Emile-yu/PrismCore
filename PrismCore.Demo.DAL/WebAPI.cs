using PrismCore.Demo.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Demo.DAL
{
    public class WebAPI : IWebAPI
    {
        private string domain = "https://localhost:5001/api/";

        private HttpClient _apiClient;

      
        public HttpClient ApiClient
        {
            get
            {
                return _apiClient;
            }
        }

        public WebAPI()
        {
            _apiClient = new HttpClient();
        }

        private MultipartFormDataContent GetFormData(Dictionary<string, HttpContent> contents)
        {
            var postContent = new MultipartFormDataContent();
            string boundary = $"----------{DateTime.Now.Ticks.ToString("x")}";
            postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");
            foreach (var item in contents)
            {
                postContent.Add(item.Value, item.Key);
            }
            return postContent;
        }
        public Task<string> PostDatas(string uri, Dictionary<string, HttpContent> contents)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage reponse = client.PostAsync($"{domain}{uri}", GetFormData(contents)).GetAwaiter().GetResult())
                {
                    if (reponse.IsSuccessStatusCode)
                    {
                        return reponse.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        throw new Exception(reponse.ReasonPhrase);
                    }
                }
            }
        }

        public Task<string> GetDatas(string uri)
        {
           
            using (HttpResponseMessage reponse = _apiClient.GetAsync($"{domain}{uri}").GetAwaiter().GetResult())
            {
                if (reponse.IsSuccessStatusCode)
                {
                    return reponse.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception(reponse.ReasonPhrase);
                }
            }
        }

        public async Task<TEntityOut> SignIn<TEntityIn, TEntityOut>(string uri, TEntityIn obj)
        where TEntityIn : class
        where TEntityOut : class
        {
           
            using (HttpResponseMessage reponse = _apiClient.PostAsJsonAsync($"{domain}{uri}", obj).GetAwaiter().GetResult())
            {
                if (reponse.IsSuccessStatusCode)
                {
                    var result = await reponse.Content.ReadAsStringAsync();

                    return Newtonsoft.Json.JsonConvert.DeserializeObject<TEntityOut>(result);
                }
                else
                {
                    throw new Exception(reponse.ReasonPhrase);
                }
            }
        }
    }
}
