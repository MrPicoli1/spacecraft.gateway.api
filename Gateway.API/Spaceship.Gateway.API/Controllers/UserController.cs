using Microsoft.AspNetCore.Mvc;
using Spaceship.Gateway.Models.User;
using Spaceship.Gateway.Models.ValueObjects;
using Spaceship.Gateway.Services.Interfaces;

namespace Spaceship.Gateway.API.Controllers
{



    [ApiController]
    [Route("api/v1/gateway/user")]
    public class UserController : Controller
    {


        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Add a User
        /// </summary>
        /// <param name="model">Object to generate a JWT Key</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If the login is susecceful</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            return Ok();
        }


        /// <summary>
        /// Add a User
        /// </summary>
        /// <param name="model">Object for the creation of a User</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If the user is created</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PostUser([FromBody] UserModel model)
        {

            var user = await _userService.AddUser(model);

            if (user.Notifications.Any())
            {
                return BadRequest(user.Notifications);
            }

            return Ok();
        }

        /// <summary>
        /// Update a User
        /// </summary>
        /// <param name="model">Object for the Update of the Info of a User</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the update occurred</response>
        [HttpPut("info")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutInfoUser([FromBody] UserModel model)
        {

            var user = await _userService.UpdateInfoUser(model);

            if (user.Notifications.Any())
            {
                return BadRequest(user.Notifications);
            }

            return NoContent();
        }

        /// <summary>
        /// Update a User
        /// </summary>
        /// <param name="model">Object for the Update of the Login of a User</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the update occurred</response>
        [HttpPut("login")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutLoginUser([FromBody] UserModel model)
        {

            var user = await _userService.UpdateLoginUser(model);

            if (user.Notifications.Any())
            {
                return BadRequest(user.Notifications);
            }

            return NoContent();
        }


        /// <summary>
        /// Delete User
        /// </summary>
        /// <param ></param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the user is deleted</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {

            var  deleted = await _userService.DeleteUser(id);

            if(deleted)
            return NoContent();

            return BadRequest();
            
        }
    }
}
