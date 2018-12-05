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

namespace FoodRecorder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IFoodRepository _repo;
        public UserController(IFoodRepository repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult Register(string firstName, string lastName, string userName, string password, 
                        string confirmPassword, string emailID, string secretQuestion, string secretAnswer)
        {
            User user = _repo.Register(firstName, lastName, userName, 
                        password, confirmPassword, 
                        emailID, 
                        secretQuestion, secretAnswer);
            if(user == null){
                return BadRequest();
            }                
            return Created("",new UserDTO(user));
        }


    }
}