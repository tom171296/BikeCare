using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BikeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetBikes()
        {
            return Ok("test");
        }
    }
}