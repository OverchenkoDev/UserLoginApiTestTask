using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserLoginApi.Models;
using UserLoginApi.Classes;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace UserLoginApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly UsersOperations _operations;
        private readonly TokenOptions _token;

        public MainController(UsersOperations operations, TokenOptions token)
        {
            _operations = operations;
            _token = token;
        }

        [Authorize]
        [HttpGet("getInfo/{username}")]
        public IActionResult GetInfo(string username)
        {
            GetUserDataResult result = _operations.GetUserData(username);
            if (result.status == "not active")
            {
                var response = new
                {
                    message = "User is not activated",
                    HttpStatusCode.NoContent
                };
                return new JsonResult(response);
            }
            if (result.status == "not found")
                return NotFound();
            if (result.status == "error")
                return Forbid();
            return new JsonResult(result.userData);
        }

        [HttpPost("login")]
        public IActionResult Login(Users user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
                return BadRequest();
            else
            {
                HttpStatusCode? result = _operations.LoginUser(user.Username, user.Password);
                if (result == HttpStatusCode.OK)
                {
                    string encodedJwt = _token.GenerateToken();
                    var response = new
                    {
                        access_token = encodedJwt,
                        message = "success",
                        HttpStatusCode.OK
                    };
                    return new JsonResult(response);
                }
                else if (result == HttpStatusCode.NotFound)
                    return NotFound();
                else if (result == HttpStatusCode.Unauthorized)
                    return Unauthorized();
                else
                    return Forbid();
            }
        }

        [HttpGet("unhandled/{username}")]
        public IActionResult Unhandled(string username)
        {
            UserNotes result = _operations.GetUserDataError(username);
            if (result == null)
            {
                var response = new
                {
                    message = "User is not activated",
                    HttpStatusCode.NoContent
                };
                return new JsonResult(response);
            }
            else
                return new JsonResult(result);
        }

        [Authorize]
        [HttpPut("updateUser")]
        public IActionResult UpdateUser(UserNotes data)
        {
            if (data == null)
                return BadRequest();
            else
            {
                IActionResult result = _operations.UpdateUserData(data);
                return result;
            }
        }
    }
}
