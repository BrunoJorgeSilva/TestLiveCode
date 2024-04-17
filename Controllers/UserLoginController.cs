using Microsoft.AspNetCore.Mvc;
using TestLiveCode.Service;
using TestLiveCode.ViewModel;

namespace TestLiveCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : Controller
    {
        private readonly IUserLoginService _userLoginService;
        public UserLoginController(IUserLoginService userLoginService) 
        {
            _userLoginService = userLoginService;   
        }
        [HttpGet("ValidateLogin/{user}/{password}")]
        public ActionResult<bool> ValidateLogin(string user, string password)
        {
            return Ok(_userLoginService.ValidateLogin(user, password));
        }

        [HttpPost("PostNewUser")]
        public ActionResult<UserLoginViewModel> PostNewUser(UserLoginViewModel userLogin)
        {
            var newUser = _userLoginService.PostNewUser(userLogin);

            if (newUser is null)
            {
                return NotFound("Sorry New User not added.");
            }
            return Ok(newUser);
        }

        [HttpPut("EditUser")]
        public ActionResult<UserLoginViewModel> EditUser(UserLoginViewModel userToEdit)
        {
            var newUser = _userLoginService.EditUser(userToEdit);

            if(newUser is null || newUser != userToEdit)
            {
                return NotFound("Sorry, it was not possible to edit the user.");
            }
                return Ok(newUser);
        }

        [HttpDelete("DeleteUser")]
        public ActionResult<bool> DeleteUser(UserLoginViewModel user) 
        {
            if (_userLoginService.DeleteUser(user) == true)
                return NotFound("User deleted successfully.");
            else
                return BadRequest("User not deleted");
        }
    }
}
