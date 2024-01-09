using crud_swashbuckle.Model;
using crud_swashbuckle.Repository;
using Microsoft.AspNetCore.Mvc;

namespace crud_swashbuckle.Controllers
{
    [ApiController]
    [Tags("Update table user")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserPutController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserPutController(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Update a user table
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns>Resource Updated Successfully</returns>
        /// <remarks>
        ///Sample request:
        /// 
        ///     Update /TODO Before
        ///     {
        ///         "id": 1,   
        ///         "name": "Ronaldinho Luiz",
        ///         "dateOfBirth: "2020-11-28T19:31:46.419"
        ///     }
        /// 
        ///     Update /TODO After
        ///     {
        ///         "id": 1,    
        ///         "name": "Sérgio Luiz",
        ///         "dateOfBirth: "2024-01-08T19:31:46.419"
        ///     }
        ///</remarks>
        ///<response code="200"> Return user Updated successfully </response>
        ///<response code="400"> Error when updating user </response>
        ///<response code="404"> User not found if null</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(int id, User user)
        {

            var userSearch = await _repository.SearchUser(id);

            if (userSearch == null)
            {
                return NotFound("User not found");
            }

            userSearch.Name = user.Name ?? userSearch.Name;
            userSearch.DateOfBirth = user.DateOfBirth == new DateTime() ? user.DateOfBirth : userSearch.DateOfBirth;
            _repository.UpdateUser(userSearch);
            return await _repository.SaveChangeAsync() ? Ok("User updated successfully") : BadRequest("Error when trying to change user values");
        }
    }
}