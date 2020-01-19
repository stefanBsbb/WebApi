using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Common;
using Services.CustomModels;
using Services.Interfaces;
using Services.Implementations;

namespace webapi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IIdentityManager manager;
        private readonly UserManager manage;

        public UsersController(IIdentityManager manager,UserManager userManager)
        {
            this.manage = userManager;
            this.manager = manager;
        }
        //gets all users
        [HttpGet]
        public IActionResult AllUsers()
        {
            var all = manage.AllUsers;

            return Ok(all);
        }
        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        //register
        public IActionResult RegisterUser([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = manager.Register(model);
                if (result.Length > 0)
                {
                    return Ok(result);
                }
                return BadRequest("Register attempt is failed. Check email and password!");
            }
            return BadRequest(ModelInfo.TurnModelToString(model));
        }
        [HttpDelete]
        [Route("delete/{id}")]
        //delets user by id
        public IActionResult DeleteUser(int id)
        {
            var res = manager.DeleteUser(id);
            if (res.Length == 0)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("edit")]
        //edits by model
        public IActionResult EditUser([FromBody]UserModel model)
        {
            var res = manager.EditUser(model);
            if (res.Length == 0)
            {
                return Ok(model);
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        //login
        public IActionResult Login([FromBody] LoginModel request)
        {
            var res = manager.LoginUser(request);
            if (res.Length > 0)
            {
                return Ok(res);
            }
            return Unauthorized();
        }
    }
}