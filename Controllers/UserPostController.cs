using crud_swashbuckle.Model;
using crud_swashbuckle.Repository;
using Microsoft.AspNetCore.Mvc;

namespace crud_swashbuckle.Controllers
{
    [ApiController]
    [Tags("Add user to table")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserPostController : ControllerBase
    {

        private readonly IUserRepository _repository;

        public UserPostController(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Adds a new user to the table
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User Created Successfully</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /TODO
        ///     {
        ///         "name": "Ronaldinho Luiz",
        ///         "dateOfBirth: "2024-01-08T19:31:46.419Z"
        ///     }
        /// </remarks>
        /// <response code="204"> Return user created successfully </response>
        /// <response code="400"> Error creating user </response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(User user)
        {
            _repository.AddUser(user);
            return await _repository.SaveChangeAsync() ? NoContent() : BadRequest("Error creating user");
        }

    }
}