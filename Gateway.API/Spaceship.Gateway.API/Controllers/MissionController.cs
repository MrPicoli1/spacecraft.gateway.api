using Microsoft.AspNetCore.Mvc;


namespace Spaceship.Gateway.API.Controllers
{

    [ApiController]
    [Route("api/v1/gateway/mission")]
    public class MissionController : Controller
    {
        /// <summary>
        /// Get a List of Missions
        /// </summary>
        /// <param></param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If the update occurred</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMission()
        {

            return Ok();
        }

        /// <summary>
        /// Finish a Mission of a Spaceship
        /// </summary>
        /// <param name="id">Object for the Update of a User</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the update occurred</response>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> EndMission([FromBody] Guid id)
        {
            return NoContent();
        }

    }
}
