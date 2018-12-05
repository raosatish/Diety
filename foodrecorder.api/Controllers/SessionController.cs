using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FoodRecorder.Common;
using FoodRecorder.Common.ExtensionMethods;
using FoodRecorder.Data;
using FoodRecorder.API.Services;

namespace api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : Controller
    {
        IFoodRepository _repo;
        ILoginService _loginService;
        ILogger<SessionController> _logger;
        public SessionController(ILogger<SessionController> logger, IFoodRepository repo, ILoginService loginService)
        {
            _repo = repo;
            _loginService = loginService;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            Session uc = _repo.Login(userName, password);
            if(uc != null){
                _loginService.AddUserContext(uc);
            }
            else{
                _logger.LogError("Login failed. user name or password is incorrect.");
                return BadRequest();
            }                
            _logger.LogInformation($"User {userName} successfully logged in.");
            return Created("",uc);
        }

        [HttpDelete]
        public IActionResult Logout(Guid token){
            Session sess = _loginService.ValidateUserContext(token);
            _loginService.RemoveUserContext(sess);
            return NoContent();
        }

    }
}