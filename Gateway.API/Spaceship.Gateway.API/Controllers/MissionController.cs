using Microsoft.AspNetCore.Mvc;
using Spaceship.Gateway.Services.Interfaces;


namespace Spaceship.Gateway.API.Controllers
{

    [ApiController]
    [Route("api/v1/gateway/mission")]
    public class MissionController : Controller
    {
        private readonly IMissionService _missionService;
        public MissionController(IMissionService missionService)
        {
            _missionService = missionService;
        }

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

            return Ok(_missionService.CreateMissionsAsync());
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
