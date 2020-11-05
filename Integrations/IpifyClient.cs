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
            HttpResponseMessage response = await client.GetAsync("https://api.ipify.org?format=json");
            return await response.Content.ReadAsAsync<IPAddress>();
        }
    }

}