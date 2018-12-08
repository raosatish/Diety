
using System;
using System.Collections.Generic;
using FoodRecorder.API.Services;
using FoodRecorder.Common;
using FoodRecorder.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FoodRecorder.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class FoodController:Controller
{
    
    IFoodRepository _repo;
        ILoginService _loginService;
        ILogger<FoodController> _logger;

        public FoodController(ILogger<FoodController> logger, IFoodRepository repo, ILoginService loginService)
        {
            _repo = repo;
            _loginService = loginService;
            _logger = logger;
        }

    [HttpGet()]
    public ActionResult GetFood(Guid token){
            Session session = _loginService.ValidateUserContext(token);
            List<Food> result = _repo.GetAllFoods(session);
            if(result == null) return NotFound();
            return Ok(result);
    }

    [HttpPost]
    public ActionResult AddFood(Guid token,[FromBody] Food foodItem){
           Session session = _loginService.ValidateUserContext(token);
           Guid id =  _repo.AddFood(session, foodItem);
           if(id != Guid.Empty) return Created("", id);
           return BadRequest();
    }
}
}