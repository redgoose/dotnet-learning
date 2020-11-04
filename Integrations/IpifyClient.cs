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
        public static async Task<IPAddress> GetIPAddress()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.ipify.org");

            HttpResponseMessage response = await client.GetAsync("?format=json");
            return await response.Content.ReadAsAsync<IPAddress>();
        }
    }

}