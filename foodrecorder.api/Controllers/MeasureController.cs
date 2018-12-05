
using System;
using System.Collections.Generic;
using FoodRecorder.API.Services;
using FoodRecorder.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FoodRecorder.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class MeasureController:Controller
{
    [HttpGet()]
    public ActionResult GetListOfMeasures(){
        return Ok(MeasureList.Measures);
    }
}
}