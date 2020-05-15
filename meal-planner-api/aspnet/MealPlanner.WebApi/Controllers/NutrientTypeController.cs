using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MealPlanner.DataContext.Repositories;
using MealPlanner.ObjectModels.Models;
using System;
using System.Threading.Tasks;

namespace MealPlanner.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [EnableCors("CorsPolicy")]
  public class NutrientTypeController : ControllerBase
  {
    private UnitOfWork _unitOfWork;
    public NutrientTypeController(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        IEnumerable<NutrientTypeModel> model = await this._unitOfWork.NutrientType.SelectAsync();

        return base.Ok(model);
      }
      catch (Exception ex)
      {
        return base.BadRequest($"Error while getting all the NutrientType! {ex.ToString()}");
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      try
      {
        return base.Ok( await this._unitOfWork.NutrientType.SelectAsync(id) );
      }
      catch (Exception ex)
      {
        return base.NotFound($"NutrientType does not exists! {ex.ToString()}");
      }
    }
  }
}