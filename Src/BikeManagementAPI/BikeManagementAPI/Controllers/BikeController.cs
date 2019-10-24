using BikeManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BikeManagementAPI.Controllers
{
    /// <summary>
    ///     Controller that handles all bike actions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class BikeController : Controller
    {
        /// <summary>
        ///     Register a new bike.
        /// </summary>
        /// <remarks>
        ///
        ///     Sample request:
        ///
        ///
        ///
        /// </remarks>
        /// <returns>A newly registered bike.</returns>
        /// <response code="201">Returns a newly registered bike.</response>
        /// <response code="400">If the request is invalid.</response>
        [HttpPut]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        public async Task<ActionResult<Bike>> RegisterNewBike()
        {
            return Created("", null);
        }
    }
}