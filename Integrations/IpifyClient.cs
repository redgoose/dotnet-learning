using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace TodoApi.Integrations
{

    public class IPAddress
    {
        public string ip { get; set; }

    }

    public static class IpifyClient
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<IPAddress> GetIPAddress()
        {
            client.BaseAddress = new Uri("https://api.ipify.org");

            HttpResponseMessage response = await client.GetAsync("?format=json");
            return await response.Content.ReadAsAsync<IPAddress>();
        }
    }

}