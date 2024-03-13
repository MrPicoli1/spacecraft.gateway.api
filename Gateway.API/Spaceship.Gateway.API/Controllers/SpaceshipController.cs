using Microsoft.AspNetCore.Mvc;
using Spaceship.Gateway.Models.Mission;
using Spaceship.Gateway.Models.Spaceship;
using Spaceship.Gateway.Services.Interfaces;


namespace Spaceship.Gateway.API.Controllers
{

    

    [ApiController]
    [Route("api/v1/gateway/spaceship")]
    public class SpaceshipController : Controller
    {

        private readonly ISpaceshipService _spaceshipService;

        public SpaceshipController(ISpaceshipService spaceshipService)
        {
            _spaceshipService = spaceshipService;
        }

        /// <summary>
        /// Add a new Spaceship
        /// </summary>
        /// <param name="model">Object for the creation of a Spaceship</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If the Spaceship is created</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateSpaceship([FromBody] SpaceshipModel model)
        {
            var spaceship = await _spaceshipService.PostSpaceAsync(model);

            if(spaceship.Notifications.Any())
            {
                return BadRequest(spaceship.Notifications);
            }

            return Ok(spaceship);
        }

        /// <summary>
        /// Return a list of Spaceships
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If it successifully gets an list of spaceships</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetNewSpaceships()
        {

            var spaceshipList = await _spaceshipService.GetNewSpaceshipsAsync();
            if(spaceshipList.Count == 0)
            {
                return BadRequest();
            }

            return Ok(spaceshipList);
        }

        /// <summary>
        /// Adds 1 to the spaceship rank
        /// </summary>
        /// <param name="id">Id of the desired spaceship</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the rank up occurred</response>
        [HttpPut("rank-up/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RankUp([FromRoute] Guid id)
        {
            var spaceship = await _spaceshipService.RankUp(id);

            if(spaceship.Notifications.Any())
                return BadRequest(spaceship.Notifications);

            return Ok(spaceship);
        }

        /// <summary>
        /// Repais the Spaceship
        /// </summary>
        /// <param name="id">Id of the desired spaceship</param>
        /// <param name="currency">money required to repair the spaceship</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the repair occurred</response>
        [HttpPut("repair/{id}/{currency}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Repair([FromRoute] Guid id,[FromRoute] int currency)
        {
            var spaceship = await _spaceshipService.Repair(id, currency);
            if(spaceship.Notifications.Any())
                return BadRequest(spaceship.Notifications);
            return Ok(spaceship);
        }


        /// <summary>
        /// Send on a Mission
        /// </summary>
        /// <param name="id">Id of the desired spaceship</param>
        /// <param name="model">Object representing a Mission</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the the spaceShip is sent on a mission</response>
        [HttpPut("send-on-mission/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> SendOnMission([FromRoute] Guid id, [FromBody] MissionModel model)
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
            if(await _spaceshipService.DeleteSpaceshipAsync(Id))
            return NoContent();

            return BadRequest();
        }
    }
}
