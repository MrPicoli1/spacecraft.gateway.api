using Microsoft.AspNetCore.Mvc;
using Spaceship.Gateway.Models.Mission;
using Spaceship.Gateway.Models.Spaceship;
using Spaceship.Gateway.Models.User;

namespace Spaceship.Gateway.API.Controllers
{
    [ApiController]
    [Route("api/v1/gateway/spaceship")]
    public class SpaceshipController : Controller
    {
        /// <summary>
        /// Add a new Spaceship
        /// </summary>
        /// <param name="model">Object for the creation of a Spaceship</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">If the Spaceship is created</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateSpaceship([FromBody] SpaceshipModel model)
        {

            return Created();
        }

        /// <summary>
        /// Return a list of Spaceships
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If it successifully gets an list of spaceships</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetNewSpaceships()
        {

            return Ok();
        }

        /// <summary>
        /// Adds 1 to the spaceship rank
        /// </summary>
        /// <param name="id">Id of the desired spaceship</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the rank up occurred</response>
        [HttpPut("rank-up")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RankUp([FromBody] Guid id)
        {

            return NoContent();
        }

        /// <summary>
        /// Repais the Spaceship
        /// </summary>
        /// <param name="id">Id of the desired spaceship</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the repair occurred</response>
        [HttpPut("repair")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Repair([FromBody] Guid id)
        {

            return NoContent();
        }


        /// <summary>
        /// Send on a Mission
        /// </summary>
        /// <param name="id">Id of the desired spaceship</param>
        /// // <param name="model">Object representing a Mission</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the the spaceShip is sent on a mission</response>
        [HttpPut("send-on-mission/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> SendOnMission([FromRoute] Guid id, MissionModel model)
        {

            return NoContent();
        }


        /// <summary>
        /// Delete a Sepaceship
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the Spaceship is deleted</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteSpaceship([FromBody] Guid Id)
        {

            return NoContent();
        }
    }
}
