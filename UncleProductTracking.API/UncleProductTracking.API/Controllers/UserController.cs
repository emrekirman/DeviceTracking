using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UncleProductTracking.Biz.Interfaces;
using UncleProductTracking.Entities.Models;

namespace UncleProductTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBiz _userBiz;

        public UserController(IUserBiz userBiz)
        {
            _userBiz = userBiz;
        }

        [HttpGet("login")]
        public ActionResult Login(string username, string password)
        {
            try
            {
                User user = _userBiz.GetUserByUsernameAndPassword(username, password);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
