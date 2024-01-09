using crud_swashbuckle.Repository;
using Microsoft.AspNetCore.Mvc;

namespace crud_swashbuckle.Controllers
{
    [ApiController]
    [Tags("Get users from table")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserGetController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserGetController(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all users from the table
        /// </summary>
        /// <returns>Users found</returns>
        ///<response code="200"> Return users found </response>
        ///<response code="404"> Users not found if null</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var users = await _repository.SearchUsers();
            return users.Any() ? Ok(users) : NotFound("Users not found");
        }

        /// <summary>
        /// Get table user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User found</returns>
        ///<response code="200"> Return user found </response>
        ///<response code="404"> User not found if null</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.SearchUser(id);
            return user != null ? Ok(user) : NotFound("User not found");
        }
    }
}