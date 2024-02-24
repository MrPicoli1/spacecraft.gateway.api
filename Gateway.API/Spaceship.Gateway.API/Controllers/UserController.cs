using Microsoft.AspNetCore.Mvc;
using Spaceship.Gateway.Models.User;

namespace Spaceship.Gateway.API.Controllers
{
    [ApiController]
    [Route("api/v1/gateway/user")]
    public class UserController : Controller
    {
        /// <summary>
        /// Add a User
        /// </summary>
        /// <param name="model">Object for the creation of a User</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">If the user is created</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostUser([FromBody] UserModel model)
        {

            return Created();
        }

        /// <summary>
        /// Update a User
        /// </summary>
        /// <param name="model">Object for the Update of a User</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the update occurred</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutUser([FromBody] UserModel model)
        {

            return NoContent();
        }


        /// <summary>
        /// Delete User
        /// </summary>
        /// <param ></param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the user is deleted</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteUser([FromBody] UserModel model)
        {

            return NoContent();
        }
    }
}
