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

        LearningService ls = new LearningService();

        [HttpGet("foo")]
        public async Task<ActionResult<string>> GetFoo()
        {
            return "foo";
        }


        [HttpGet("bar")]
        public async Task<ActionResult<Bar>> GetBar()
        {
            return ls.GetBar();
        }

        [HttpGet("baz")]
        public async Task<ActionResult<IPAddress>> GetBaz()
        {
            return await IpifyClient.GetIPAddress();
        }

    }
}
