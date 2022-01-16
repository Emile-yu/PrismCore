using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrismCore.Server.Common.Models;
using PrismCore.Server.Domain.Models;
using PrismCore.Server.IServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrismCore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ILoginServer _login;
        private readonly IMenuServer _menuServer;
        private readonly IUserServer _userServer;
        private readonly ILogger<UserController> _logger;

        public UserController(ILoginServer login, IMenuServer menuServer, IUserServer userServer, ILogger<UserController> logger)
        {
            this._login = login;
            this._menuServer = menuServer;
            this._userServer = userServer;
            this._logger = logger;
        }
        [HttpGet]
        public string Get()
        {
            return "Get";
        }

        [HttpGet("{id}")]
        public string GetID()
        {
            return "GetID";
        }

        [HttpGet("all")]
        public JsonResult GetUser()
        {
            return Json(this._userServer.FindAll<SysUserInfo>(u => true));
        }

        [HttpGet("roles/{userId}")]
        public JsonResult GetRolesByUserId(int userId)
        {
            return Json(this._userServer.GetRolesByUserId(userId));
        }

        [HttpPost]
        public IActionResult Login([FromForm] string username, [FromForm] string password)
        {
            _logger.LogError("error");
            SysUserInfo user = new SysUserInfo() { UserName = username, Password = password };
            //var res = _login.Query<SysUserInfo>(user);

            SysUserInfo res = _login.Login(username, password);//_login.Find<SysUserInfo>(u=>u.UserName == username&&u.Password==password);

            var menus = _menuServer.GetMenuByUserId(res.id);
            res.Menus = menus;
            if (res!=null)
            {
                return Ok(res);

                //todo
                //list menu
                //menu<->role_menu<->role<->role_user<->user
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("Login")]
        public void Login([FromForm] string username)
        {
            string str = $"Hello world : {username}";
        }

        [HttpPost("SignIn")]
        public IActionResult SignIn([FromForm] string username, [FromForm] string password)
        {
            SysUserInfo user = new SysUserInfo() { UserName = username, Password = password };

            _login.Add<SysUserInfo>(user);
            //var res = _login.Query<SysUserInfo>(user);

            SysUserInfo res = _login.Find<SysUserInfo>(u => u.UserName == username && u.Password == password);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }

        }
        [HttpPost("SignInEntity")]
        public IActionResult SignIn(UserEntity sysUser)
        {
            SysUserInfo user = new SysUserInfo() { UserName = sysUser.UserName, Password = sysUser.Password };

            _login.Add<SysUserInfo>(user);
            //var res = _login.Query<SysUserInfo>(user);

            SysUserInfo res = _login.Find<SysUserInfo>(u => u.UserName == sysUser.UserName && u.Password == sysUser.Password);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }

        }

        [HttpPost("resetpwd")]
        public IActionResult ResetPassword([FromForm] IFormCollection form)
        {
            _userServer.ResetPassword(int.Parse(form["userId"]));
            return Ok();
        }

    }
}
