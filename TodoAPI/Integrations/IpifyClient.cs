using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace TodoApi.Integrations
{

    public class IPAddress
    {
        public string ip { get; set; }

    }

    public class IpifyClient
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string _baseUrl;

        public IpifyClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<IPAddress> GetIPAddress()
        {
            HttpResponseMessage response = await client.GetAsync($"{_baseUrl}?format=json");
            return await response.Content.ReadAsAsync<IPAddress>();
        }
    }

}