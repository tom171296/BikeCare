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
        [Route("private-scoped")]
        [Authorize("read:bike")]
        public async Task<IActionResult> testPrivateScoped()
        {
            return Ok("test-scoped");
        }
    }
}