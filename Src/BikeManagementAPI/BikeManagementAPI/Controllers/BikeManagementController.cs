using BikeManagementAPI.Command;
using BikeManagementAPI.CommandHandlers;
using BikeManagementAPI.Commands;
using BikeManagementAPI.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BikeManagementAPI.Controllers
{
    /// <summary>
    ///     Controller that handles all bike actions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class BikeManagementController : Controller
    {
        private readonly IRegisterBikeJobCommandHandler registerBikeJobCommandHandler;

        /// <summary>
        ///
        /// </summary>
        /// <param name="registerBikeJobCommandHandler"></param>
        public BikeManagementController(IRegisterBikeJobCommandHandler registerBikeJobCommandHandler)
        {
            this.registerBikeJobCommandHandler = registerBikeJobCommandHandler;
        }

        /// <summary>
        ///     Register a new bike.
        /// </summary>
        /// <remarks>
        ///
        ///     Sample request:
        ///
        ///     POST /1234/bikes
        ///     {
        ///
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly registered bike.</returns>
        /// <response code="201">Returns a newly registered bike.</response>
        /// <response code="400">If the request is invalid.</response>
        [HttpPost]
        [Route("/{customerId}/bikes")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [Authorize("Bike:Create")]
        public async Task<ActionResult<Bike>> RegisterAsync(string customerId, [FromBody] RegisterBikeJob registerBikeJob)
        {
            Bike bike = await registerBikeJobCommandHandler.HandleCommandAsync(registerBikeJob);

            return CreatedAtRoute("GetByCustomerId", new { customerId = customerId, bikeId = bike.Id }, bike);
        }
    }
}