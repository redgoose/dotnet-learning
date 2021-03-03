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
        private HttpClient _client;

        public IpifyClient(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<IPAddress> GetIPAddress()
        {
            HttpResponseMessage response = await _client.GetAsync("https://api.ipify.org?format=json");
            return await response.Content.ReadAsAsync<IPAddress>();
        }
    }

}