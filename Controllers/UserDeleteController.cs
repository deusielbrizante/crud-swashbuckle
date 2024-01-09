using crud_swashbuckle.Repository;
using Microsoft.AspNetCore.Mvc;

namespace crud_swashbuckle.Controllers
{
    [ApiController]
    [Tags("Delete user by id")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserDeleteController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserDeleteController(IUserRepository repository)
        {
            _repository = repository;
        }

        ///<summary>
        ///Delete a Specific User
        ///</summary>
        ///<param name="id"></param>
        ///<returns>User Deleted Successfully</returns>
        ///<remarks>
        ///Sample request:
        /// 
        ///     Delete /TODO
        ///     {
        ///         "id": 1    
        ///     }
        ///</remarks>
        ///<response code="200"> Return user deleted successfully </response>
        ///<response code="400"> Error deleting user </response>
        ///<response code="404"> User not found if null</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var userSearch = await _repository.SearchUser(id);

            if (userSearch == null)
            {
                return NotFound();
            }

            _repository.DeleteUser(userSearch);

            return await _repository.SaveChangeAsync() ? Ok() : BadRequest();
        }
    }
}