using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Integrations;
using TodoApi.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LearningController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("foo")]
        public string GetFoo()
        {
            return "foo";
        }


        [HttpGet("bar")]
        public Bar GetBar()
        {
            LearningService ls = new LearningService();
            return ls.GetBar();
        }

        [HttpGet("baz")]
        public async Task<ActionResult<IPAddress>> GetBaz()
        {
            var ipifyClient = new IpifyClient(_httpClientFactory.CreateClient());
            return await ipifyClient.GetIPAddress();
        }

    }
}
