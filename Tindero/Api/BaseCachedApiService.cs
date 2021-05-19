using MonkeyCache.FileStore;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tindero.Api
{
    public abstract class BaseCachedApiService
    {
        public const string BaseApiUrl = "https://reqres.in/api/";
        private readonly Lazy<HttpClient> _httpClientLazy;

        protected HttpClient HttpClient => _httpClientLazy.Value;
        
        public BaseCachedApiService()
        {
            _httpClientLazy = new Lazy<HttpClient>(() => 
                new HttpClient
                {
                    BaseAddress = new Uri(BaseApiUrl)
                });
        }

        public async Task<T> GetAsync<T>(string url, int days = 7, bool forceRefresh = false)
        {
            var json = string.Empty;

            if (!CrossConnectivity.Current.IsConnected)
                json = Barrel.Current.Get<string>(url);

            if (!forceRefresh && !Barrel.Current.IsExpired(url))
                json = Barrel.Current.Get<string>(url);

            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    json = await HttpClient.GetStringAsync(url);
                    Barrel.Current.Add(url, json, TimeSpan.FromDays(days));
                }
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to get information from server {ex}");
            }

            return default;
        }
    }
}
