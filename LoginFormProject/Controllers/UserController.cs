using LoginFormProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LoginFormProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        ////[Route("api/User")]

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            UserModel mod = new UserModel(_configuration);
            List<UserEntity> users = mod.GetAllUsers();

            var JsonData = JsonConvert.SerializeObject(users);

            return Ok(users);
        }


        [HttpPost("SaveUser")]
        public IActionResult SaveUser(UserEntity user)
        {
            UserModel mod = new UserModel(_configuration);
            mod.SaveUser(user);



            return Ok();
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser(int Id)
        {
            UserModel mod = new UserModel(_configuration);
            UserEntity user = mod.GetUser(Id);
            var JsonData = JsonConvert.SerializeObject(user);
            return Ok(user);
        }

        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser(UserEntity user)
        {
            UserModel mod = new UserModel(_configuration);
            mod.UpdateUser(user);

            return Ok();
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int Id)
        {
            UserModel mod = new UserModel(_configuration);
            mod.DeleteUser(Id);

            return Ok();
        }
    }
}

