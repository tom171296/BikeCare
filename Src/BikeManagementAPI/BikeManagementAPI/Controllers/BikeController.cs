using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BikeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : Controller
    {
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok("test");
        }

        [HttpGet]
        [Route("private")]
        [Authorize]
        public async Task<IActionResult> testPrivate()
        {
            return Ok("test-private");
        }

        [HttpGet]
        [Route("private-scoped")]
        [Authorize("read:bike")]
        public async Task<IActionResult> testPrivateScoped()
        {
            return Ok("test-scoped");
        }
    }
}