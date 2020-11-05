using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Integrations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningController : ControllerBase
    {
        [HttpGet("foo")]
        public async Task<ActionResult<string>> GetFoo()
        {
            return "foo";
        }

        public class Bar
        {
            public string foo { get; set; }
        }

        [HttpGet("bar")]
        public async Task<ActionResult<Bar>> GetBar()
        {
            return new Bar { foo = "bar" };
        }

        [HttpGet("baz")]
        public async Task<ActionResult<IPAddress>> GetBaz()
        {
            return await IpifyClient.GetIPAddress();
        }

    }
}
