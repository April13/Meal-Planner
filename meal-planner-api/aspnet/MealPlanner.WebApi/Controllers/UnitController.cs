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
  public class UnitController : ControllerBase
  {
    private UnitOfWork _unitOfWork;
    public UnitController(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        IEnumerable<UnitModel> model = await this._unitOfWork.Unit.SelectAsync();

        return base.Ok(model);
      }
      catch (Exception ex)
      {
        return base.BadRequest($"Error while getting all the Unit! {ex.ToString()}");
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      try
      {
        return base.Ok( await this._unitOfWork.Unit.SelectAsync(id) );
      }
      catch (Exception ex)
      {
        return base.NotFound($"Unit does not exists! {ex.ToString()}");
      }
    }
  }
}